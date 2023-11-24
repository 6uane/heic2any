using h2a.Core.Editor.Interfaces;
using h2a.Core.Editor.Receiver;

namespace h2a.Core.Editor.Commands;

public class BlurCommand(ImageProcessor imageProcessor, double radius, double sigma) : ICommand
{

    public void Execute() => imageProcessor.Blur(radius, sigma);
}