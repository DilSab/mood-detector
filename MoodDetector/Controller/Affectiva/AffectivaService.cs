using Affdex;
using System.Collections.Generic;

namespace Controller.Affectiva
{
    public class AffectivaService
    {
        readonly PhotoDetector detector;
        readonly ImageListenerImpl imageListener;
        readonly Helper helper;

        AffectivaService()
        {
            detector = new PhotoDetector(1, FaceDetectorMode.LARGE_FACES);
            imageListener = new ImageListenerImpl(detector);
            helper = new Helper();
            detector.setClassifierPath("C:\\Program Files\\Affectiva\\AffdexSDK\\data");
            detector.setDetectAllExpressions(true);
            detector.setDetectAllEmotions(true);
            detector.setDetectAllEmojis(true);
            detector.setDetectAllAppearances(false);
        }

        public void ProcessPhoto(string filePath)
        {
            Frame frame = helper.LoadFrameFromFile(filePath);
            detector.start();
            detector.process(frame);
            detector.stop();
        }

        public Dictionary<string, float> GetEmotions()
        {
            return imageListener.GetEmotions();
        }

        public Dictionary<string, float> GetExpressions()
        {
            return imageListener.GetExpressions();
        }

        public Dictionary<string, float> GetEmojis()
        {
            return imageListener.GetEmojis();
        }
    }
}
