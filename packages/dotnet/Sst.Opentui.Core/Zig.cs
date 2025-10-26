using System.Runtime.InteropServices;
using System.Text;
using static Sst.Opentui.Core.Zig;

namespace Sst.Opentui.Core;

//TODO: Make this insternal after testing
public unsafe static partial class Zig
{
    public const string LIB_NAME = "opentui";

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LogCallback(int level, IntPtr msgPtr, UInt128 msgLen);

    [LibraryImport(LIB_NAME, EntryPoint = "setLogCallback")]
    public static partial void SetLogCallback(LogCallback callback);

    [LibraryImport(LIB_NAME, EntryPoint = "createRenderer")]
    public static partial IntPtr CreateRenderer(UInt32 width, UInt32 height, [MarshalAs(UnmanagedType.I1)] bool testing = false);

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
    public static partial IntPtr CreateOptimizedBuffer(UInt32 width, UInt32 height, [MarshalAs(UnmanagedType.I1)] bool respectAlpha, UInt16 widthMethod, IntPtr id, UInt64 idLen);

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

    [LibraryImport(LIB_NAME, EntryPoint = "bufferGetId")]
    public static partial UInt64 BufferGetId(IntPtr buffer, IntPtr id, UInt64 idLen);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferDrawText")]
    public static partial void BufferDrawText(IntPtr buffer, IntPtr text, Int64 textLen, UInt32 x, UInt32 y, IntPtr fg, IntPtr bg, byte attributes);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferSetCellWithAlphaBlending")]
    public static partial void BufferSetCellWithAlphaBlending(IntPtr buffer, UInt32 x, UInt32 y, UInt32 char_code, IntPtr fg, IntPtr bg, byte attributes);

    [LibraryImport(LIB_NAME, EntryPoint = "bufferSetCell")]
    public static partial void BufferSetCell(IntPtr buffer, UInt32 x, UInt32 y, UInt32 char_code, IntPtr color, IntPtr bgColor, byte attributes);

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

    [LibraryImport(LIB_NAME, EntryPoint = "setTerminalTitle")]
    public static partial void SetTerminalTitle(IntPtr renderer, IntPtr title, UInt64 titleLen);

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
    public static partial void DumpBuffers(IntPtr renderer, Int64 timestamp);

    [LibraryImport(LIB_NAME, EntryPoint = "dumpStdoutBuffer")]
    public static partial void DumpStdoutBuffer(IntPtr renderer, Int64 timestamp);

    [LibraryImport(LIB_NAME, EntryPoint = "enableMouse")]
    public static partial void EnableMouse(IntPtr renderer, [MarshalAs(UnmanagedType.I1)] bool enableMovement);

    [LibraryImport(LIB_NAME, EntryPoint = "disableMouse")]
    public static partial void DisableMouse(IntPtr renderer);

    [LibraryImport(LIB_NAME, EntryPoint = "enableKittyKeyboard")]
    public static partial void EnableKittyKeyboard(IntPtr renderer, byte flags);

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

    [LibraryImport(LIB_NAME, EntryPoint = "processCapabilityResponse")]
    public static partial void ProcessCapabilityResponse(IntPtr renderer, IntPtr response, UInt64 responseLen);
}

public record ClipRect(int x, int y, int width, int height);
public enum UnicodeType
{
    WcWidth,
    Unicode
}
public record TerminalCapabilities(bool KittyKeyboard,
                                   bool KittyGraphics,
                                   bool Rgb,
                                   UnicodeType Unicode,
                                   bool SgrPixels,
                                   bool ColorSchemeUpdates,
                                   bool ExplicitWidth,
                                   bool ScaledText,
                                   bool Sixel,
                                   bool FocusTracking,
                                   bool Sync,
                                   bool BracketedPaste,
                                   bool Hyperlinks);
public interface IRenderLib
{
    public IntPtr CreateRenderer(int width, int height, bool testing = false);
    public void DestroyRenderer(IntPtr renderer, bool useAlternateScreen, int splitHeight);
    public void SetUseThread(IntPtr renderer, bool useThread);
    public void SetBackgroundColor(IntPtr renderer, Rgba color);
    public void SetRenderOffset(IntPtr renderer, int offset);
    public void UpdateStats(IntPtr renderer, int time, int fps, int frameCallbackTime);
    public void UpdateMemoryStats(IntPtr renderer, int heapUsed, int heapTotal, int arrayBuffers);
    public void Render(IntPtr renderer, bool force = false);
    public OptomizedBuffer GetNextBuffer(IntPtr renderer);
    public OptomizedBuffer GetCurrentBuffer(IntPtr renderer);
    public OptomizedBuffer CreateOptimizedBuffer(int width, int height, WidthMethod widthMethod, bool respectAlpha = false, string? id = "unnamed buffer");
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
    public string BufferGetId(IntPtr buffer);
    public void BufferDrawText(IntPtr buffer, string text, int x, int y, Rgba color, Rgba? bgColor, byte? attributes = null);
    public void BufferSetCellWithAlphaBlending(IntPtr buffer, int x, int y, char character , Rgba color, Rgba bgColor, byte attributes);
    public void BufferSetCell(IntPtr buffer, int x, int y, char character , Rgba color, Rgba bgColor, byte attributes);
    public void BufferFillRect(IntPtr buffer, int x, int y, int width, int height, Rgba color);
    public void BufferDrawSuperSampleBuffer(IntPtr buffer, int x, int y, IntPtr pixelDataPtr, int pixelDataLenth, int alignedBytesPerRow);
    public void BufferDrawPackedBuffer(IntPtr buffer, IntPtr dataPtr, int dataLen, int posX, int posY, int terminalWidthCells, int terminalHeightCells);
    public void BufferDrawBox(IntPtr buffer, int x, int y, int width, int height, BoxOptions options, Rgba borderColor, Rgba backgroundColor);
    public BufferData BufferResize(IntPtr buffer, int width, int height);
    public void ResizeRenderer(IntPtr renderer, int width, int height);
    public void SetCursorPosition(IntPtr renderer, int x, int y, bool visible);
    public void SetCursorStyle(IntPtr renderer, CursorStyle style, bool blinking);
    public void SetCursorColor(IntPtr renderer, Rgba color);
    public void SetDebugOverlay(IntPtr renderer, bool enabled, DebugOverlayCorner corner);
    public void ClearTerminal(IntPtr renderer);
    public void SetTerminalTitle(IntPtr renderer, string title);
    public void AddToHitGrid(IntPtr renderer, int x, int y, int width, int height, int id);
    public int CheckHit(IntPtr renderer, int x, int y);
    public void DumpHitGrid(IntPtr renderer);
    public void DumpBuffers(IntPtr renderer, DateTime? timestamp = null);
    public void DumpStdoutBuffer(IntPtr renderer, DateTime? timestamp = null);
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
    public BufferData TextBufferResize(IntPtr buffer, int newLength); 
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
    public LineInfo TextBufferGetLineInfo(IntPtr buffer);
    public BufferData GetTextBufferArrays(IntPtr buffer, int size);
    public void BufferDrawTextBuffer(IntPtr buffer, IntPtr textBuffer, int x, int y, ClipRect? clipRect);

    public TerminalCapabilities GetTerminalCapabilities(IntPtr renderer);
    public void ProcessCapabilityResponse(IntPtr renderer, string response);
}

public class FFIRenderLib : IRenderLib
{
    private bool loggingSetup = false;

    public FFIRenderLib() 
    {
        this.SetupLogging();
    }

    //TODO: Maybe maybe a logger that can be used from the Microsoft.Extensions.Logging namespace?
    private void SetupLogging()
    {
        if (this.loggingSetup)
            return;

        LogCallback callback = (int level, IntPtr msgPtr, UInt128 msgLen) =>
        {
          try
          {
              if (msgLen == 0 || msgPtr == IntPtr.Zero)
                  return;

              byte[] msgBuffer = new byte[(long)msgLen];
              Marshal.Copy(msgPtr, msgBuffer, 0, (int)msgLen);
              string message = Encoding.UTF8.GetString(msgBuffer);
              switch (level)
              {
                  case 0:
                      Console.Error.WriteLine($"[ERROR] {message}");
                      break;
                  case 1:
                      Console.Error.WriteLine($"[WARN] {message}");
                      break;
                  case 2:
                      Console.WriteLine($"[INFO] {message}");
                      break;
                  case 3:
                      Console.WriteLine($"[DEBUG] {message}");
                      break;
                  default:
                      Console.WriteLine($"[LOG] {message}");
                      break;
              }
          }
          catch (Exception ex)
          {
              Console.Error.WriteLine($"[LOG ERROR] Error in Zig log callback: {ex.Message}");
          }
        };

        Zig.SetLogCallback(callback);
        this.loggingSetup = true;
    }

    public IntPtr CreateRenderer(int width, int height, bool testing) => Zig.CreateRenderer((UInt32)width, (UInt32)height, testing);

    public void DestroyRenderer(IntPtr renderer, bool useAlternateScreen, int splitHeight) =>
      Zig.DestroyRenderer(renderer, useAlternateScreen, (UInt32)splitHeight);

    public void SetUseThread(IntPtr renderer, bool useThread) => Zig.SetUseThread(renderer, useThread);

    public void SetBackgroundColor(IntPtr renderer, Rgba color)
    {
        Zig.SetBackgroundColor(renderer, color.ToRawArrayPtr());
    }

    public void SetRenderOffset(IntPtr renderer, int offset) => Zig.SetRenderOffset(renderer, (UInt32)offset);

    public void UpdateStats(IntPtr renderer, int time, int fps, int frameCallbackTime) =>
      Zig.UpdateStats(renderer, time, (UInt32)fps, frameCallbackTime);

    public void UpdateMemoryStats(IntPtr renderer, int heapUsed, int heapTotal, int arrayBuffers) =>
      Zig.UpdateMemoryStats(renderer, (UInt32)heapUsed, (UInt32)heapTotal, (UInt32)arrayBuffers);

    public void Render(IntPtr renderer, bool force = false) => Zig.Render(renderer, force);

    public OptomizedBuffer GetNextBuffer(IntPtr renderer)
    {
        IntPtr bufferPtr = Zig.GetNextBuffer(renderer);

        if (bufferPtr == IntPtr.Zero)
            throw new Exception("Failed to get next buffer from renderer");

        UInt32 width = Zig.GetBufferWidth(bufferPtr);
        UInt32 height = Zig.GetBufferHeight(bufferPtr);
        UInt32 size = width * height;

        BufferData buffers = this.GetBuffer(bufferPtr, (int)size);

        return new OptomizedBuffer(this, bufferPtr, buffers, Convert.ToInt32(width), Convert.ToInt32(height));
    }

    public OptomizedBuffer GetCurrentBuffer(IntPtr renderer)
    {
        IntPtr bufferPtr = Zig.GetCurrentBuffer(renderer);

        if (bufferPtr == IntPtr.Zero)
            throw new Exception("Failed to get current buffer from renderer");

        UInt32 width = Zig.GetBufferWidth(bufferPtr);
        UInt32 height = Zig.GetBufferHeight(bufferPtr);
        UInt32 size = width * height;

        BufferData buffers = this.GetBuffer(bufferPtr, (int)size);

        return new OptomizedBuffer(this, bufferPtr, buffers, Convert.ToInt32(width), Convert.ToInt32(height));
    }

    private BufferData GetBuffer(IntPtr bufferPtr, int size)
    {
        IntPtr charPtr = Zig.BufferGetCharPtr(bufferPtr);
        IntPtr fgPtr = Zig.BufferGetFgPtr(bufferPtr);
        IntPtr bgPtr = Zig.BufferGetBgPtr(bufferPtr);
        IntPtr attributesPtr = Zig.BufferGetAttributesPtr(bufferPtr);

        UInt32[] charArray = new UInt32[size];
        float[] fg = new float[size * 4];
        float[] bg = new float[size * 4];
        byte[] attributes = new byte[size];

        Marshal.Copy(charPtr, (int[])(object)charArray, 0, size);
        Marshal.Copy(fgPtr, fg, 0, size * 4);
        Marshal.Copy(bgPtr, bg, 0, size * 4);
        Marshal.Copy(attributesPtr, attributes, 0, size);

        return new BufferData(charArray, fg, bg, attributes);
    }

    public void BufferClear(IntPtr buffer, Rgba color) => Zig.BufferClear(buffer, color.ToRawArrayPtr());
    public int GetBufferWidth(IntPtr buffer) => (int)Zig.GetBufferWidth(buffer);
    public int GetBufferHeight(IntPtr buffer) => (int)Zig.GetBufferHeight(buffer);
    public IntPtr BufferGetCharPtr(IntPtr buffer) => Zig.BufferGetCharPtr(buffer);
    public IntPtr BufferGetFgPtr(IntPtr buffer) => Zig.BufferGetFgPtr(buffer);
    public IntPtr BufferGetBgPtr(IntPtr buffer) => Zig.BufferGetBgPtr(buffer);
    public IntPtr BufferGetAttributesPtr(IntPtr buffer) => Zig.BufferGetAttributesPtr(buffer);

    public OptomizedBuffer CreateOptimizedBuffer(int width, int height, WidthMethod widthMethod, bool respectAlpha = false, string? id = "unnamed buffer")
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Width and height must be greater than zero");

        IntPtr idPtr = IntPtr.Zero;
        UInt64 idLen = 0;

        if (id is not null)
        {
            byte[] idBytes = Encoding.UTF8.GetBytes(id);
            idLen = (UInt64)idBytes.Length;
            idPtr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * idBytes.Length);
            Marshal.Copy(idBytes, 0, idPtr, idBytes.Length);
        }

        IntPtr bufferPtr = Zig.CreateOptimizedBuffer((UInt32)width, (UInt32)height, respectAlpha, (UInt16)widthMethod, idPtr, idLen);

        if (bufferPtr == IntPtr.Zero)
            throw new Exception("Failed to create optimized buffer");

        int size = width * height;
        var buffers = this.GetBuffer(bufferPtr, size);

        return new OptomizedBuffer(this, bufferPtr, buffers, width, height, new BufferOptions(respectAlpha));
    }

    public void DestroyOptimizedBuffer(IntPtr buffer) => Zig.DestroyOptimizedBuffer(buffer);

    public void DrawFrameBuffer(IntPtr targetBufferPtr, int destX, int destY, IntPtr bufferPtr, int? sourceX, int? sourceY, int? sourceWidth, int? sourceHeight) =>
        Zig.DrawFrameBuffer(targetBufferPtr, (Int32)destX, (Int32)destY, bufferPtr,
                            (UInt32)(sourceX ?? 0), (UInt32)(sourceY ?? 0),
                            (UInt32)(sourceWidth ?? 0), (UInt32)(sourceHeight ?? 0));

    public void SetDebugOverlay(IntPtr renderer, bool enabled, DebugOverlayCorner corner) =>
      Zig.SetDebugOverlay(renderer, enabled, (byte)corner);

    public void ClearTerminal(IntPtr renderer) => Zig.ClearTerminal(renderer);

    public void SetTerminalTitle(IntPtr renderer, string title)
    {
        byte[] titleBytes = Encoding.UTF8.GetBytes(title);
        IntPtr titlePtr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * titleBytes.Length);
        Marshal.Copy(titleBytes, 0, titlePtr, titleBytes.Length);
        Zig.SetTerminalTitle(renderer, titlePtr, (UInt64)titleBytes.Length);
    }

    public void AddToHitGrid(IntPtr renderer, int x, int y, int width, int height, int id) =>
      Zig.AddToHitGrid(renderer, (Int32)x, (Int32)y, (UInt32)width, (UInt32)height, (UInt32)id);

    public int CheckHit(IntPtr renderer, int x, int y) => (int)Zig.CheckHit(renderer, (UInt32)x, (UInt32)y);
    public void DumpHitGrid(IntPtr renderer) => Zig.DumpHitGrid(renderer);
    public void DumpBuffers(IntPtr renderer, DateTime? timestamp = null)
    {
      long ts = timestamp is null ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : ((DateTimeOffset)timestamp).ToUnixTimeMilliseconds();
      Zig.DumpBuffers(renderer, ts);
    }

    public void DumpStdoutBuffer(IntPtr renderer, DateTime? timestamp = null)
    {
      long ts = timestamp is null ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : ((DateTimeOffset)timestamp).ToUnixTimeMilliseconds();
      Zig.DumpStdoutBuffer(renderer, ts);
    }

    public void EnableMouse(IntPtr renderer, bool enableMovement) => Zig.EnableMouse(renderer, enableMovement);

    public void DisableMouse(IntPtr renderer) => Zig.DisableMouse(renderer);

    public void EnableKittyKeyboard(IntPtr renderer, byte flags) => Zig.EnableKittyKeyboard(renderer, flags);

    public void DisableKittyKeyboard(IntPtr renderer) => Zig.DisableKittyKeyboard(renderer);

    public void SetupTerminal(IntPtr renderer, bool useAlternateScreen) => Zig.SetupTerminal(renderer, useAlternateScreen);

    public TextBuffer CreateTextBuffer(int capacity, WidthMethod widthMethod)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero");

        IntPtr bufferPtr = Zig.CreateTextBuffer((UInt32)capacity, (byte)widthMethod);

        if (bufferPtr == IntPtr.Zero)
            throw new Exception("Failed to create text buffer");

        return new TextBuffer(this, bufferPtr, new TextBuffer.BufferData(), capacity);
    }

    public void DestroyTextBuffer(IntPtr buffer) => Zig.DestroyTextBuffer(buffer);

    public IntPtr TextBufferGetCharPtr(IntPtr buffer) => Zig.TextBufferGetCharPtr(buffer);

    public IntPtr TextBufferGetFgPtr(IntPtr buffer) => Zig.TextBufferGetFgPtr(buffer);

    public IntPtr TextBufferGetBgPtr(IntPtr buffer) => Zig.TextBufferGetBgPtr(buffer);

    public IntPtr TextBufferGetAttributesPtr(IntPtr buffer) => Zig.TextBufferGetAttributesPtr(buffer);

    public bool BufferGetRespectAlpha(IntPtr buffer) => Zig.BufferGetRespectAlpha(buffer);

    public void BufferSetRespectAlpha(IntPtr buffer, bool respectAlpha) => Zig.BufferSetRespectAlpha(buffer, respectAlpha);

    public string BufferGetId(IntPtr buffer)
    {
        const int MAX_ID_LENGTH = 256;
        IntPtr idPtr = Marshal.AllocHGlobal(MAX_ID_LENGTH);
        UInt64 idLen = Zig.BufferGetId(buffer, idPtr, (UInt64)MAX_ID_LENGTH);

        if (idLen == 0)
        {
            Marshal.FreeHGlobal(idPtr);
            return string.Empty;
        }

        byte[] idBytes = new byte[(long)idLen];
        Marshal.Copy(idPtr, idBytes, 0, (int)idLen);
        Marshal.FreeHGlobal(idPtr);

        return Encoding.UTF8.GetString(idBytes);
    }

    public int BufferGetWidth(IntPtr buffer) => (int)Zig.GetBufferWidth(buffer);

    public int TextBufferGetLength(IntPtr buffer) => (int)Zig.TextBufferGetLength(buffer);

    public void BufferDrawText(IntPtr buffer, string text, int x, int y, Rgba color, Rgba? bgColor, byte? attributes = null)
    {
        UTF8Encoding encoding = new();
        byte[] textBytes = encoding.GetBytes(text);
        int textLength = textBytes.Length;
        float[]? bg = bgColor?.buffer;
        float[] fg = color.buffer;

        IntPtr textPtr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * textLength);
        Marshal.Copy(textBytes, 0, textPtr, textLength);

        IntPtr bgPtr = bg is null ? IntPtr.Zero : Marshal.AllocHGlobal(Marshal.SizeOf<float>() * bg.Length);
        if (bg is not null)
            Marshal.Copy(bg, 0, bgPtr, bg.Length);

        IntPtr fgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * fg.Length);
        Marshal.Copy(fg, 0, fgPtr, fg.Length);

        Zig.BufferDrawText(buffer, textPtr, textLength, Convert.ToUInt32(x), Convert.ToUInt32(y), fgPtr, bgPtr, attributes ?? 0);
    }

    public void BufferSetCellWithAlphaBlending(IntPtr buffer, int x, int y, char character , Rgba color, Rgba bgColor, byte attributes) =>
      Zig.BufferSetCellWithAlphaBlending(buffer, (UInt32)x, (UInt32)y, (UInt32)character, color.ToRawArrayPtr(), bgColor.ToRawArrayPtr(), attributes);

    public void BufferSetCell(IntPtr buffer, int x, int y, char character , Rgba color, Rgba bgColor, byte attributes) =>
      Zig.BufferSetCell(buffer, Convert.ToUInt32(x), Convert.ToUInt32(y), Convert.ToUInt32(character), color.ToRawArrayPtr(), bgColor.ToRawArrayPtr(), attributes);

    public void BufferFillRect(IntPtr buffer, int x, int y, int width, int height, Rgba color) =>
      Zig.BufferFillRect(buffer, Convert.ToUInt32(x), Convert.ToUInt32(y), Convert.ToUInt32(width), Convert.ToUInt32(height), color.ToRawArrayPtr());
    
    public void ResizeRenderer(IntPtr renderer, int width, int height) => Zig.ResizeRenderer(renderer, Convert.ToUInt32(width), Convert.ToUInt32(height));

    public void SetCursorPosition(IntPtr renderer, int x, int y, bool visible) => Zig.SetCursorPosition(renderer, Convert.ToUInt32(x), Convert.ToUInt32(y), visible);
    
    public void SetCursorStyle(IntPtr renderer, CursorStyle cursorStyle, bool blinking)
    {
        string styleStr = cursorStyle switch 
        {
            CursorStyle.Block => "block",
            CursorStyle.Line => "line",
            CursorStyle.Underline => "underline",
            _ => throw new ArgumentOutOfRangeException(nameof(cursorStyle), "Invalid cursor style")
        };

        byte[] styleBytes = System.Text.Encoding.UTF8.GetBytes(styleStr);
        int styleLen = styleBytes.Length;
        
        IntPtr stylePtr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * styleLen);
        Marshal.Copy(styleBytes, 0, stylePtr, 4);

        Zig.SetCursorStyle(renderer, stylePtr, styleLen, blinking);
    }

    public void SetCursorColor(IntPtr renderer, Rgba color) => Zig.SetCursorColor(renderer, color.ToRawArrayPtr());

    public void TextBufferSetCell(IntPtr buffer, int index, char character, Rgba color, Rgba bgColor, byte attributes)
    {
      IntPtr colorPtr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * 4);
      Marshal.Copy(color.ToRawArray(), 0, colorPtr, 4);
      IntPtr bgColorPtr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * 4);
      Marshal.Copy(bgColor.ToRawArray(), 0, bgColorPtr, 4);

      Zig.TextBufferSetCell(buffer, (UInt32)index, (UInt32)character, color.ToRawArrayPtr(), bgColor.ToRawArrayPtr(), attributes);
    }

    public TextBuffer TextBufferConcat(IntPtr buffer1, IntPtr buffer2)
    {
        IntPtr newBufferPtr = Zig.TextBufferConcat(buffer1, buffer2);

        if (newBufferPtr == IntPtr.Zero)
            throw new Exception("Failed to concatenate text buffers");

        int lengthPtr = Convert.ToInt32(Zig.TextBufferGetLength(newBufferPtr));
        int capacity = Convert.ToInt32(Zig.TextBufferGetCapacityb(newBufferPtr));

        return new TextBuffer(this, newBufferPtr, new TextBuffer.BufferData(), capacity);
    }

    public BufferData TextBufferResize(IntPtr buffer, int newLength)
    {
        if (newLength <= 0)
            throw new ArgumentException("New length must be greater than zero");

        Zig.TextBufferResize(buffer, (UInt32)newLength);
        return this.GetTextBuffer(buffer, newLength);
    }

    public void BufferDrawBox(IntPtr buffer, 
                              int x, 
                              int y, 
                              int width, 
                              int height, 
                              BoxOptions options, 
                              Rgba borderColor, 
                              Rgba backgroundColor)
    {
        IntPtr titlePtr = IntPtr.Zero;
        int titleLen = -1;
        if(options.Title is not null)
        {
            byte[] titleBytes = System.Text.Encoding.UTF8.GetBytes(options.Title);
            titleLen = titleBytes.Length;
            titlePtr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * titleLen);
            Marshal.Copy(titleBytes, 0, titlePtr, titleLen);
        }

        IntPtr borderCharsPtr = options.BorderChars is null ? IntPtr.Zero : options.BorderChars.ToRawArrayPtr();

        Zig.BufferDrawBox(
            buffer: buffer, 
            x: x, 
            y: y, 
            width: Convert.ToUInt32(width), 
            height: Convert.ToUInt32(height), 
            borderChars: borderCharsPtr, 
            packedOptions: options.ToPackedOptions(),
            borderColor: borderColor.ToRawArrayPtr(),
            backgroundColor: backgroundColor.ToRawArrayPtr(), 
            title: titlePtr, 
            titleLen: (UInt32)(titleLen == -1 ? 0 : titleLen));
    }

    public void BufferDrawPackedBuffer(IntPtr buffer, IntPtr dataPtr, int dataLen, int posX, int posY, int terminalWidthCells, int terminalHeightCells) =>
      Zig.BufferDrawPackedBuffer(buffer, dataPtr, Convert.ToUInt32(dataLen), Convert.ToUInt32(posX), Convert.ToUInt32(posY), Convert.ToUInt32(terminalWidthCells), Convert.ToUInt32(terminalHeightCells));

    public void BufferDrawSuperSampleBuffer(IntPtr buffer, int x, int y, IntPtr pixelDataPtr, int pixelDataLenth, int alignedBytesPerRow) =>
      Zig.BufferDrawSuperSampleBuffer(buffer, Convert.ToUInt32(x), Convert.ToUInt32(y), pixelDataPtr, Convert.ToUInt64(pixelDataLenth), 0, Convert.ToUInt32(alignedBytesPerRow));

    public BufferData BufferResize(IntPtr buffer, int width, int height)
    {
        Zig.BufferResize(buffer, Convert.ToUInt32(width), Convert.ToUInt32(height));
        return this.GetBuffer(buffer, width * height);
    }

    public void TextBufferReset(IntPtr buffer) => Zig.TextBufferReset(buffer);

    public void TextBufferSetSelection(IntPtr buffer, int start, int end, Rgba? bgColor, Rgba? fgColor)
    {
        IntPtr bgColorPtr = bgColor is null ? IntPtr.Zero : bgColor.ToRawArrayPtr();
        IntPtr fgColorPtr = fgColor is null ? IntPtr.Zero : fgColor.ToRawArrayPtr();

        Zig.TextBufferSetSelection(buffer, (UInt32)start, (UInt32)end, bgColorPtr, fgColorPtr);
    }

    public void TextBufferResetSelection(IntPtr buffer) => Zig.TextBufferResetSelection(buffer);

    public void TextBufferSetDefaultFg(IntPtr buffer, Rgba? color)
    {
        IntPtr colorPtr = color is null ? IntPtr.Zero : color.ToRawArrayPtr();
        Zig.TextBufferSetDefaultFg(buffer, colorPtr);
    }

    public void TextBufferSetDefaultBg(IntPtr buffer, Rgba? color)
    {
        IntPtr colorPtr = color is null ? IntPtr.Zero : color.ToRawArrayPtr();
        Zig.TextBufferSetDefaultBg(buffer, colorPtr);
    }

    public void TextBufferSetDefaultAttributes(IntPtr buffer, byte? attributes) =>
      Zig.TextBufferSetDefaultAttributes(buffer, attributes ?? 0);

    public void TextBufferResetDefaults(IntPtr buffer) => Zig.TextBufferResetDefaults(buffer);

    public int TextBufferWriteChunk(IntPtr buffer, string text, Rgba? fg, Rgba? bg, byte? attributes)
    {
        IntPtr fgPtr = fg is null ? IntPtr.Zero : fg.ToRawArrayPtr();
        IntPtr bgPtr = bg is null ? IntPtr.Zero : bg.ToRawArrayPtr();

        return (int)Zig.TextBufferWriteChunk(buffer, Marshal.StringToHGlobalAnsi(text), (UInt32)text.Length, fgPtr, bgPtr, attributes ?? 0);
    }

    public int TextBufferGetCapacity(IntPtr buffer) => (int)Zig.TextBufferGetCapacityb(buffer);
    public void TextBufferFinalizeLineInfo(IntPtr buffer) => Zig.TextBufferFinalizeLineInfo(buffer);

    public LineInfo TextBufferGetLineInfo(IntPtr buffer)
    {
        IntPtr lineStartsPtr = Zig.TextBufferGetLineStartsPtr(buffer);
        IntPtr lineWidthsPtr = Zig.TextBufferGetLineWidthsPtr(buffer);
        int lineCount = (int)Zig.TextBufferGetLineCount(buffer);

        int[] lineStarts = new int[lineCount];
        int[] lineWidths = new int[lineCount];

        Marshal.Copy(lineStartsPtr, lineStarts, 0, lineCount);
        Marshal.Copy(lineWidthsPtr, lineWidths, 0, lineCount);

        return new LineInfo(lineStarts, lineWidths);
    }

    public BufferData GetTextBuffer(IntPtr buffer, int size)
    {
        IntPtr charPtr = Zig.TextBufferGetCharPtr(buffer);
        IntPtr fgPtr = Zig.TextBufferGetFgPtr(buffer);
        IntPtr bgPtr = Zig.TextBufferGetBgPtr(buffer);
        IntPtr attributesPtr = Zig.TextBufferGetAttributesPtr(buffer);

        UInt32[] charArray = new UInt32[size];
        float[] fgArray = new float[size * 4];
        float[] bgArray = new float[size * 4];
        byte[] attributesArray = new byte[size];

        Marshal.Copy(charPtr, (int[])(object)charArray, 0, size);
        Marshal.Copy(fgPtr, fgArray, 0, size * 4);
        Marshal.Copy(bgPtr, bgArray, 0, size * 4);
        Marshal.Copy(attributesPtr, attributesArray, 0, size);

        return new BufferData(charArray, fgArray, bgArray, attributesArray);
    }

    public BufferData GetTextBufferArrays(IntPtr buffer, int size) => this.GetTextBuffer(buffer, size);

    public void BufferDrawTextBuffer(IntPtr buffer, IntPtr textBuffer, int x, int y, ClipRect? clipRect)
    {
        if (clipRect is null)
        {
            Zig.BufferDrawTextBuffer(buffer, textBuffer, (Int32)x, (Int32)y, 0, 0, 0, 0, false);
        }
        else
        {
            Zig.BufferDrawTextBuffer(buffer, textBuffer, (Int32)x, (Int32)y,
                                     (Int32)clipRect.x,
                                     (Int32)clipRect.y,
                                     (UInt32)clipRect.width,
                                     (UInt32)clipRect.height,
                                     true);
        }
    }

    public TerminalCapabilities GetTerminalCapabilities(IntPtr renderer)
    {
        IntPtr capsPtr = Marshal.AllocHGlobal(1024);
        Zig.GetTerminalCapabilities(renderer, capsPtr); 

        int offset = 0;
        bool KittyKeyboard = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool KittyGraphics = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool Rgb = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        UnicodeType unicodeType = (UnicodeType)Marshal.ReadByte(capsPtr, offset); offset += 1;
        bool SgrPixels = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool ColorSchemeUpdates = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool ExplicitWidth = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool ScaledText = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool Sixel = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool FocusTracking = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool Sync = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool BracketedPaste = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        bool Hyperlinks = Marshal.ReadByte(capsPtr, offset) != 0; offset += 1;
        Marshal.FreeHGlobal(capsPtr);

        return new TerminalCapabilities(KittyKeyboard,
                                        KittyGraphics,
                                        Rgb,
                                        unicodeType,
                                        SgrPixels,
                                        ColorSchemeUpdates,
                                        ExplicitWidth,
                                        ScaledText,
                                        Sixel,
                                        FocusTracking,
                                        Sync,
                                        BracketedPaste,
                                        Hyperlinks);
    }

    public void ProcessCapabilityResponse(IntPtr renderer, string response)
    { 
        byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
        IntPtr responseBytesPtr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * responseBytes.Length);
        Marshal.Copy(responseBytes, 0, responseBytesPtr, responseBytes.Length);
        Zig.ProcessCapabilityResponse(renderer, responseBytesPtr, Convert.ToUInt32(responseBytes.Length));
    }
}
