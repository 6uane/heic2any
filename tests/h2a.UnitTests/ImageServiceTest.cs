using h2a.Core;
using h2a.Core.Services;
using ImageMagick;

namespace h2a.UnitTests;

public class Tests
{
    private ImageConversionService _imageConversionService;
    private const string _heicFilesFolderPath =
        @"C:\Users\duane\RiderProjects\h2a\tests\h2a.UnitTests\TestData\HEICFiles";

    [SetUp]
    public void Setup()
    {
        _imageConversionService = new ImageConversionService();
    }

    // [TearDown]
    // public void TearDown()
    // {
    // foreach (var file in Directory.GetFiles(_heicFilesFolderPath))
    // {
    // if (file.EndsWith(MagickFormat.Jpeg.ToString("G"), StringComparison.OrdinalIgnoreCase))
    // File.Delete(file);
    // }
    // }

    [Test]
    public async Task ConvertAllHeicToDesiredFormat()
    {
        IEnumerable<FileInfo> files;
        var settings = new ImageConversionSettings(_heicFilesFolderPath, MagickFormat.Jpeg);

        await _imageConversionService.ConvertHeicFilesInFolder(settings);
        files = new DirectoryInfo(_heicFilesFolderPath).EnumerateFiles();

        Assert.AreEqual(8, files.Count());
    }
}
