using Sst.Opentui.Core;

IRenderLib renderLib = new FFIRenderLib();

IntPtr renderer = renderLib.CreateRenderer(100, 20);
renderLib.SetBackgroundColor(renderer, Rgba.FromValues(0.1f, 0.1f, 0.3f));
renderLib.ClearTerminal(renderer);

OptomizedBuffer buffer = renderLib.GetNextBuffer(renderer);
renderLib.BufferClear(buffer.Ptr, Rgba.FromValues(0.1f, 0.1f, 0.3f));
renderLib.BufferDrawText(buffer.Ptr, "Hello world!", 3, 3, Rgba.FromInts(0, 255, 255), Rgba.FromInts(0, 0, 0));

BoxOptions opts = new(
    Sides: BorderSides.All,
    Fill: true,
    TitleAlignment: TextAliignment.Left,
    BorderChars: BoxOptions.RoundedBorderChars,
    Title: "< My Box >");

renderLib.BufferDrawBox(
    buffer: buffer.Ptr, 
    x: 10, 
    y: 10, 
    width: 20, 
    height: 5, 
    options: opts,
    Rgba.FromInts(255, 0, 0), 
    Rgba.FromInts(0, 0, 0, 0)
);

renderLib.BufferSetCell(buffer.Ptr, 20, 1, '@', Rgba.FromInts(0, 255, 0), Rgba.FromInts(0, 0, 255), 0);
renderLib.SetTerminalTitle(renderer, "My opentui Renderer");

renderLib.Render(renderer, force: true);

Console.ReadKey();
renderLib.DestroyRenderer(renderer, false, 0);
