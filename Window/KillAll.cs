﻿using System.Diagnostics;

namespace Physics_Window_Manager.Window
{
    internal class KillAll
    {
        public static void Kill()
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == "dvdify")
                {
                    p.Kill();
                }
            }
        }
    }
}
