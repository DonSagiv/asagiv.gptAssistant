using OpenSilver.Simulator;
using System;

namespace asagiv.UI.gptAssistant.OpenSilver.Simulator
{
    internal static class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            return SimulatorLauncher.Start(typeof(App));
        }
    }
}
