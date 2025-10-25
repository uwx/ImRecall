using System.Drawing;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Advanced;

namespace ImRecall;

public static class SimplifiedRowIterator
{
    public static void IterateRows<T>(
        Rectangle rectangle,
        in T operation)
        where T : struct, IRowOperation
    {
        int top = rectangle.Top;
        int bottom = rectangle.Bottom;
        int width = rectangle.Width;
        int height = rectangle.Height;

        int maxSteps = DivideCeil(width * (long)height, 1024);
        int numOfSteps = Math.Min(Environment.ProcessorCount, maxSteps);

        // Avoid TPL overhead in this trivial case:
        if (numOfSteps == 1)
        {
            for (int y = top; y < bottom; y++)
            {
                Unsafe.AsRef(in operation).Invoke(y);
            }

            return;
        }

        int verticalStep = DivideCeil(rectangle.Height, numOfSteps);
        var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = numOfSteps };
        var wrappingOperation = new RowOperationWrapper<T>(top, bottom, verticalStep, in operation);

        Parallel.For(
            0,
            numOfSteps,
            parallelOptions,
            wrappingOperation.Invoke);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int DivideCeil(long dividend, int divisor) => (int)Math.Min(1 + ((dividend - 1) / divisor), int.MaxValue);

    [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly struct RowOperationWrapper<T>(
        int minY,
        int maxY,
        int stepY,
        in T action
    )
        where T : struct, IRowOperation
    {
        private readonly T _action = action;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(int i)
        {
            int yMin = minY + (i * stepY);

            if (yMin >= maxY)
            {
                return;
            }

            int yMax = Math.Min(yMin + stepY, maxY);

            for (int y = yMin; y < yMax; y++)
            {
                // Skip the safety copy when invoking a potentially impure method on a readonly field
                Unsafe.AsRef(in _action).Invoke(y);
            }
        }
    }
}