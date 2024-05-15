using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Physics_Window_Manager.Window
{
	internal class MoveWindow
	{
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		const uint SWP_NOSIZE = 0x0001;
		const uint SWP_NOZORDER = 0x0004;


		public static void SetWindowPosition(Process process, (int x, int y) position)
		{
			SetWindowPos(process.MainWindowHandle, IntPtr.Zero, position.x, position.y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
		}
	}
}
