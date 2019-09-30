using Affdex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Controller.Affectiva
{
    class AffectivaService
    {
        public Dictionary<string, float> GetEmotions(string filePath)
        {
            Dictionary<string, float> emotions = new Dictionary<string, float>;

            PhotoDetector detector = new PhotoDetector(2, FaceDetectorMode.LARGE_FACES);
            String classifierPath = "C:\\Program Files\\Affectiva\\AffdexSDK\\data";
            detector.setClassifierPath(classifierPath);
            ImageListenerImpl imageListener = new ImageListenerImpl(detector);
            detector.setDetectAllExpressions(true);
            detector.setDetectAllEmotions(true);
            detector.setDetectAllEmojis(true);
            detector.setDetectAllAppearances(true);

            Frame frame = LoadFrameFromFile(filePath);
            detector.start();
            detector.process(frame);
            emotions = imageListener.GetEmotions();
            detector.stop();
            return emotions;
        }

        private Frame LoadFrameFromFile(string filePath)
        {
            Bitmap bitmap = new Bitmap(filePath);

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            int numBytes = bitmap.Width * bitmap.Height * 3;
            byte[] rgbValues = new byte[numBytes];

            int data_x = 0;
            int ptr_x = 0;
            int row_bytes = bitmap.Width * 3;      //3 bytes per pixel

            // The bitmap requires bitmap data to be byte aligned.
            for (int y = 0; y < bitmap.Height; y++)
            {
                Marshal.Copy(ptr + ptr_x, rgbValues, data_x, row_bytes);//(pixels, data_x, ptr + ptr_x, row_bytes);
                data_x += row_bytes;
                ptr_x += bmpData.Stride;
            }

            bitmap.UnlockBits(bmpData);

            return new Affdex.Frame(bitmap.Width, bitmap.Height, rgbValues, Affdex.Frame.COLOR_FORMAT.BGR);
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
