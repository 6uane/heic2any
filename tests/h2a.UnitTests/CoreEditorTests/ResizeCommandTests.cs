using h2a.Core.LivePreview.Commands;
using h2a.Core.LivePreview.Receiver;
using ImageMagick;
using System.Reflection;

namespace h2a.UnitTests.CoreEditorTests;

[TestFixture]
public class ResizeCommandTests
{
    private string _testDataDirectory = null!;

    [SetUp]
    public void Init()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        _testDataDirectory = Path.Combine(
            currentDirectory,
            "..",
            "..",
            "..",
            "TestData",
            "HEICFiles"
        );
    }

    [Test]
    public void ResizeCommand_ResizeToLargerDimensions()
    {
        // Arrange
        var imageProcessor = new ImageProcessor();
        var image = new MagickImage(_testDataDirectory + "/sample1.heic");
        imageProcessor.SetImage(image);

        const int width = 400;
        const int height = 300;
        var command = new ResizeCommand(width, height, imageProcessor);

        // Act
        command.Execute();

        // Assert
        var resizedImage = imageProcessor.GetPreviewImageClone();
        Assert.AreEqual(width, resizedImage.Width);
        Assert.AreEqual(height, resizedImage.Height);
    }

    [Test]
    public void ResizeCommand_ResizeAndUndo()
    {
        // Arrange
        var imageProcessor = new ImageProcessor();
        var image = new MagickImage(_testDataDirectory + "/sample1.heic");
        imageProcessor.SetImage(image);

        const int width = 200;
        const int height = 150;
        var command = new ResizeCommand(width, height, imageProcessor);

        // Act
        command.Execute();
        command.Undo();

        // Assert
        var resizedImage = imageProcessor.GetPreviewImageClone();
        Assert.AreEqual(image.Width, resizedImage.Width);
        Assert.AreEqual(image.Height, resizedImage.Height);
    }

    [Test]
    public void ResizeCommand_ResizeAndRedo()
    {
        // Arrange
        var imageProcessor = new ImageProcessor();
        var image = new MagickImage(_testDataDirectory + "/sample1.heic");
        imageProcessor.SetImage(image);

        const int width = 200;
        const int height = 150;
        var command = new ResizeCommand(width, height, imageProcessor);

        // Act
        command.Execute();
        command.Undo();
        command.Redo();

        // Assert
        var resizedImage = imageProcessor.GetPreviewImageClone();
        Assert.AreEqual(width, resizedImage.Width);
        Assert.AreEqual(height, resizedImage.Height);
    }
}
