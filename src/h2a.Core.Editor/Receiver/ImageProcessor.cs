using h2a.Core.LivePreview.Interfaces;
using ImageMagick;

namespace h2a.Core.LivePreview.Receiver;

public class ImageProcessor : IImageProcessor
{
    private MagickImage _source = null!;
    private MagickImage _preview = null!;

    public void SetImage(MagickImage image) =>
        (_source, _preview) = (image, (MagickImage)image.Clone());

    public MagickImage GetSourceImageClone() => (MagickImage)_source.Clone();

    public MagickImage GetPreviewImageClone() => (MagickImage)_preview.Clone();

    public void Resize(int width, int height)
    {
        // Resize doesn't fill the box just fit it
        IMagickGeometry geometry = new MagickGeometry(width, height);
        geometry.IgnoreAspectRatio = true;
        geometry.FillArea = true;
        _preview.Resize(geometry);
    }
}
