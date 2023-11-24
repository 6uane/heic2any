using h2a.Core.Interfaces;
using ImageMagick;

namespace h2a.Core.Common.Settings;

public record FolderConversionSettings(
    string FolderPath,
    MagickFormat SourceFormat,
    MagickFormat TargetFormat,
    int Quality
) : IConversionSettings;