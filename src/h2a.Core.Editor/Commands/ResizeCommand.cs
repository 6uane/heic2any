using h2a.Core.LivePreview.Interfaces;

namespace h2a.Core.LivePreview.Commands;

public class ResizeCommand(int width, int height, IImageProcessor imageProcessor) : IUndoCommand
{
    private readonly int _preResizeWidth = imageProcessor.GetPreviewImageClone().Width;
    private readonly int _preResizeHeight = imageProcessor.GetPreviewImageClone().Height;

    public void Execute() => imageProcessor.Resize(width, height);

    public void Undo() => imageProcessor.Resize(_preResizeWidth, _preResizeHeight);

    public void Redo() => Execute();
}
