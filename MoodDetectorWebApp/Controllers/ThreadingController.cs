using System;
using System.Threading;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class ThreadingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WithThreading()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int a = 3;
            int b = 15;
            string str = "string";
            Thread thread1 = new Thread(() => SwapingTakesTime<int>(ref a, ref b));
            Thread thread2 = new Thread(delegate() { ChangingStringTakesTime(ref str); });
            thread1.Start();
            thread2.Start();
            while (thread1.IsAlive || thread2.IsAlive) { }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return View("Results", new { elapsedMs });
        }

        public ActionResult WithoutThreading()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int a = 3;
            int b = 15;
            string str = "string";
            SwapingTakesTime<int>(ref a, ref b);
            ChangingStringTakesTime(ref str);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return View("Results", new { elapsedMs });
        }

        private void SwapingTakesTime<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
            Thread.Sleep(3000);
        }

        private void ChangingStringTakesTime(ref string str)
        {
            Thread.Sleep(3000);
            str = str.Insert(0, "blah_");
        }
    }
}