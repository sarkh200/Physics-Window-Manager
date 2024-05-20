using Physics_Window_Manager.WindowManagement.Physics;

namespace Physics_Window_Manager.WindowManagement
{
	internal class ProcessThread
	{
		public static void Process(ProcessData data)
		{
			int [] velocityOptions = [-1, 1];
			Random random = new();
			data.Velocity = (velocityOptions [random.Next(velocityOptions.Length)], velocityOptions [random.Next(velocityOptions.Length)]);

			try
			{
				_ = data.DataProcess.HasExited;
			}
			catch
			{
				return;
			}

			ProcessData.RECT borders = new()
			{
				Left = 8,
				Top = 0,
				Right = 8,
				Bottom = 8
			};
			
			while (!data.DataProcess.HasExited)
			{
				if (data.StateOfWindow != ProcessData.WindowState.Maximized)
				{
					if (!(Calculate.IsPointWithinRect(Cursor.Position, data.WindowRect) && (Control.MouseButtons & MouseButtons.Left) != 0))
					{
						Calculate.CalculateWindowPosition(data.WindowPos, data.Velocity, out (int x, int y) windowPos);
						Calculate.CalculateCollisions(windowPos, data.Velocity, data.WindowDims, data.ScreenDims, borders, 1, out windowPos, out data.Velocity);
						MoveWindow.SetWindowPosition(data.DataProcess, windowPos);
					}
				}
				Thread.Sleep(10);
			}
		}
	}
}
