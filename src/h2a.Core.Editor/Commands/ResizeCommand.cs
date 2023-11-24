using h2a.Core.Editor.Interfaces;
using ImageMagick;

namespace h2a.Core.Editor.Commands;

public class ResizeCommand(IMagickGeometry geometry, IImageProcessor imageProcessor) : ICommand
{
    public void Execute() => imageProcessor.Resize(geometry);
}