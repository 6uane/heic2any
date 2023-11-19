using h2a.Core.Common.ConversionSettings;
using h2a.Core.Interfaces;
using ImageMagick;

namespace h2a.Core.Services;

public class ImageConversionService : IImageConversionService
{
    private const string HeicExtension = ".heic";

    public async Task ConvertHeicFilesInFolder(ConversionSettings settings) =>
        await Task.WhenAll(
            Directory
                .EnumerateFiles(settings.path, $"*{MagickFormat.Heic:G}")
                .Select(
                    selector: async filePath =>
                        await ConvertHeicFile(filePath, settings.DesiredFormat)
                )
        );

    public async Task ConvertHeicFile(string filePath, MagickFormat desiredFormat)
    {
        using var image = new MagickImage(filePath);
        await image.WriteAsync(
            filePath.Replace(
                HeicExtension,
                $"_converted.{desiredFormat:G}",
                StringComparison.OrdinalIgnoreCase
            )
        );
    }
}
