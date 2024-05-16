using System.Diagnostics;

namespace Physics_Window_Manager.WindowManagement
{
	internal class KillAll
	{
		public static void Kill()
		{
			foreach (Process p in Process.GetProcesses())
			{
				if (p.ProcessName == "gravify")
				{
					p.Kill();
				}
			}
		}
	}
}
