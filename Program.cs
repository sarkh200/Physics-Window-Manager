using Physics_Window_Manager.WindowManagement;
using System.Diagnostics;
using System.Windows.Automation;

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

			Automation.AddAutomationEventHandler(
						eventId: WindowPattern.WindowOpenedEvent,
						element: AutomationElement.RootElement,
						scope: TreeScope.Children,
						eventHandler: WindowOpened);

			ProcessDataManager.SetUpProcessDataArray(out ProcessData [] graphicalProcessData);
			foreach (ProcessData data in graphicalProcessData)
			{
				Thread t = new(() => WindowManagement.ProcessThread.Process(data));
				t.Start();
			}
			while (true)
			{
				Thread.Sleep(1000);
			}

			void WindowOpened(object sender, AutomationEventArgs automationEventArgs)
			{
				var element = sender as AutomationElement;
				if (element != null)
				{
					Process p = Process.GetProcessById(element.Current.ProcessId);
					ProcessData data = new() { DataProcess = p };
					Thread t = new(() => WindowManagement.ProcessThread.Process(data));
					t.Start();
				}
			}
		}
	}
}