using h2a.Core.Common.ConversionSettings;
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
            var service = new ImageConversionService();
            var settings = new ConversionSettings(
                _testDirectoryPath,
                MagickFormat.Heic,
                MagickFormat.Jpeg
            );

            await service.ConvertHeicFilesInFolder(settings);
        }
    }
}
