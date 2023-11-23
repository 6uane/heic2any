using ImageMagick;

namespace h2a.Core.LivePreview.Interfaces;

public interface IImageProcessor
{
    void SetImage(MagickImage image);
    MagickImage GetSourceImageClone();
    MagickImage GetPreviewImageClone();
    void Resize(int width, int height);
}
