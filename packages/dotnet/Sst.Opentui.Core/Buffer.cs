namespace Sst.Opentui.Core;

internal struct BufferData
{
  public UInt32[] charArray;
  public float[] fg;
  public float[] bg;
  public short[] attributes;
}

public record BufferOptions(bool? RespectAlpha = null);

public class OptomizedBuffer
{
  private static int fbIdCounter = 0; 
  private string id;
  public IRenderLib lib; //TODO: Maybe make this private with a getter?
  private IntPtr bufferPtr;
  private BufferData buffer;
  private int width;
  private int height;
  public bool respectAlpha;
  public bool useFfi;

  internal OptomizedBuffer(IRenderLib lib, IntPtr ptr, BufferData buffer, int width, int height, BufferOptions? options = null)
  {
    this.id = $"fb_{fbIdCounter++}";
    this.lib = lib;
    this.bufferPtr = ptr;
    this.useFfi = true;
    this.respectAlpha = options?.RespectAlpha ?? false;

    this.buffer = buffer;
    this.width = width;
    this.height = height;
  }

  public IntPtr Ptr => this.bufferPtr;

  // public static OptomizedBuffer Create(int width, int height, WidthMethod widthMethod, bool respectAlpha = false)
  // {
  //
  // }
}

