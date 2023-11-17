using ImageMagick;

namespace h2a.Core;

public record ImageConversionSettings(string FolderPath, MagickFormat DesiredFormat);
