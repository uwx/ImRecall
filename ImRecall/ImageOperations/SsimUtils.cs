using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using SixLabors.ImageSharp.PixelFormats;

namespace ImRecall;

public static class SsimUtils
{
    public static bool IsSimilar<TPixel>(LibraryIndependentImage<TPixel> img1, LibraryIndependentImage<TPixel> img2, double threshold = 0.9)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        return ComputeMeanSsim(img1, img2) >= threshold;
    }
        
    private static double GetLuminance<TPixel>(TPixel pixel) where TPixel : unmanaged, IPixel<TPixel>
    {
        var p = new Rgba32();
        pixel.ToRgba32(ref p);
        return 0.299 * p.R + 0.587 * p.G + 0.114 * p.B;
    }

    // Computes the mean SSIM between two images in parallel
    public static double ComputeMeanSsim<TPixel>(LibraryIndependentImage<TPixel> img1, LibraryIndependentImage<TPixel> img2)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        if (img1.Width != img2.Width || img1.Height != img2.Height)
            throw new ArgumentException("Images must have the same dimensions.");

        int width = img1.Width;
        int height = img1.Height;
        int windowSize = 8;

        int maxSteps = SimplifiedRowIterator.DivideCeil(width * (long)height, 1024);
        var numOfSteps = Math.Min(Environment.ProcessorCount, maxSteps);
            
        var op = new SsimRowOperation<TPixel>(img1, img2, windowSize, numOfSteps);

        var stopwatch = Stopwatch.StartNew();
        SimplifiedRowIterator.IterateRowsWithIndex(new Rectangle(0, 0, width, height), op, numOfSteps);
        var meanSsim = op.GetMeanSsim();
        stopwatch.Stop();
        Console.WriteLine($"SSIM computation took {stopwatch.ElapsedMilliseconds} ms. Similarity: {meanSsim:F4}");

        return meanSsim;
    }

    private struct SsimRowOperation<TPixel> : IRowOperationWithIndex where TPixel : unmanaged, IPixel<TPixel>
    {
        private readonly LibraryIndependentImage<TPixel> _img1;
        private readonly LibraryIndependentImage<TPixel> _img2;
        private readonly int _windowSize;

        // SSIM constants
        private readonly double _k1 = 0.01;
        private readonly double _k2 = 0.03;
        private readonly double _l = 255;
        private readonly double _c1;
        private readonly double _c2;
            
        private readonly double[] _ssimSums;
        private readonly int[] _counts;
        private readonly int _numOfSteps;

        public SsimRowOperation(LibraryIndependentImage<TPixel> img1, LibraryIndependentImage<TPixel> img2, int windowSize, int numOfSteps)
        {
            _img1 = img1;
            _img2 = img2;
            _windowSize = windowSize;
            _numOfSteps = numOfSteps;
                
            _c1 = (_k1 * _l) * (_k1 * _l);
            _c2 = (_k2 * _l) * (_k2 * _l);
                
            _ssimSums = new double[numOfSteps];
            _counts = new int[numOfSteps];
        }

        public void Invoke(int y, int index)
        {
            int height = _img1.Height;
            int width = _img1.Width;
            if (y > height - _windowSize) return;

            double localSum = 0.0;
            int localCount = 0;
            for (int x = 0; x <= width - _windowSize; x += _windowSize)
            {
                double mean1 = 0, mean2 = 0, var1 = 0, var2 = 0, covar = 0;
                for (int wy = 0; wy < _windowSize; wy++)
                {
                    var row1 = _img1.DangerousGetRowSpan(y + wy);
                    var row2 = _img2.DangerousGetRowSpan(y + wy);
                    for (int wx = 0; wx < _windowSize; wx++)
                    {
                        double v1 = GetLuminance(row1[x + wx]);
                        double v2 = GetLuminance(row2[x + wx]);
                        mean1 += v1;
                        mean2 += v2;
                    }
                }
                mean1 /= (_windowSize * _windowSize);
                mean2 /= (_windowSize * _windowSize);
                for (int wy = 0; wy < _windowSize; wy++)
                {
                    var row1 = _img1.DangerousGetRowSpan(y + wy);
                    var row2 = _img2.DangerousGetRowSpan(y + wy);
                    for (int wx = 0; wx < _windowSize; wx++)
                    {
                        double v1 = GetLuminance(row1[x + wx]);
                        double v2 = GetLuminance(row2[x + wx]);
                        var1 += (v1 - mean1) * (v1 - mean1);
                        var2 += (v2 - mean2) * (v2 - mean2);
                        covar += (v1 - mean1) * (v2 - mean2);
                    }
                }
                var1 /= (_windowSize * _windowSize - 1);
                var2 /= (_windowSize * _windowSize - 1);
                covar /= (_windowSize * _windowSize - 1);
                double ssim = ((2 * mean1 * mean2 + _c1) * (2 * covar + _c2)) /
                              ((mean1 * mean1 + mean2 * mean2 + _c1) * (var1 + var2 + _c2));
                localSum += ssim;
                localCount++;
            }
                
            _ssimSums[index] = localSum;
            _counts[index] = localCount;
        }

        public double GetMeanSsim()
        {
            var countsSum = _counts.Sum();
            return countsSum == 0 ? 0 : _ssimSums.Sum() / countsSum;
        }
    }
}