using h2a.Core.Common.Settings;
using h2a.Core.Interfaces;
using h2a.Core.Services;
using ImageMagick;

namespace h2a.UnitTests
{
    [TestFixture]
    public class Tests
    {
        private const string _testDirectoryPath =
            @"C:\Users\duane\RiderProjects\h2a\tests\h2a.UnitTests\TestData\\HEICFiles";

        [Test]
        public async Task ConvertDirectoryFiles()
        {
            IImageConversionService service = new ImageConversionService();
            var settings = new FolderConversionSettings(
                _testDirectoryPath,
                MagickFormat.Heic,
                MagickFormat.Jpeg,
                100
            );

            await service.ConvertImageFilesInFolder(settings);
        }
    }
}
