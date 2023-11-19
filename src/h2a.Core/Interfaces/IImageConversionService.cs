using h2a.Core.Common.ConversionSettings;
using ImageMagick;

namespace h2a.Core.Interfaces;

public interface IImageConversionService
{
    Task ConvertHeicFilesInFolder(ConversionSettings settings);
    Task ConvertHeicFile(string filePath, MagickFormat desiredFormat);
}
