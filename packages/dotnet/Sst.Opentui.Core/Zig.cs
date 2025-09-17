using System.Runtime.InteropServices;

namespace Sst.Opentui.Core;

//TODO: Make this insternal after testing
public unsafe static partial class Zig
{
    [LibraryImport("opentui", EntryPoint = "createRenderer")]
    public static partial IntPtr CreateRenderer(UInt32 width, UInt32 height);
}
