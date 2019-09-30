using Affdex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Controller.Affectiva
{
    public class AffectivaService
    {
        public Dictionary<string, float> GetEmotions(string filePath)
        {
            Helper helper = new Helper();
            Dictionary<string, float> emotions = new Dictionary<string, float>();

            PhotoDetector detector = new PhotoDetector(2, FaceDetectorMode.LARGE_FACES);
            String classifierPath = "C:\\Program Files\\Affectiva\\AffdexSDK\\data";
            detector.setClassifierPath(classifierPath);
            ImageListenerImpl imageListener = new ImageListenerImpl(detector);
            detector.setDetectAllExpressions(true);
            detector.setDetectAllEmotions(true);
            detector.setDetectAllEmojis(true);
            detector.setDetectAllAppearances(true);

            Frame frame = helper.LoadFrameFromFile(filePath);
            detector.start();
            detector.process(frame);
            emotions = imageListener.GetEmotions();
            detector.stop();
            return emotions;
        }

        
    }

    public class ImageListenerImpl : ImageListener
    {
        Dictionary<string, float> emotions;
        public ImageListenerImpl(PhotoDetector detector)
        {
            detector.setImageListener(this);
        }

        public void onImageCapture(Frame frame)
        {

        }

        public void onImageResults(Dictionary<int, Face> faces, Frame frame)
        {
            foreach (KeyValuePair<int, Face> face in faces)
            {
                Emotions emo = face.Value.Emotions;
                emotions.Add("anger", emo.Anger);
                emotions.Add("joy", emo.Joy);
                emotions.Add("contempt", emo.Contempt);
                emotions.Add("disgust", emo.Disgust);
                emotions.Add("engagement", emo.Engagement);
                emotions.Add("fear", emo.Fear);
                emotions.Add("sadness", emo.Sadness);
                emotions.Add("surprise", emo.Surprise);
                emotions.Add("valence", emo.Valence);
            }
        }

        public Dictionary<string, float> GetEmotions()
        {
            return emotions;
        }
    }
}
