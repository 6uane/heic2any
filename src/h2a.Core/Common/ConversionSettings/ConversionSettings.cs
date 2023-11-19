using ImageMagick;

namespace h2a.Core.Common.ConversionSettings;

public record ConversionSettings(
    string path,
    MagickFormat CurrentFormat,
    MagickFormat DesiredFormat
);