using Sst.Opentui.Core;

// See https://aka.ms/new-console-template for more information

IntPtr renderer = Zig.CreateRenderer(800, 600);
Zig.ClearTerminal(renderer);

//Probably draw with renderer here instead at some point
Console.WriteLine("Hello, World!");

Console.ReadKey();
Zig.DestroyRenderer(renderer, false, 0
