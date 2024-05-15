using Physics_Window_Manager.WindowManagement.Physics;

namespace Physics_Window_Manager.WindowManagement
{
	internal class ProcessThread
	{
		public static void Process(ProcessData data)
		{
			data.Velocity = (1, 1);
			try
			{
				_ = data.DataProcess.HasExited;
			}
			catch
			{
				return;
			}
			while (!data.DataProcess.HasExited)
			{
				//Console.WriteLine($"{data.DataProcess.ProcessName} ({data.WindowWidth}, {data.WindowHeight}):{data.WindowPos}");
				//data.Velocity.y += 1;

				ProcessData.RECT borders = new()
				{
					Left = 8,
					Top = 0,
					Right = 8,
					Bottom = 8
				};

				if (data.StateOfWindow != ProcessData.WindowState.Maximized)
				{
					Calculate.CalculateWindowPosition(data.WindowPos, data.Velocity, out (int x, int y) windowPos);
					Calculate.CalculateCollisions(windowPos, data.Velocity, data.WindowDims, data.ScreenDims, borders, 1, out windowPos, out data.Velocity);
					MoveWindow.SetWindowPosition(data.DataProcess, windowPos);
				}
				Thread.Sleep(1);
			}
		}
	}
}
