using System;
using static System.Console;

namespace WeakEventPattern
{
    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            //WeakEventManager<Button, EventArgs>
            //    .AddHanddle(button, "Clicked", ButtonOnClicked); //Only .Net Framework not .Net Core
                button.Clicked += ButtonOnClicked;
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            WriteLine("Button clicked (Window handler)");
        }

        ~Window()
        {
            WriteLine("Window finalized");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var button = new Button();
            var window = new Window(button);
            var windowRef = new WeakReference(window);
            button.Fire();

            WriteLine("Setting window to null");
            window = null;

            FireGC();
            WriteLine($"Is the window alive after GC? {windowRef.IsAlive}");

            ReadKey();
        }

        private static void FireGC()
        {
            WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            WriteLine("GC is Done");

        }
    }
}
