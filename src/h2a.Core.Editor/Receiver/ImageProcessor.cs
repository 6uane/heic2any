using h2a.Core.Editor.Interfaces;
using h2a.Core.Editor.Observer;
using ImageMagick;

namespace h2a.Core.Editor.Receiver;

public class ImageProcessor : IImageProcessor, IObservable<MagickImage>, IDisposable
{

    private readonly HashSet<IObserver<MagickImage>> _observers =
        new HashSet<IObserver<MagickImage>>();

    private MagickImage _preview = null!;
    private MagickImage _source = null!;

    public void Dispose()
    {
        _source.Dispose();
        _preview.Dispose();
    }

    public void SetImage(MagickImage image) =>
        (_source, _preview) = (image, (MagickImage)image.Clone());

    public MagickImage GetSourceImageClone() => (MagickImage)_source.Clone();

    public MagickImage GetPreviewImageClone() => (MagickImage)_preview.Clone();

    public void Resize(IMagickGeometry geometry) => _preview.Resize(geometry);

    public IDisposable Subscribe(IObserver<MagickImage> observer)
    {
        if (_observers.Add(observer))
            observer.OnNext(_preview);

        return new Unsubscriber<MagickImage>(_observers, observer);
    }

    public void Blur(double radius, double sigma) => _preview.Blur(radius, sigma);
}