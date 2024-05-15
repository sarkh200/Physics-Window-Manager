using System.Diagnostics;

namespace Physics_Window_Manager.Window
{
	internal class ProcessDataManager
	{
		public static void SetUpProcessDataArray(out ProcessData [] processData)
		{
			Process [] graphicalProcesses = FindWindows.GetGraphicalProcesses();
			processData = new ProcessData [graphicalProcesses.Length];
			{
				List<ProcessData> graphicalProcessDataList = [];
				foreach (Process process in graphicalProcesses)
				{
					graphicalProcessDataList.Add(new() { DataProcess = process });
				}
				processData = graphicalProcessDataList.ToArray();
			}
		}
	}
}
