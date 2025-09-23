namespace Sst.Opentui.Core;

internal struct BufferData
{
  public UInt32[] charArray;
  public float[] fg;
  public float[] bg;
  public short[] attributes;
}

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

  // public OptomiizedBuffer()
  // {
  //   this.id = $"fb_{fbIdCounter++}";
  //   this.respectAlpha = false;
  //   this.useFfi = true;
  // }

  public IntPtr Ptr => this.bufferPtr;

  // public static OptomizedBuffer Create(int width, int height, WidthMethod widthMethod, bool respectAlpha = false)
  // {
  //
  // }
}

