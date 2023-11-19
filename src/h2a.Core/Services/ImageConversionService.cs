using h2a.Core.Common.Settings;
using h2a.Core.Interfaces;
using ImageMagick;

namespace h2a.Core.Services;

public class ImageConversionService : IImageConversionService
{
    public async Task ConvertImageFilesInFolder(FolderConversionSettings settings) =>
        await Task.WhenAll(
            Directory
                .EnumerateFiles(settings.FolderPath, $"*.{settings.SourceFormat:G}")
                .Select(
                    selector: async imageFilePath => await ConvertImageFile(imageFilePath, settings)
                )
        );

    public async Task ConvertImageFile(string imageFilePath, IConversionSettings settings)
    {
        using var image = new MagickImage(imageFilePath);
        (image.Format, image.Quality) = (settings.TargetFormat, settings.Quality);

        await image.WriteAsync(
            imageFilePath.Replace(
                $".{settings.SourceFormat:G}",
                $"_converted.{settings.TargetFormat:G}",
                StringComparison.OrdinalIgnoreCase
            )
        );

        image.Dispose();
    }
}
