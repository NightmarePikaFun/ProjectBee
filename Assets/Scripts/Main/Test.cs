using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR;
using Debug = UnityEngine.Debug;

public class Test : MonoBehaviour
{
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT { public int left, top, right, bottom; }

    [StructLayout(LayoutKind.Sequential)]
    private struct MARGINS { public int cxLeftWidth, cxRightWidth, cyTopHeight, cyBottomHeight; }

    private const int GWL_STYLE = -16;
    private const int GWL_EXSTYLE = -20;

    private const uint WS_OVERLAPPEDWINDOW = 0x00CF0000;
    private const uint WS_POPUP = 0x80000000;
    private const uint WS_VISIBLE = 0x10000000;
    private const uint WS_EX_LAYERED = 0x00080000;

    private const uint SPI_GETWORKAREA = 0x0030;
    private const int SWP_FRAMECHANGED = 0x0020;
    private const int SWP_NOZORDER = 0x0004;
    private const int SWP_NOACTIVATE = 0x0010;

    const uint WS_EX_TRANSPARENT = 0x00000020;
    private const uint WS_EX_TOOLWINDOW = 0x00000080;

    private const int SW_SHOW = 5;
    private const uint LWA_ALPHA = 0x2;

    const uint LWA_COLORKEY = 0x00000001;

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, out RECT pvParam, uint fWinIni);

    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    private static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
    private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("dwmapi.dll")]
    private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);

    private static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
    {
        return IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : new IntPtr(GetWindowLong32(hWnd, nIndex));
    }

    private static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
    {
        return IntPtr.Size == 8 ? SetWindowLongPtr64(hWnd, nIndex, dwNewLong) : new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
    }

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    void Start()
    {
        IntPtr hwnd = GetActiveWindow();
        if (hwnd == IntPtr.Zero)
        {
            Debug.LogError("❌ Failed to get Unity window handle.");
            return;
        }

        // Get usable screen area (without taskbar)
        SystemParametersInfo(SPI_GETWORKAREA, 0, out RECT workArea, 0);
        int width = workArea.right - workArea.left;
        int height = workArea.bottom - workArea.top;

        // Get current style
        IntPtr stylePtr = GetWindowLongPtr(hwnd, GWL_STYLE);
        long style = stylePtr.ToInt64();

        // Apply popup + visible (borderless)
        style = (long)( WS_VISIBLE);//WS_POPUP |
        SetWindowLongPtr(hwnd, GWL_STYLE, new IntPtr(style));

        // Add layered extended style (for transparency)
        IntPtr exStylePtr = GetWindowLongPtr(hwnd, GWL_EXSTYLE);
        long exStyle = WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOOLWINDOW;//exStylePtr.ToInt64() | WS_EX_LAYERED;
        SetWindowLongPtr(hwnd, GWL_EXSTYLE, new IntPtr(WS_EX_LAYERED));// | WS_EX_TRANSPARENT));

        // Resize window to work area (without taskbar)
        SetWindowPos(hwnd, HWND_TOPMOST, workArea.left, workArea.top, width, height, 0);

        // Force redraw
        ShowWindow(hwnd, SW_SHOW);

        // Enable DWM transparency
        MARGINS margins = new MARGINS { cxLeftWidth = -1 };
        DwmExtendFrameIntoClientArea(hwnd, ref margins);
        //SetLayeredWindowAttributes(hwnd, 0, 255, LWA_ALPHA);
        SetLayeredWindowAttributes(hwnd, 0, 0, LWA_COLORKEY);
    }
}
