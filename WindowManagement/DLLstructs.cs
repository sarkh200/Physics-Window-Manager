﻿namespace Physics_Window_Manager.WindowManagement
{

	internal partial class ProcessData
	{
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		public enum DWMWINDOWATTRIBUTE
		{
			DWMWA_NCRENDERING_ENABLED,
			DWMWA_NCRENDERING_POLICY,
			DWMWA_TRANSITIONS_FORCEDISABLED,
			DWMWA_ALLOW_NCPAINT,
			DWMWA_CAPTION_BUTTON_BOUNDS,
			DWMWA_NONCLIENT_RTL_LAYOUT,
			DWMWA_FORCE_ICONIC_REPRESENTATION,
			DWMWA_FLIP3D_POLICY,
			DWMWA_EXTENDED_FRAME_BOUNDS,
			DWMWA_HAS_ICONIC_BITMAP,
			DWMWA_DISALLOW_PEEK,
			DWMWA_EXCLUDED_FROM_PEEK,
			DWMWA_CLOAK,
			DWMWA_CLOAKED,
			DWMWA_FREEZE_REPRESENTATION,
			DWMWA_PASSIVE_UPDATE_MODE,
			DWMWA_USE_HOSTBACKDROPBRUSH,
			DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
			DWMWA_WINDOW_CORNER_PREFERENCE = 33,
			DWMWA_BORDER_COLOR,
			DWMWA_CAPTION_COLOR,
			DWMWA_TEXT_COLOR,
			DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
			DWMWA_SYSTEMBACKDROP_TYPE,
			DWMWA_LAST
		};
		public struct MONITORINFO
		{
			public uint cbSize;
			public RECT rcMonitor;
			public RECT rcWork;
			public uint dwFlags;
		}
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
		internal enum WindowState: int
		{
			Normal = 0,
			Maximized = 1,
			Minimized = 2,
		}
	}
}
