using h2a.Core.ImageConversion.Settings;
using h2a.Core.Interfaces;
using ImageMagick;

namespace h2a.Core.ImageConversion;

public class ImageConversionService : IImageConversionService
{
    public const string HeicExtension = ".heic";

    public async Task ConvertHeicFilesInFolder(ImageConversionSettings settings) =>
        await Task.WhenAll(
            Directory
                .EnumerateFiles(settings.FolderPath, $"*{HeicExtension}")
                .Select(async file =>
                {
                    using var image = new MagickImage(file);
                    await image.WriteAsync(
                        file.Replace(
                            HeicExtension,
                            $"_converted.{settings.DesiredFormat:G}",
                            StringComparison.OrdinalIgnoreCase
                        )
                    );
                })
        );
}
