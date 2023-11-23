using h2a.Core.LivePreview.Interfaces;
using ImageMagick;

namespace h2a.Core.LivePreview.Commands;

public class ResizeCommand(IMagickGeometry geometry, IImageProcessor imageProcessor) : IUndoCommand
{
    private readonly int _preResizeWidth = imageProcessor.GetPreviewImageClone().Width;
    private readonly int _preResizeHeight = imageProcessor.GetPreviewImageClone().Height;

    public void Execute() => imageProcessor.Resize(geometry);

    public void Undo() =>
        imageProcessor.Resize(
            new MagickGeometry { Height = _preResizeHeight, Width = _preResizeWidth }
        );

    public void Redo() => Execute();
}
