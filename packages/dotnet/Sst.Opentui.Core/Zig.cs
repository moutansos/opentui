using System.Runtime.InteropServices;

namespace Sst.Opentui.Core;

//TODO: Make this insternal after testing
public unsafe static partial class Zig
{
    public const string LIB_NAME = "opentui";

    [LibraryImport(LIB_NAME, EntryPoint = "createRenderer")]
    public static partial IntPtr CreateRenderer(UInt32 width, UInt32 height);

    [LibraryImport(LIB_NAME, EntryPoint = "destroyRenderer")]
    public static partial void DestroyRenderer(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool useAlternateScreen, UInt32 splitHeight);

    [LibraryImport(LIB_NAME, EntryPoint = "setUseThread")]
    public static partial void SetUseThread(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool useThread);

    [LibraryImport(LIB_NAME, EntryPoint = "setBackgroundColor")]
    public static partial void SetBackgroundColor(IntPtr renderer, IntPtr color);

    [LibraryImport(LIB_NAME, EntryPoint = "setRenderOffset")]
    public static partial void SetRenderOffset(IntPtr renderer, UInt32 offset);

    [LibraryImport(LIB_NAME, EntryPoint = "updateStats")]
    public static partial void UpdateStats(IntPtr renderer, double time, UInt32 fps, double frameCallbackTime);

    [LibraryImport(LIB_NAME, EntryPoint = "updateMemoryStats")]
    public static partial void UpdateMemoryStats(IntPtr renderer, UInt32 heapUsed, UInt32 heapTotal, UInt32 arrayBuffers);

    [LibraryImport(LIB_NAME, EntryPoint = "render")]
    public static partial void Render(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool force);

    [LibraryImport(LIB_NAME, EntryPoint = "getNextBuffer")]
    public static partial IntPtr GetNextBuffer(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "getCurrentBuffer")]
    public static partial IntPtr GetCurrentBuffer(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "createOptimizedBuffer")]
    public static partial IntPtr CreateOptimizedBuffer(UInt32 width, UInt32 height, [MarshalAs(UnmanagedType.I1)] bool respectAlpha, UInt16 widthMethod);

    [LibraryImport(LIB_NAME, EntryPoint = "destroyOptimizedBuffer")]
    public static partial void DestroyOptimizedBuffer(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "drawFrameBuffer")]
    public static partial void DrawFrameBuffer(IntPtr target, Int32 destX, Int32 destY, IntPtr frameBuffer, UInt32 sourceX, UInt32 sourceY, UInt32 sourceWidth, UInt32 sourceHeight);

    [LibraryImport(LIB_NAME, EntryPoint = "getBufferWidth")]
    public static partial UInt32 GetBufferWidth(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "getBufferHeight")]
    public static partial UInt32 GetBufferHeight(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferClear")]
    public static partial void BufferClear(IntPtr buffer, IntPtr bg);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferGetCharPtr")]
    public static partial IntPtr BufferGetCharPtr(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferGetFgPtr")]
    public static partial IntPtr BufferGetFgPtr(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferGetBgPtr")]
    public static partial IntPtr BufferGetBgPtr(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferGetAttributesPtr")]
    public static partial IntPtr BufferGetAttributesPtr(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferGetRespectAlpha")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool BufferGetRespectAlpha(IntPtr buffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferSetRespectAlpha")]
    public static partial void BufferSetRespectAlpha(IntPtr buffer, [MarshalAs(UnmanagedType.I1)] bool respectAlpha);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferDrawText")]
    public static partial void BufferDrawText(IntPtr buffer, IntPtr text, Int64 textLen, UInt32 x, UInt32 y, IntPtr fg, IntPtr bg, byte attributes);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferSetCellWithAlphaBlending")]
    public static partial void BufferSetCellWithAlphaBlending(IntPtr buffer, UInt32 x, UInt32 y, UInt32 char_code, IntPtr fg, IntPtr bg, byte attributes);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferFillRect")]
    public static partial void BufferFillRect(IntPtr buffer, UInt32 x, UInt32 y, UInt32 width, UInt32 height, IntPtr bg);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferResize" )]
    public static partial void BufferResize(IntPtr buffer, UInt32 newWidth, UInt32 newHeight);

    [LibraryImport(LIB_NAME, EntryPoint = "resizeRenderer")]
    public static partial void ResizeRenderer(IntPtr renderer, UInt32 newWidth, UInt32 newHeight);

    [LibraryImport(LIB_NAME, EntryPoint = "setCursorPosition")]
    public static partial void SetCursorPosition(IntPtr renderer, UInt32 x, UInt32 y, [MarshalAs(UnmanagedType.I1)] bool visible);

    [LibraryImport(LIB_NAME, EntryPoint = "setCursorStyle")]
    public static partial void SetCursorStyle(IntPtr renderer, IntPtr style, Int64 styleLen, [MarshalAs(UnmanagedType.I1)] bool blinking);

    [LibraryImport(LIB_NAME, EntryPoint = "setCursorColor")]
    public static partial void SetCursorColor(IntPtr renderer, IntPtr color);

    [LibraryImport(LIB_NAME, EntryPoint = "setDebugOverlay")]
    public static partial void SetDebugOverlay(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool enabled, byte corner);

    [LibraryImport(LIB_NAME, EntryPoint = "clearTerminal")]
    public static partial void ClearTerminal(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferDrawSuperSampleBuffer")]
    public static partial void BufferDrawSuperSampleBuffer(IntPtr buffer, UInt32 x, UInt32 y, IntPtr pixelData, UInt64 len, byte format, UInt32 alignedBytesPerRow);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferDrawPackedBuffer")]
    public static partial void BufferDrawPackedBuffer(IntPtr buffer, IntPtr data, UInt64 dataLen, UInt32 posX, UInt32 posY, UInt32 terminalWidthCells, UInt32 terminalHeightCells);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferDrawBox")]
    public static partial void BufferDrawBox(IntPtr buffer, Int32 x, Int32 y, UInt32 width, UInt32 height, IntPtr borderChars, UInt32 packedOptions, IntPtr borderColor, IntPtr backgroundColor, IntPtr title, UInt32 titleLen);

    [LibraryImport(LIB_NAME, EntryPoint = "addToHitGrid")]
    public static partial void AddToHitGrid(IntPtr renderer, Int32 x, Int32 y, UInt32 width, UInt32 height, UInt32 id);

    [LibraryImport(LIB_NAME, EntryPoint = "checkHit")]
    public static partial UInt32 CheckHit(IntPtr renderer, UInt32 x, UInt32 y);

    [LibraryImport(LIB_NAME, EntryPoint = "dumpHitGrid")]
    public static partial void DumpHitGrid(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "dumpBuffers")]
    public static partial void DumpBuffers(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "dumpStdoutBuffer")]
    public static partial void DumpStdoutBuffer(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "enableMouse")]
    public static partial void EnableMouse(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool enabled);

    [LibraryImport(LIB_NAME, EntryPoint = "disableMouse")]
    public static partial void DisableMouse(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "enableKittyKeyboard")]
    public static partial void EnableKittyKeyboard(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool enabled);

    [LibraryImport(LIB_NAME, EntryPoint = "disableKittyKeyboard")]
    public static partial void DisableKittyKeyboard(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "setupTerminal" )]
    public static partial void SetupTerminal(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool useAlternateScreen);

    [LibraryImport(LIB_NAME, EntryPoint = "createTextBuffer")]
    public static partial IntPtr CreateTextBuffer(UInt32 length, byte widthMethod);

    [LibraryImport(LIB_NAME, EntryPoint = "destroyTextBuffer")]
    public static partial void DestroyTextBuffer(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetCharPtr")]
    public static partial IntPtr TextBufferGetCharPtr(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetFgPtr")]
    public static partial IntPtr TextBufferGetFgPtr(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetBgPtr")]
    public static partial IntPtr TextBufferGetBgPtr(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetAttributesPtr")]
    public static partial IntPtr TextBufferGetAttributesPtr(IntPtr textBuffer);
}
