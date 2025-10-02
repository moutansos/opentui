using System.Runtime.InteropServices;

namespace Sst.Opentui.Core;

internal static class Utils
{
    public static IntPtr ToRawArrayPtr(this Rgba color)
    {
        float[] rawArray = color.ToRawArray();
        IntPtr colorPtr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * rawArray.Length);
        Marshal.Copy(rawArray, 0, colorPtr, rawArray.Length);
        return colorPtr;
    }
}

