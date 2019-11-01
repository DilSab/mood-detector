using Affdex;
using Model.Entity;
using System.Collections.Generic;

namespace ControllerProject.Affectiva
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

        public MoodCollection GetMoodCollection()
        {
            Dictionary<string, float> emotions = GetEmotions();

            MoodCollection moodCollection = new MoodCollection
            {
                Anger = emotions["anger"],
                Contempt = emotions["contempt"],
                Disgust = emotions["disgust"],
                Engagement = emotions["engagement"],
                Fear = emotions["fear"],
                Joy = emotions["joy"],
                Sadness = emotions["sadness"],
                Suprise = emotions["surprise"],
                Valence = emotions["valence"]
            };

            return moodCollection;
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
