using Affdex;
using System;
using System.Collections.Generic;

namespace Controller.Affectiva
{
    public class AffectivaService
    {
        static PhotoDetector detector = new PhotoDetector(2, FaceDetectorMode.LARGE_FACES);
        ImageListenerImpl imageListener = new ImageListenerImpl(detector);
        public Dictionary<string, float> GetEmotions(string filePath)
        {
            Dictionary<string, float> emotions = new Dictionary<string, float>();
            ProcessPhoto(filePath);
            emotions = imageListener.GetEmotions();
            return emotions;
        }



        private void ProcessPhoto(string filePath)
        {
            Helper helper = new Helper();
            String classifierPath = "C:\\Program Files\\Affectiva\\AffdexSDK\\data";
            detector.setClassifierPath(classifierPath);
            detector.setDetectAllExpressions(true);
            detector.setDetectAllEmotions(true);
            detector.setDetectAllEmojis(true);
            detector.setDetectAllAppearances(false);
            Frame frame = helper.LoadFrameFromFile(filePath);
            detector.start();
            detector.process(frame);
            detector.stop();
            
        }
    }

    public class ImageListenerImpl : ImageListener
    {
        Dictionary<string, float> emotions;
        Dictionary<string, float> expressions;
        Dictionary<string, float> emojis;
        public ImageListenerImpl(PhotoDetector detector)
        {
            detector.setImageListener(this);
        }

        public void onImageCapture(Frame frame)
        {

        }

        public void onImageResults(Dictionary<int, Face> faces, Frame frame)
        {
            AddEmotions(faces);
            AddExpressions(faces);
            AddEmojis(faces);
        }

        public Dictionary<string, float> GetEmotions()
        {
            return emotions;
        }

        public Dictionary<string, float> GetExpressions()
        {
            return expressions;
        }

        public Dictionary<string, float> GetEmojis()
        {
            return emojis;
        }

        private void AddEmotions(Dictionary<int, Face> faces)
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

        private void AddExpressions(Dictionary<int, Face> faces)
        {
            foreach (KeyValuePair<int, Face> face in faces)
            {
                Expressions exp = face.Value.Expressions;
                expressions.Add("attention", exp.Attention);
                expressions.Add("brow furrow", exp.BrowFurrow);
                expressions.Add("brow raise", exp.BrowRaise);
                expressions.Add("cheek raise", exp.CheekRaise);
                expressions.Add("chin raise", exp.ChinRaise);
                expressions.Add("dimpler", exp.Dimpler);
                expressions.Add("eye closure", exp.EyeClosure);
                expressions.Add("eye widen", exp.EyeWiden);
                expressions.Add("inner brow raise", exp.InnerBrowRaise);
                expressions.Add("jaw drop", exp.JawDrop);
                expressions.Add("lid tighten", exp.LidTighten);
                expressions.Add("lip corner depressor", exp.LipCornerDepressor);
                expressions.Add("lip press", exp.LipPress);
                expressions.Add("lip pucer", exp.LipPucker);
                expressions.Add("lip stretch", exp.LipStretch);
                expressions.Add("lip suck", exp.LipSuck);
                expressions.Add("mouth open", exp.MouthOpen);
                expressions.Add("nose wrinkle", exp.NoseWrinkle);
                expressions.Add("smile", exp.Smile);
                expressions.Add("smirk", exp.Smirk);
                expressions.Add("upper lip raise", exp.UpperLipRaise);
            }
        }

        private void AddEmojis(Dictionary<int, Face> faces)
        {
            foreach (KeyValuePair<int, Face> face in faces)
            {
                Emojis em = face.Value.Emojis;
                emojis.Add("disappointed", em.disappointed);
                emojis.Add("flushed", em.flushed);
                emojis.Add("kissing", em.kissing);
                emojis.Add("laughing", em.laughing);
                emojis.Add("rage", em.rage);
                emojis.Add("relaxed", em.relaxed);
                emojis.Add("scream", em.scream);
                emojis.Add("smiley", em.smiley);
                emojis.Add("smirk", em.smirk);
                emojis.Add("stuck out tongue", em.stuckOutTongue);
                emojis.Add("stuck out tongue winking eye", em.stuckOutTongueWinkingEye);
                emojis.Add("wink", em.wink);
            }
        }
    }
}
