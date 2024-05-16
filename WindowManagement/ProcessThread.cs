using Physics_Window_Manager.WindowManagement.Physics;

namespace Physics_Window_Manager.WindowManagement
{
	internal class ProcessThread
	{
		public static void Process(ProcessData data)
		{
			bool isGrounded = false;
			int [] velocityOptions = [-10, 10];
			Random random = new();
			data.Velocity = (0/*velocityOptions [random.Next(velocityOptions.Length)]*/, velocityOptions [random.Next(velocityOptions.Length)]);
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
					Calculate.CalculateCollisions(windowPos, data.Velocity, data.WindowDims, data.ScreenDims, borders, 3, out windowPos, out data.Velocity, out isGrounded);
					MoveWindow.SetWindowPosition(data.DataProcess, windowPos);
				}
				if (!isGrounded) data.Velocity.y += 1;
				Thread.Sleep(1);
			}
		}
	}
}
