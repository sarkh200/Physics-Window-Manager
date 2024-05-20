using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Physics_Window_Manager.WindowManagement
{

	internal partial class ProcessData
	{
		required public Process DataProcess { get; set; }

		public (int x, int y) Velocity = (0, 0);

		public Screen MainScreen => Screen.FromHandle(DataProcess.MainWindowHandle);

		public (int width, int height) ScreenDims => (MainScreen.WorkingArea.Width, MainScreen.WorkingArea.Height);

		public (int widht, int height) WindowDims => (WindowRect.Right - WindowRect.Left, WindowRect.Bottom - WindowRect.Top);

		public (int x, int y) WindowPos
		{
			get
			{
				GetWindowRect(DataProcess.MainWindowHandle, out RECT windowRect);
				return (windowRect.Left, windowRect.Top);
			}
		}

		public bool IsFocussed { 
			get
			{
				return GetForegroundWindow() == DataProcess.MainWindowHandle;
			} 
		}

		public RECT WindowRect
		{
			get
			{
				GetWindowRect(DataProcess.MainWindowHandle, out RECT windowRect);
				return windowRect;
			}
		}

		public WindowState StateOfWindow
		{
			get
			{
				var placement = GetPlacement(DataProcess.MainWindowHandle);
				return placement.showCmd.ToString() switch
				{
					"Normal" => WindowState.Normal,
					"Maximized" => WindowState.Maximized,
					"Minimized" => WindowState.Maximized,
					_ => WindowState.Normal,
				};
			}
		}

		private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
		{
			WINDOWPLACEMENT placement = new();
			placement.length = Marshal.SizeOf(placement);
			GetWindowPlacement(hwnd, ref placement);
			return placement;
		}
	}
}
