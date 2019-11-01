using ControllerProject.Affectiva;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace UnitTest.Affectiva.AffectivaServiceTest
{
    public class AffectivaServiceTest
    {
        AffectivaService affectiva = new AffectivaService();

        public AffectivaServiceTest()
        {
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string pattern = @"\\bin";
            string projectFolderWithoutBin = Regex.Replace(projectFolder, pattern, "", RegexOptions.IgnoreCase);
            var photoPath = Path.Combine(projectFolderWithoutBin, @"woman.jpg");
            affectiva.StartDetector();
            affectiva.ProcessPhoto(photoPath);
        }

        [Fact]
        public void TestAffectivaServiceReturn9EmotionDictionary()
        {
            Dictionary<string, float> emotions = affectiva.GetEmotions();
            Assert.Equal(9, emotions.Keys.Count);
        }

        [Theory]
        [InlineData("anger")]
        [InlineData("joy")]
        [InlineData("contempt")]
        [InlineData("disgust")]
        [InlineData("engagement")]
        [InlineData("fear")]
        [InlineData("sadness")]
        [InlineData("surprise")]
        [InlineData("valence")]
        public void TestAffectivaServiceReturnAllEmotionKeys(string key)
        {
            Dictionary<string, float> emotions = affectiva.GetEmotions();
            Assert.True(emotions.ContainsKey(key));
        }

        [Fact]
        public void TestAffectivaServiceReturn21ExpressionDictionary()
        {
            Dictionary<string, float> expressions = affectiva.GetExpressions();
            Assert.Equal(21, expressions.Keys.Count);
        }

        [Theory]
        [InlineData("attention")]
        [InlineData("brow furrow")]
        [InlineData("brow raise")]
        [InlineData("cheek raise")]
        [InlineData("chin raise")]
        [InlineData("dimpler")]
        [InlineData("eye closure")]
        [InlineData("eye widen")]
        [InlineData("inner brow raise")]
        [InlineData("jaw drop")]
        [InlineData("lid tighten")]
        [InlineData("lip corner depressor")]
        [InlineData("lip press")]
        [InlineData("lip pucker")]
        [InlineData("lip stretch")]
        [InlineData("lip suck")]
        [InlineData("mouth open")]
        [InlineData("nose wrinkle")]
        [InlineData("smile")]
        [InlineData("smirk")]
        [InlineData("upper lip raise")]
        public void TestAffectivaServiceReturnAllExpressionKeys(string key)
        {
            Dictionary<string, float> expressions = affectiva.GetExpressions();
            Assert.True(expressions.ContainsKey(key));
        }

        [Fact]
        public void TestAffectivaServiceReturn12EmojiDictionary()
        {
            Dictionary<string, float> emojis = affectiva.GetEmojis();
            Assert.Equal(12, emojis.Keys.Count);
        }

        [Theory]
        [InlineData("disappointed")]
        [InlineData("flushed")]
        [InlineData("kissing")]
        [InlineData("laughing")]
        [InlineData("rage")]
        [InlineData("relaxed")]
        [InlineData("scream")]
        [InlineData("smiley")]
        [InlineData("smirk")]
        [InlineData("stuck out tongue")]
        [InlineData("stuck out tongue winking eye")]
        [InlineData("wink")]
        public void TestAffectivaServiceReturnAllEmojisKeys(string key)
        {
            Dictionary<string, float> emojis = affectiva.GetEmojis();
            Assert.True(emojis.ContainsKey(key));
        }
    }
}
