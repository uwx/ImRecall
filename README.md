# ImRecall

A .NET tool that automatically captures Windows screenshots every 3 seconds and uploads them to
[Immich](https://immich.app/), a self-hosted photo and video backup solution.

This lets you take advantage of Immich's powerful search (and newly added OCR) for your screenshots.

## Features

- Captures screenshots from all connected displays using Windows Graphics Capture API (virtually instant)
- Only uploads visually different screenshots
- HDR to SDR tonemapping for proper color representation (no washed out colors)
- Organizes screenshots by screen name and active window title
- Automatically uploads to Immich in an "ImRecall" titled album

## Installation

1. Download a Release build
2. Set up Immich authentication:

Either authenticate with Immich CLI (`pnpm dlx @immich/cli login <url> <key>`) or create a YAML file at `~/.config/immich/auth.yml`:
```yaml
url: https://your-immich-instance.com
key: your-api-key
```

## Configuration

Create an `appsettings.json` file in the same directory as the executable to configure ImRecall:

```json
{
  "ImRecall": {
    "EnableUpload": true,
    "AlbumName": "ImRecall",
    "ArchiveUploads": true
  }
}
```

Configuration options:
- `EnableUpload` - Whether to upload screenshots to Immich (default: `true`)
- `AlbumName` - Name of the Immich album to upload to (default: `"ImRecall"`)
- `ArchiveUploads` - Whether to mark uploaded assets as archived in Immich (default: `true`)

## Usage

### Basic Usage

Run the tool to start capturing and uploading screenshots:

```powershell
.\ImRecall
```

The tool will:
- Capture screenshots from all displays every 3 seconds
- Skip duplicate screenshots using similarity detection
- Upload new screenshots to Immich with filename format: `[DisplayName]-[WindowTitle]-[Timestamp].png`

### Publishing

Build a native AOT executable for production:

```powershell
dotnet publish -c Release
```

## Requirements

- Windows 10, 2104 or later

## License

AGPL

## Credits

Vaguely inspired by [OpenRecall](https://github.com/openrecall/openrecall) and [Windows Recall](https://support.microsoft.com/en-us/windows/retrace-your-steps-with-recall-aa03f8a0-a78b-4b3e-b0a1-2eb8ac48701c).