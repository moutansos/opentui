using Sst.Opentui.Core.Lib;

namespace Sst.Opentui.Core;

public class TextChunk
{
    internal bool isChunk = true;
    public byte[] Text { get; set; }
    public string PlainText { get; set; }
    public Rgba? Fg;
    public Rgba? Bg;
    public byte? Attributes;

    public TextChunk(byte[] text,
                     string plainText,
                     Rgba? fg = null,
                     Rgba? bg = null,
                     byte? attributes = null)
    {
        this.Text = text;
        this.PlainText = plainText;
        this.Fg = fg;
        this.Bg = bg;
        this.Attributes = attributes;
    }

    public TextChunk WithStyleApplied(Rgba? fg = null,
                                      Rgba? bg = null,
                                      byte? attributes = null)
    {
        byte? newAttributes =
            attributes is null && this.Attributes is null ? null :
            attributes is null ? this.Attributes :
            this.Attributes is null ? attributes :
                (byte)(attributes.Value | this.Attributes.Value);

        return new TextChunk(this.Text,
                             this.PlainText,
                             fg ?? this.Fg,
                             bg ?? this.Bg,
                             newAttributes);
    }
}

public class TextBuffer
{
    public struct BufferData
    {
        public UInt32[] charArray;
        public float[] fg;
        public float[] bg;
        public UInt16[] attributes;
    }

    private struct LineInfo
    {
        public int[] lineStarts;
        public int[] lineWidths;
    }

    private IRenderLib lib;
    private IntPtr bufferPtr;
    private BufferData buffer;
    private int length = 0;
    private int capacity;
    private LineInfo lineInfo;

    public TextBuffer(IRenderLib lib,
                      IntPtr ptr,
                      BufferData buffer,
                      int capacity)
    {
        this.lib = lib;
        this.bufferPtr = ptr;
        this.buffer = buffer;
        this.capacity = capacity;
    }

    public static TextBuffer Create(WidthMethod widthMethod,  int capacity = 256)
    {
        // Need to implement the FFI instance of Render Lib and add the loader before this will work
        throw new NotImplementedException();

        // const lib = resolveRenderLib()
        // return lib.createTextBuffer(capacity, widthMethod)
    }

    private void SyncBuffersAfterResize()
    {
        // var capacity = this.lib.TextBufferGetCapacity(this.bufferPtr);

        // Need to finish this after FFI is done
        throw new NotImplementedException();

        // const capacity = this.lib.textBufferGetCapacity(this.bufferPtr)
        // this.buffer = this.lib.getTextBufferArrays(this.bufferPtr, capacity)
        // this._capacity = capacity
    }

    private void setStyledText(StyledText text)
    {
        // Need to finish this after FFI is done
        throw new NotImplementedException();
    }
}

