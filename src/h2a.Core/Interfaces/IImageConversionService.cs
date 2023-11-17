using h2a.Core.ImageConversion.Settings;

namespace h2a.Core.Interfaces;

public interface IImageConversionService
{
    Task ConvertHeicFilesInFolder(ImageConversionSettings settings);
}