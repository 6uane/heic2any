using ImageMagick;

namespace h2a.Core.Interfaces;

public interface IConversionSettings
{
    public MagickFormat SourceFormat { get; }
    public MagickFormat TargetFormat { get; }
    public int Quality { get; }
}
