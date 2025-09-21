using Sst.Opentui.Core;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IntPtr renderer = Zig.CreateRenderer(800, 600);
Console.ReadKey();
Zig.DestroyRenderer(renderer, false, 0);
