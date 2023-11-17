using h2a.Core.ImageConversion.Settings;
using h2a.Core.Interfaces;
using ImageMagick;

namespace h2a.Core.ImageConversion;

public class ImageConversionService : IImageConversionService
{
    private const string HeicExtension = ".heic";

    private static async Task ConvertHeicFile(ImageConversionSettings settings)
    {
        using var image = new MagickImage(settings.FolderPath);
        await image.WriteAsync(
            settings.FolderPath.Replace(
                HeicExtension,
                $"_converted.{settings.DesiredFormat:G}",
                StringComparison.OrdinalIgnoreCase
            )
        );
    }

    public async Task ConvertHeicFilesInFolder(ImageConversionSettings settings) =>
        await Task.WhenAll(
            Directory
                .EnumerateFiles(settings.FolderPath, $"*{HeicExtension}")
                .Select(async _ => await ConvertHeicFile(settings))
        );
}
