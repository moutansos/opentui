using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Sst.Opentui.Core;

public enum CursorStyle
{
  Block = 0,
  Line = 1,
  Underline = 2,
}

public enum DebugOverlayCorner
{
  TopLeft = 0,
  TopRight = 1,
  BottomLeft = 2,
  BottomRight = 3,
}

public enum TextAttribute
{
  Bold = 1 << 0,
  Dim = 1 << 1,
  Italic = 1 << 2,
  Underline = 1 << 3,
  Blink = 1 << 4,
  Inverse = 1 << 5,
  Hidden = 1 << 6,
  Strikethrough = 1 << 7,
  DoubleUnderline = 1 << 8,
}

public static class TextAttributeExtensions
{
  public static bool IsBold(this TextAttribute attr) => (attr & TextAttribute.Bold) != 0;
  public static bool IsDim(this TextAttribute attr) => (attr & TextAttribute.Dim) != 0;
  public static bool IsItalic(this TextAttribute attr) => (attr & TextAttribute.Italic) != 0;
  public static bool IsUnderline(this TextAttribute attr) => (attr & TextAttribute.Underline) != 0;
  public static bool IsBlink(this TextAttribute attr) => (attr & TextAttribute.Blink) != 0;
  public static bool IsInverse(this TextAttribute attr) => (attr & TextAttribute.Inverse) != 0;
  public static bool IsHidden(this TextAttribute attr) => (attr & TextAttribute.Hidden) != 0;
  public static bool IsStrikethrough(this TextAttribute attr) => (attr & TextAttribute.Strikethrough) != 0;
  public static bool IsDoubleUnderline(this TextAttribute attr) => (attr & TextAttribute.DoubleUnderline) != 0;
}

public class Rgba
{
  internal float[] buffer;

  public Rgba(float[] buffer)
  {
    this.buffer = buffer;
  }

  public static Rgba FromArray(float[] arr) => new Rgba(arr);
  public static Rgba FromValues(float r, float g, float b, float a = 1.0f) => new(new float[] { r, g, b, a });
  public static Rgba FromInts(int r, int g, int b, int a = 255) => new(new float[] { r / 255f, g / 255f, b / 255f, a / 255f });
  public static Rgba FromHex(string hex) => throw new NotImplementedException();

  public (int r, int g, int b, int a) ToInts()
  {
    return (
        (int)Math.Round(this.buffer[0] * 255),
        (int)Math.Round(this.buffer[1] * 255),
        (int)Math.Round(this.buffer[2] * 255),
        (int)Math.Round(this.buffer[3] * 255)
    );
  }

  public float R
  {
    get => this.buffer[0];
    set => this.buffer[0] = value;
  }

  public float G
  {
    get => this.buffer[1];
    set => this.buffer[1] = value;
  }

  public float B
  {
    get => this.buffer[2];
    set => this.buffer[2] = value;
  }

  public float A
  {
    get => this.buffer[3];
    set => this.buffer[3] = value;
  }

  public R[] Map<R>(Func<float, R> fn) =>
    new R[] { fn(this.buffer[0]), fn(this.buffer[1]), fn(this.buffer[2]), fn(this.buffer[3]) };

  public override string ToString() => $"rgba({this.buffer[0]:F2}, {this.buffer[1]:F2}, {this.buffer[2]:F2}, {this.buffer[3]})";

  public static Rgba HexToRgb(string hex)
  {
    hex = hex.Replace("#", "");

    if (hex.Length == 3)
    {
      hex = string.Concat(hex[0], hex[0], hex[1], hex[1], hex[2], hex[2]);
    }

    // Check for bad format with regex
    if (Regex.IsMatch(hex, @"^[0-9A-Fa-f]{6}$") == false)
    {
      Console.WriteLine($"Invalid hex color: {hex}, defaulting to magenta");
      return Rgba.FromValues(1, 0, 1, 1);
    }

    float r = Convert.ToInt32(hex.Substring(0, 2), 16) / 255f;
    float g = Convert.ToInt32(hex.Substring(2, 2), 16) / 255f;
    float b = Convert.ToInt32(hex.Substring(4, 2), 16) / 255f;

    return Rgba.FromValues(r, g, b, 1);
  }

  public static string RgbToHex(Rgba color)
  {
    var (r, g, b, a) = color.ToInts();
    return $"#{r:X2}{g:X2}{b:X2}";
  }

  public static Rgba HsvToRgb(float h, float s, float v)
  {

    float r = 0, g = 0, b = 0;

    int i = (int)Math.Floor(h * 6);
    float f = h * 6 - i;
    float p = v * (1 - s);
    float q = v * (1 - f * s);
    float t = v * (1 - (1 - f) * s);

    switch (i % 6)
    {
      case 0:
        r = v; g = t; b = p;
        break;
      case 1:
        r = q; g = v; b = p;
        break;
      case 2:
        r = p; g = v; b = t;
        break;
      case 3:
        r = p; g = q; b = v;
        break;
      case 4:
        r = t; g = p; b = v;
        break;
      case 5:
        r = v; g = p; b = q;
        break;
    }

    return Rgba.FromValues(r, g, b, 1);
  }

  private static readonly Dictionary<string, string> CSS_COLOR_NAMES = new()
  {
    ["black"] = "#000000",
    ["white"] = "#FFFFFF",
    ["red"] = "#FF0000",
    ["green"] = "#008000",
    ["blue"] = "#0000FF",
    ["yellow"] = "#FFFF00",
    ["cyan"] = "#00FFFF",
    ["magenta"] = "#FF00FF",
    ["silver"] = "#C0C0C0",
    ["gray"] = "#808080",
    ["grey"] = "#808080",
    ["maroon"] = "#800000",
    ["olive"] = "#808000",
    ["lime"] = "#00FF00",
    ["aqua"] = "#00FFFF",
    ["teal"] = "#008080",
    ["navy"] = "#000080",
    ["fuchsia"] = "#FF00FF",
    ["purple"] = "#800080",
    ["orange"] = "#FFA500",
    ["brightblack"] = "#666666",
    ["brightred"] = "#FF6666",
    ["brightgreen"] = "#66FF66",
    ["brightblue"] = "#6666FF",
    ["brightyellow"] = "#FFFF66",
    ["brightcyan"] = "#66FFFF",
    ["brightmagenta"] = "#FF66FF",
    ["brightwhite"] = "#FFFFFF",
  };

  public static Rgba ParseColor(string colorString)
  {
    string color = colorString.Trim().ToLower();

    if (color == "trasparent")
      return Rgba.FromValues(0, 0, 0, 0);

    if (CSS_COLOR_NAMES.ContainsKey(color))
      return HexToRgb(CSS_COLOR_NAMES[color]);
    if (Regex.IsMatch(color, @"^#([0-9A-Fa-f]{3}){1,2}$"))
      return HexToRgb(color);

    throw new ArgumentException($"Unknown color format: {colorString}");
  }

  public float[] ToRawArray() => this.buffer;
}

public enum WidthMethod
{
  ArcWidth = 0,
  Unicode = 1,
}

public record LineInfo(int[] LineStarts, int[] LineWidths);

public record BorderSides(
    bool Top,
    bool Right,
    bool Bottom,
    bool Left
)
{
    public static BorderSides All => new BorderSides(true, true, true, true);
    public static BorderSides None => new BorderSides(false, false, false, false);
}

public enum TextAliignment
{
    Left = 0,
    Center = 1,
    Right = 2,
}

public record BoxOptions(
    BorderSides Sides,
    bool Fill,
    TextAliignment TitleAlignment,
    char[] BorderChars,
    string? Title = null
)
{
    public static readonly char[] DefaultBorderChars = new char[] 
    { 
      '┌', '┐', 
      '└', '┘', 
      '─', '│',
    };

    internal UInt32 ToPackedOptions()
    {
        UInt32 packed = 0;
        if (Sides.Top) packed |= 0b1000;
        if (Sides.Right) packed |= 0b0100;
        if (Sides.Bottom) packed |= 0b0010;
        if (Sides.Left) packed |= 0b0001;
        if (Fill) packed |= 1 << 4;
        packed |= Convert.ToUInt32(((int)TitleAlignment)&0b11) << 5;
        return packed;
    }
}
