using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace Physics_Window_Manager.Window
{

	internal partial class ProcessData
	{
		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hwnd, out RECT rectangle);

		//[DllImport("dwmapi.dll")]
		//public static extern int DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out RECT pvAttribute, int cbAttribute);
		//[DllImport("user32.dll")]
		//private static extern int MonitorFromWindow(IntPtr hWnd, uint nIndex);
		//const uint MONITOR_DEFAULTTONULL = 0x00000000;
		//const uint MONITOR_DEFAULTTOPRIMARY = 0x00000001;
		//const uint MONITOR_DEFAULTTONEAREST = 0x00000002;
		//[DllImport("user32.dll")]
		//private static extern bool GetMonitorInfoA(IntPtr hMonitor, out MONITORINFO info);

		required public Process DataProcess { get; set; } = new();

		//GetMonitorInfoA(MonitorFromWindow(process.MainWindowHandle, MONITOR_DEFAULTTOPRIMARY), out MONITORINFO info);
		public static (int width, int height) ScreenDims => ((int) SystemParameters.WorkArea.Width, (int) SystemParameters.WorkArea.Height);

		public (int widht, int height) WindowDims => (WindowRect.Right - WindowRect.Left, WindowRect.Bottom - WindowRect.Top);

		public (int x, int y) WindowPos
		{
			get
			{
				GetWindowRect(DataProcess.MainWindowHandle, out RECT windowRect);
				return (windowRect.Left, windowRect.Top);
			}
		}

		public (int x, int y) Velocity = (1, 1);//TEMP

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

		internal enum WindowState: int
		{
			Normal = 0,
			Maximized = 1,
			Minimized = 2,
		}

		private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
		{
			WINDOWPLACEMENT placement = new();
			placement.length = Marshal.SizeOf(placement);
			GetWindowPlacement(hwnd, ref placement);
			return placement;
		}

		[DllImport("user32.dll")]
		internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

		internal struct WINDOWPLACEMENT
		{
			public int length;
			public int flags;
			public ShowWindowCommands showCmd;
			public System.Drawing.Point ptMinPosition;
			public System.Drawing.Point ptMaxPosition;
			public System.Drawing.Rectangle rcNormalPosition;
		}

		internal enum ShowWindowCommands: int
		{
			Hide = 0,
			Normal = 1,
			Minimized = 2,
			Maximized = 3,
		}
	}
}
