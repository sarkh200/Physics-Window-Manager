using System.Runtime.InteropServices;

namespace Physics_Window_Manager.WindowManagement
{
	internal partial class ProcessData
	{
		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hwnd, out RECT rectangle);

		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
	}
}