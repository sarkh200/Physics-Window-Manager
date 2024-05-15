using System.Diagnostics;

namespace Physics_Window_Manager.WindowManagement
{
	internal class FindWindows
	{
		public static Process [] GetGraphicalProcesses()
		{
			Process [] openProcesses = Process.GetProcesses();
			List<Process> graphicalProcesses = [];
			foreach (Process openProcess in openProcesses)
			{
				if (openProcess.MainWindowHandle != IntPtr.Zero)
				{
					graphicalProcesses.Add(openProcess);
				}
			}
			return graphicalProcesses.ToArray();
		}
	}
}
