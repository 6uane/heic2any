using h2a.Core.Editor.Commands;
using h2a.Core.Editor.Receiver;
using ImageMagick;

namespace h2a.UnitTests.CoreEditorTests;

[TestFixture]
public class ResizeCommandTests
{

    [SetUp] public void Init()
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
    private string _testDataDirectory = null!;

    [Test] public void ResizeCommand_ResizeToLargerDimensions()
    {
        // Arrange
        var imageProcessor = new ImageProcessor();
        var image = new MagickImage(_testDataDirectory + "/sample1.heic");
        imageProcessor.SetImage(image);

        const int width = 400;
        const int height = 300;
        var command = new ResizeCommand(
        new MagickGeometry(width, height) { FillArea = true, IgnoreAspectRatio = true },
        imageProcessor
        );

        // Act
        command.Execute();

        // Assert
        var resizedImage = imageProcessor.GetPreviewImageClone();
        Assert.AreEqual(width, resizedImage.Width);
        Assert.AreEqual(height, resizedImage.Height);
    }
}