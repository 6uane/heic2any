using ImageMagick;

namespace h2a.Core.Editor.Interfaces;

public interface IImageProcessor
{
    void SetImage(MagickImage image);
    MagickImage GetSourceImageClone();
    MagickImage GetPreviewImageClone();
    void Resize(IMagickGeometry geometry);
}