using Affdex;
using System.Collections.Generic;

namespace Controller.Affectiva
{
    public class ImageListenerImpl : ImageListener
    {
        public Dictionary<string, float> Emotions;
        public Dictionary<string, float> Expressions;
        public Dictionary<string, float> Emojis;

        public ImageListenerImpl(PhotoDetector detector)
        {
            detector.setImageListener(this);
        }

        public void CreateDictionaries()
        {
            Emotions = new Dictionary<string, float>();
            Expressions = new Dictionary<string, float>();
            Emojis = new Dictionary<string, float>();
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
            return Emotions;
        }

        public Dictionary<string, float> GetExpressions()
        {
            return Expressions;
        }

        public Dictionary<string, float> GetEmojis()
        {
            return Emojis;
        }

        private void AddEmotions(Dictionary<int, Face> faces)
        {
            foreach (KeyValuePair<int, Face> face in faces)
            {
                Emotions emo = face.Value.Emotions;
                Emotions.Add("anger", emo.Anger);
                Emotions.Add("joy", emo.Joy);
                Emotions.Add("contempt", emo.Contempt);
                Emotions.Add("disgust", emo.Disgust);
                Emotions.Add("engagement", emo.Engagement);
                Emotions.Add("fear", emo.Fear);
                Emotions.Add("sadness", emo.Sadness);
                Emotions.Add("surprise", emo.Surprise);
                Emotions.Add("valence", emo.Valence);
            }
        }

        private void AddExpressions(Dictionary<int, Face> faces)
        {
            foreach (KeyValuePair<int, Face> face in faces)
            {
                Expressions exp = face.Value.Expressions;
                Expressions.Add("attention", exp.Attention);
                Expressions.Add("brow furrow", exp.BrowFurrow);
                Expressions.Add("brow raise", exp.BrowRaise);
                Expressions.Add("cheek raise", exp.CheekRaise);
                Expressions.Add("chin raise", exp.ChinRaise);
                Expressions.Add("dimpler", exp.Dimpler);
                Expressions.Add("eye closure", exp.EyeClosure);
                Expressions.Add("eye widen", exp.EyeWiden);
                Expressions.Add("inner brow raise", exp.InnerBrowRaise);
                Expressions.Add("jaw drop", exp.JawDrop);
                Expressions.Add("lid tighten", exp.LidTighten);
                Expressions.Add("lip corner depressor", exp.LipCornerDepressor);
                Expressions.Add("lip press", exp.LipPress);
                Expressions.Add("lip pucker", exp.LipPucker);
                Expressions.Add("lip stretch", exp.LipStretch);
                Expressions.Add("lip suck", exp.LipSuck);
                Expressions.Add("mouth open", exp.MouthOpen);
                Expressions.Add("nose wrinkle", exp.NoseWrinkle);
                Expressions.Add("smile", exp.Smile);
                Expressions.Add("smirk", exp.Smirk);
                Expressions.Add("upper lip raise", exp.UpperLipRaise);
            }
        }

        private void AddEmojis(Dictionary<int, Face> faces)
        {
            foreach (KeyValuePair<int, Face> face in faces)
            {
                Emojis em = face.Value.Emojis;
                Emojis.Add("disappointed", em.disappointed);
                Emojis.Add("flushed", em.flushed);
                Emojis.Add("kissing", em.kissing);
                Emojis.Add("laughing", em.laughing);
                Emojis.Add("rage", em.rage);
                Emojis.Add("relaxed", em.relaxed);
                Emojis.Add("scream", em.scream);
                Emojis.Add("smiley", em.smiley);
                Emojis.Add("smirk", em.smirk);
                Emojis.Add("stuck out tongue", em.stuckOutTongue);
                Emojis.Add("stuck out tongue winking eye", em.stuckOutTongueWinkingEye);
                Emojis.Add("wink", em.wink);
            }
        }
    }
}
