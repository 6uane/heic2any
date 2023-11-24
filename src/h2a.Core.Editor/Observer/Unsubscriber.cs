namespace h2a.Core.Editor.Observer;

public class Unsubscriber<TMagickImage>(
    ICollection<IObserver<TMagickImage>> observers,
    IObserver<TMagickImage> observer
) : IDisposable
{
    public void Dispose() => observers.Remove(observer);
}