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
    public static partial void EnableMouse(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool enableMovement);

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

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetLength")]
    public static partial UInt32 TextBufferGetLength(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferSetCell")]
    public static partial void TextBufferSetCell(IntPtr textBuffer, UInt32 index, UInt32 char_code, IntPtr fg, IntPtr bg, UInt16 attr);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferConcat")]
    public static partial IntPtr TextBufferConcat(IntPtr tb1, IntPtr tb2);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferResize")]
    public static partial void TextBufferResize(IntPtr textBuffer, UInt32 newLength);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferReset")]
    public static partial void TextBufferReset(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferSetSelection")]
    public static partial void TextBufferSetSelection(IntPtr textBuffer, UInt32 start, UInt32 end, IntPtr bgColor, IntPtr fgColor);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferResetSelection")]
    public static partial void TextBufferResetSelection(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferSetDefaultFg")]
    public static partial void TextBufferSetDefaultFg(IntPtr textBuffer, IntPtr fg);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferSetDefaultBg")]
    public static partial void TextBufferSetDefaultBg(IntPtr textBuffer, IntPtr bg);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferSetDefaultAttributes")]
    public static partial void TextBufferSetDefaultAttributes(IntPtr textBuffer, byte attr);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferResetDefaults")]
    public static partial void TextBufferResetDefaults(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferWriteChunk")]
    public static partial UInt32 TextBufferWriteChunk(IntPtr textBuffer, IntPtr textBytes, UInt32 textLen, IntPtr fg, IntPtr bg, byte attr);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetCapacity")]
    public static partial UInt32 TextBufferGetCapacityb(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferFinalizeLineInfo")]
    public static partial void TextBufferFinalizeLineInfo(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetLineStartsPtr")]
    public static partial IntPtr TextBufferGetLineStartsPtr(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetLineWidthsPtr")]
    public static partial IntPtr TextBufferGetLineWidthsPtr(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "textBufferGetLineCount")]
    public static partial UInt32 TextBufferGetLineCount(IntPtr textBuffer);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferDrawTextBuffer")]
    public static partial void BufferDrawTextBuffer(IntPtr buffer, IntPtr textBuffer, Int32 x, Int32 y, Int32 clipX, Int32 clipY, UInt32 clipWidth, UInt32 clipHeight, [MarshalAs(UnmanagedType.I1)] bool hasClipRect);

    [LibraryImport(LIB_NAME, EntryPoint = "getTerminalCapabilities")]
    public static partial void GetTerminalCapabilities(IntPtr renderer, IntPtr caps);

    [LibraryImport(LIB_NAME, EntryPoint = "getTerminalType")]
    public static partial IntPtr GetTerminalType(IntPtr renderer, IntPtr response, UInt64 responseLen);
}

public record TextBufferArrays(UInt32[] character, float[] fg, float[] bg, byte[] attributes);
public record ClipRect(int x, int y, int width, int height);

public interface IRenderLib
{
    public IntPtr CreateRenderer(int width, int height);
    public void DestroyRenderer(IntPtr renderer, bool useAlternateScreen, int splitHeight);
    public void SetUseThread(IntPtr renderer, bool useThread);
    public void SetBackgroundColor(IntPtr renderer, Rgba color);
    public void SetRenderOffset(IntPtr renderer, int offset);
    public void UpdateStats(IntPtr renderer, int time, int fps, int frameCallbackTime);
    public void UpdateMemoryStats(IntPtr renderer, int heapUsed, int heapTotal, int arrayBuffers);
    public void Render(IntPtr renderer, bool force);
    public OptomizedBuffer GenNextBuffer(IntPtr renderer);
    public OptomizedBuffer GetCurrentBuffer(IntPtr renderer);
    public OptomizedBuffer CreateOptimizedBuffer(int width, int height, WidthMethod widthMethod, bool respectAlpha = false);
    public void DestroyOptimizedBuffer(IntPtr buffer);
    public void DrawFrameBuffer(IntPtr targetBufferPtr, int destX, int destY, IntPtr bufferPtr, int? sourceX, int? sourceY, int? sourceWidth, int? sourceHeight);
    public int GetBufferWidth(IntPtr buffer);
    public int GetBufferHeight(IntPtr buffer);
    public void BufferClear(IntPtr buffer, Rgba color);
    public IntPtr BufferGetCharPtr(IntPtr buffer);
    public IntPtr BufferGetFgPtr(IntPtr buffer);
    public IntPtr BufferGetBgPtr(IntPtr buffer);
    public IntPtr BufferGetAttributesPtr(IntPtr buffer);
    public bool BufferGetRespectAlpha(IntPtr buffer);
    public void BufferSetRespectAlpha(IntPtr buffer, bool respectAlpha);
    public void BufferDrawText(IntPtr buffer, string text, int x, int y, Rgba color, Rgba? bgColor, byte? attributes);
    public void BufferSetCellWithAlphaBlending(IntPtr buffer, int x, int y, char character , Rgba color, Rgba bgColor, byte attributes);
    public void BufferFillRect(IntPtr buffer, int x, int y, int width, int height, Rgba color);
    public void BufferDrawSuperSampleBuffer(IntPtr buffer, int x, int y, IntPtr pixelDataPtr, int pixelDataLenth, int alignedBytesPerRow);
    public void BufferDrawPackedBuffer(IntPtr buffer, IntPtr dataPtr, int dataLen, int posX, int posY, int terminalWidthCells, int terminalHeightCells);
    public void BufferDrawBox(IntPtr buffer, int x, int y, int width, int height, UInt32[] borderChars, byte packedOptions, Rgba borderColor, Rgba backgroundColor, string? title);
    public TextBufferArrays BufferResize(IntPtr buffer, int width, int height);
    public void ResizeRenderer(IntPtr renderer, int width, int height);
    public void SetCursorPosition(IntPtr renderer, int x, int y, bool visible);
    public void SetCursorStyle(IntPtr renderer, CursorStyle style, bool blinking);
    public void SetCursorColor(IntPtr renderer, Rgba color);
    public void SetDebugOverlay(IntPtr renderer, bool enabled, DebugOverlayCorner corner);
    public void ClearTerminal(IntPtr renderer);
    public void AddToHitGrid(IntPtr renderer, int x, int y, int width, int height, int id);
    public int CheckHit(IntPtr renderer, int x, int y);
    public void DumpHitGrid(IntPtr renderer);
    public void DumpBuffers(IntPtr renderer);
    public void DumpStdoutBuffer(IntPtr renderer);
    public void EnableMouse(IntPtr renderer, bool enableMovement);
    public void DisableMouse(IntPtr renderer);
    public void EnableKittyKeyboard(IntPtr renderer, byte flags);
    public void DisableKittyKeyboard(IntPtr renderer);
    public void SetupTerminal(IntPtr renderer, bool useAlternateScreen);

    //TextBuffer methods
    public TextBuffer CreateTextBuffer(int capacity, WidthMethod widthMethod);
    public void DestroyTextBuffer(IntPtr buffer);
    public IntPtr TextBufferGetCharPtr(IntPtr buffer);
    public IntPtr TextBufferGetFgPtr(IntPtr buffer);
    public IntPtr TextBufferGetBgPtr(IntPtr buffer);
    public IntPtr TextBufferGetAttributesPtr(IntPtr buffer);
    public int TextBufferGetLength(IntPtr buffer);
    public void TextBufferSetCell(IntPtr buffer, int index, char character, Rgba color, Rgba bgColor, byte attributes);
    public TextBuffer TextBufferConcat(IntPtr buffer1, IntPtr buffer2);
    public TextBufferArrays TextBufferResize(IntPtr buffer, int newLength); 
    public void TextBufferReset(IntPtr buffer);
    public void TextBufferSetSelection(IntPtr buffer, int start, int end, Rgba? bgColor, Rgba? fgColor);
    public void TextBufferResetSelection(IntPtr buffer);
    public void TextBufferSetDefaultFg(IntPtr buffer, Rgba? color);
    public void TextBufferSetDefaultBg(IntPtr buffer, Rgba? color);
    public void TextBufferSetDefaultAttributes(IntPtr buffer, byte? attributes);
    public void TextBufferResetDefaults(IntPtr buffer);
    public int TextBufferWriteChunk(IntPtr buffer, string text, Rgba? fg, Rgba? bg, byte? attributes);
    public int TextBufferGetCapacity(IntPtr buffer);
    public void TextBufferFinalizeLineInfo(IntPtr buffer);
    public IntPtr TextBufferGetLineInfo(IntPtr buffer);
    public TextBufferArrays GetTextBufferArrays(IntPtr buffer, int size);
    public void BufferDrawTextBuffer(IntPtr buffer, IntPtr textBuffer, int x, int y, ClipRect? clipRect);

    public dynamic GetTerminalCapabilities(IntPtr renderer);
    public void ProcessCapabilityRespponse(IntPtr renderer, string response);
}

public class FFIRenderLib : IRenderLib
{
    public FFIRenderLib() { }

    public IntPtr CreateRenderer(int width, int height) => Zig.CreateRenderer((UInt32)width, (UInt32)height);

    public void DestroyRenderer(IntPtr renderer, bool useAlternateScreen, int splitHeight) =>
      Zig.DestroyRenderer(renderer, useAlternateScreen, (UInt32)splitHeight);

    public void SetUseThread(IntPtr renderer, bool useThread) => Zig.SetUseThread(renderer, useThread);

    public void SetBackgroundColor(IntPtr renderer, Rgba color)
    {
        float[] rawArray = color.ToRawArray();
        IntPtr colorPtr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * rawArray.Length);
        Marshal.Copy(rawArray, 0, colorPtr, rawArray.Length);
        Zig.SetBackgroundColor(renderer, colorPtr);
    }

    //TODO: Implement the rest of the IRenderLib methods
}
