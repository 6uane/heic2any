using h2a.Core.Common.Settings;

namespace h2a.Core.Interfaces;

public interface IImageConversionService
{
    Task ConvertImageFilesInFolder(FolderConversionSettings settings);
    Task ConvertImageFile(string imageFilePath, IConversionSettings settings);
}
