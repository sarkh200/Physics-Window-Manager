using Physics_Window_Manager.Window;

namespace Physics_Window_Manager.Main
{
	class MainWindow
	{
		static void Main(string [] args)
		{
			if (args.Length > 0 && args [0] == "--kill")
			{
				KillAll.Kill();
				Environment.Exit(0);
			}

			List<Thread> threads = [];
			List<int> oldProcessData = [];
			for (int i = 0; i < 1000; i++)
			{
				ProcessDataManager.SetUpProcessDataArray(out ProcessData [] graphicalProcessData);
				foreach (ProcessData data in graphicalProcessData)
				{
					//Console.WriteLine(data.DataProcess.ProcessName);
					if (!oldProcessData.Contains(data.DataProcess.Id) && data.DataProcess.ProcessName == "WindowsTerminal")
					{
						Thread t = new(() => ProcessThread.Process(data));
						t.Start();
						threads.Add(t);
					}
				}
				oldProcessData = [];
				foreach (ProcessData data in graphicalProcessData)
				{
					oldProcessData.Add(data.DataProcess.Id);
				}
				Thread.Sleep(300);
			}
		}
	}
}