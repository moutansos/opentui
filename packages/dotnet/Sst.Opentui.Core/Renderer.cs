using System.Linq;

namespace Sst.Opentui.Core;

internal struct MemorySnapshot 
{
  public int heapUsed;
  public int heapTotal;
  public int arryayBuffers;
}

public class CliRenderer 
{
  private static int animationFrameId = 0;
  //private RenderLib lib;
  private StreamReader stdin;
  private StreamWriter stdout;
  private bool exitOnCtrlC;
  private bool isDestroyed;
  //private OptimizedBuffer nextRenderBuffer;
  //private OptimizedBuffer currentRenderBuffer;
  private bool isRunning;
  private int targetFps;
  private int memorySnapshotInterval;
  //private Timer memorySnapshotTimer;
  private MemorySnapshot lastMemorySnapshot;
  // private RootRenderable root;
  private int width;
  private int height;
  private bool useThread;
  private bool gatherStats;
  private IEnumerable<int> frameTimes;
  private int maxStatSamples = 300;
  // private IEnumerable<Action<OptomizedBuffer, int>> postProcessFns;
  // private Rgba backgroundColor;

  protected CliRenderer(
    StreamReader stdin,
    StreamWriter stdout
  ) {
    this.isDestroyed = false;
    this.isRunning = false;
    this.targetFps = 30;
    this.lastMemorySnapshot = new MemorySnapshot
    {
      heapUsed = 0,
      heapTotal = 0,
      arryayBuffers = 0
    };
    this.useThread = false;
    this.frameTimes = Enumerable.Empty<int>();
    this.postProcessFns = Enumerable.Empty<Action<OptomizedBuffer, int>>();
  }
}
