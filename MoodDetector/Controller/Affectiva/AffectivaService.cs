using Affdex;
using System.Collections.Generic;

namespace Controller.Affectiva
{
    public class AffectivaService
    {
        readonly PhotoDetector detector;
        readonly ImageListenerImpl imageListener;

        public AffectivaService()
        {
            detector = new PhotoDetector(1, FaceDetectorMode.LARGE_FACES);
            imageListener = new ImageListenerImpl(detector);
            detector.setClassifierPath("C:\\Program Files\\Affectiva\\AffdexSDK\\data");
            detector.setDetectAllExpressions(true);
            detector.setDetectAllEmotions(true);
            detector.setDetectAllEmojis(true);
            detector.setDetectAllAppearances(false);
        }

        public void ProcessPhoto(string filePath)
        {
            imageListener.CreateDictionaries();
            Frame frame = Helper.LoadFrameFromFile(filePath);
            detector.reset();
            detector.process(frame);
        }

        public void StartDetector()
        {
            detector.start();
        }

        public void StopDetector()
        {
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
