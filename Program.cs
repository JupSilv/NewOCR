using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

namespace ConsoleOCR
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
          

            string iconPath = @"C:\Users\mt12313\Desktop\Teste_OCR\google.png";
            Click(@"C:\Users\mt12313\Desktop\Teste_OCR\outlook.png");
            Thread.Sleep(1000);
            Click(@"C:\Users\mt12313\Desktop\Teste_OCR\google.png");
            Thread.Sleep(1000);
            Click(@"C:\Users\mt12313\Desktop\Teste_OCR\blocoNotas.png");
            Thread.Sleep(1000);
            SendKeysGeneric("Teste sendKeys");
            Thread.Sleep(1000);

        }
        static bool IsProcessOpen(string name)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        static void SendKeysGeneric(string keys)
        {
            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.TextEntry(keys);
            // Enviar a tecla Enter
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        public static void Click(string iconPath)
        {
            APILauncher launcher = new APILauncher(true);
            launcher.Start();
            Pattern image = new Pattern(iconPath);
            Screen scr = new Screen();
            scr.Click(image);
            launcher.Stop();
        }
    }
}
