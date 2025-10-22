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

    public static IntPtr ToRawArrayPtr(this char[] arr)
    {
        IntPtr arrPtr = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * arr.Length);
        UInt32[] uintArr = Array.ConvertAll(arr, c => Convert.ToUInt32(c));
        byte[] byteArr = uintArr.ToByteArray();
        Marshal.Copy(uintArr.ToByteArray(), 0, arrPtr, byteArr.Length);
        return arrPtr;
    }

    private static byte[] ToByteArray(this UInt32[] arr)
    {
        byte[] byteArr = new byte[arr.Length * sizeof(UInt32)];
        Buffer.BlockCopy(arr, 0, byteArr, 0, byteArr.Length);
        return byteArr;
    }
}

