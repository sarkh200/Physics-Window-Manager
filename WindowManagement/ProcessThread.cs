using Physics_Window_Manager.WindowManagement.Physics;

namespace Physics_Window_Manager.WindowManagement
{
	internal class ProcessThread
	{
		public static void Process(ProcessData data)
		{
			(int x, int y) point = (int.MinValue, int.MinValue);
			DateTime clickStart = DateTime.MinValue;
			int [] velocityOptions = [-10, 10];
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
						if (point.x != int.MinValue && point.y != int.MinValue)
						{
							point = (data.WindowPos.x - point.x, data.WindowPos.y - point.y);
							Calculate.CalculateVelocity(point, Convert.ToInt32(DateTime.Now.Subtract(clickStart).TotalMilliseconds), out data.Velocity);
							point = (int.MinValue, int.MinValue);
							clickStart = DateTime.MinValue;
						}
						Calculate.CalculateWindowPosition(data.WindowPos, data.Velocity, out (int x, int y) windowPos);
						Calculate.CalculateCollisions(windowPos, data.Velocity, data.WindowDims, data.ScreenDims, borders, 3, out windowPos, out data.Velocity, out bool isGrounded);
						MoveWindow.SetWindowPosition(data.DataProcess, windowPos);
						if (!isGrounded)
						{
							data.Velocity.y += 1;
						}
						else
						{
							if (data.Velocity.x > 0)
							{
								data.Velocity.x -= 1;
							}
							else if (data.Velocity.x < 0)
							{
								data.Velocity.x += 1;
							}
						}
					}
					else if (point.x == int.MinValue && point.y == int.MinValue)
					{
						point.x = data.WindowPos.x;
						point.y = data.WindowPos.y;
						clickStart = DateTime.Now;
					}
				}
				Thread.Sleep(1);
			}
		}
	}
}
