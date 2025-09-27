using Sst.Opentui.Core;

namespace packages.dotnet.Sst.Opentui.Core.Lib;

public class StyleAttrs
{
    public Rgba? Fg { get; set; }
    public Rgba? Bg { get; set; }
    public bool? Bold { get; set; }
    public bool? Italic { get; set; }
    public bool? Underline { get; set; }
    public bool? Strikethrough { get; set; }
    public bool? Dim { get; set; }
    public bool? Reverse { get; set; }
    public bool? Blink { get; set; }

    public TextAttribute ToTextAttributeFlags()
    {
        TextAttribute flags = 0;
        if (Bold == true) flags |= TextAttribute.Bold;
        if (Dim == true) flags |= TextAttribute.Dim;
        if (Italic == true) flags |= TextAttribute.Italic;
        if (Underline == true) flags |= TextAttribute.Underline;
        if (Blink == true) flags |= TextAttribute.Blink;
        if (Reverse == true) flags |= TextAttribute.Inverse;
        if (Strikethrough == true) flags |= TextAttribute.Strikethrough;
        return flags;
    }

    public byte ToTextAttributeByte()
    {
        byte flags = 0;
        if (Bold == true) flags |= (byte)TextAttribute.Bold;
        if (Dim == true) flags |= (byte)TextAttribute.Dim;
        if (Italic == true) flags |= (byte)TextAttribute.Italic;
        if (Underline == true) flags |= (byte)TextAttribute.Underline;
        if (Blink == true) flags |= (byte)TextAttribute.Blink;
        if (Reverse == true) flags |= (byte)TextAttribute.Inverse;
        if (Strikethrough == true) flags |= (byte)TextAttribute.Strikethrough;
        return flags;
    }
}

public class StyledText
{
    private readonly TextChunk[] chunks;
    //TODO: plaintext should probably be removed when selection is moved to native
    private string plainText = "";

    public StyledText(TextChunk[] chunks)
    {
        this.chunks = chunks;

        foreach (TextChunk chunk in chunks)
            this.plainText += chunk.PlainText;
    }

    private StyledText(TextChunk[] chunks, string plainText)
    {
        this.chunks = chunks;      
        this.plainText = plainText;
    }

    public override string ToString() => this.plainText;

    private static string ChunksToPlainText(TextChunk[] chunks)
    {
        string result = "";
        foreach (TextChunk chunk in chunks)
            result += chunk.PlainText;
        return result;
    }

    public StyledText Insert(TextChunk chunk, int? index = null)
    {
        int originalLength = this.chunks.Length;
        IEnumerable<TextChunk> newChunks = Enumerable.Empty<TextChunk>();
        string newPlainText;

        if (index == null || index == originalLength)
        {
            newChunks = this.chunks.Append(chunk);
            newPlainText = this.plainText + chunk.PlainText;
        }
        else
        {
            int idx = index.Value;
            if (idx < 0 || idx > originalLength)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            newChunks = this.chunks.Take(idx).Append(chunk).Concat(this.chunks.Skip(idx));
            newPlainText = ChunksToPlainText(newChunks.ToArray());
        }

        return new StyledText(newChunks.ToArray(), newPlainText);
    }

    public StyledText Remove(TextChunk chunk)
    {
        int originalLength = this.chunks.Length;
        int index = Array.IndexOf(this.chunks, chunk);
        if (index == -1)
            return this;

        IEnumerable<TextChunk> newChunks;
        string newPlainText;

        if (index == originalLength - 1)
        {
            newChunks = this.chunks.Take(originalLength - 1);
            newPlainText = this.plainText.Substring(0, this.plainText.Length - chunk.PlainText.Length);
        } 
        else
        {
            newChunks = this.chunks.Take(index).Concat(this.chunks.Skip(index + 1));
            newPlainText = ChunksToPlainText(newChunks.ToArray());
        }

        return new StyledText(newChunks.ToArray(), newPlainText);
    }

    public StyledText Replace(TextChunk oldChunk, TextChunk newChunk)
    {
        IEnumerable<TextChunk> newChunks = this.chunks.Select(c => c == oldChunk ? newChunk : c);
        string newPlainText = ChunksToPlainText(newChunks.ToArray());
        return new StyledText(newChunks.ToArray(), newPlainText);
    }

    public static StyledText StringToStyledText(string str)
    {
        TextChunk chunk = new TextChunk(
            text: System.Text.Encoding.UTF8.GetBytes(str),
            plainText: str
        );
        return new StyledText(new TextChunk[] { chunk });
    }

    internal static TextChunk ApplyStyle(TextChunk input, StyleAttrs style)
    {
        Rgba? fg = style.Fg ?? input.Fg;
        Rgba? bg = style.Bg ?? input.Bg;
        
        TextChunk newChunk = input.WithStyleApplied(
            fg: fg,
            bg: bg,
            attributes: style.ToTextAttributeByte()
        );

        return newChunk;
    }

    internal static TextChunk ApplyStyle(int input, StyleAttrs style)
    {
        string str = input.ToString();
        TextChunk chunk = new TextChunk(
            text: System.Text.Encoding.UTF8.GetBytes(str),
            plainText: str
        );
        return ApplyStyle(chunk, style);
    }

    internal static TextChunk ApplyStyle(bool input, StyleAttrs style)
    {
        string str = input.ToString();
        TextChunk chunk = new TextChunk(
            text: System.Text.Encoding.UTF8.GetBytes(str),
            plainText: str
        );
        return ApplyStyle(chunk, style);
    }

    internal static TextChunk ApplyStyle(string input, StyleAttrs style)
    {
        TextChunk chunk = new TextChunk(
            text: System.Text.Encoding.UTF8.GetBytes(input),
            plainText: input
        );
        return ApplyStyle(chunk, style);
    }
}

public static class ColorFunctions
{
    #region Regular Colors

    public static TextChunk Black(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("black") });
    public static TextChunk Black(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("black") });
    public static TextChunk Black(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("black") });
    public static TextChunk Black(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("black") });

    public static TextChunk Red(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("red") });
    public static TextChunk Red(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("red") });
    public static TextChunk Red(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("red") });
    public static TextChunk Red(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("red") });

    public static TextChunk Green(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("green") });
    public static TextChunk Green(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("green") });
    public static TextChunk Green(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("green") });
    public static TextChunk Green(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("green") });

    public static TextChunk Yellow(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("yellow") });
    public static TextChunk Yellow(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("yellow") });
    public static TextChunk Yellow(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("yellow") });
    public static TextChunk Yellow(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("yellow") });

    public static TextChunk Blue(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("blue") });
    public static TextChunk Blue(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("blue") });
    public static TextChunk Blue(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("blue") });
    public static TextChunk Blue(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("blue") });

    public static TextChunk Magenta(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("magenta") });
    public static TextChunk Magenta(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("magenta") });
    public static TextChunk Magenta(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("magenta") });
    public static TextChunk Magenta(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("magenta") });

    public static TextChunk Cyan(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("cyan") });
    public static TextChunk Cyan(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("cyan") });
    public static TextChunk Cyan(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("cyan") });
    public static TextChunk Cyan(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("cyan") });

    public static TextChunk White(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("white") });
    public static TextChunk White(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("white") });
    public static TextChunk White(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("white") });
    public static TextChunk White(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("white") });

    #endregion

    #region Bright Colors

    public static TextChunk BrightBlack(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlack") });
    public static TextChunk BrightBlack(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlack") });
    public static TextChunk BrightBlack(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlack") });
    public static TextChunk BrightBlack(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlack") });

    public static TextChunk BrightRed(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightRed") });
    public static TextChunk BrightRed(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightRed") });
    public static TextChunk BrightRed(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightRed") });
    public static TextChunk BrightRed(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightRed") });

    public static TextChunk BrightGreen(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightGreen") });
    public static TextChunk BrightGreen(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightGreen") });
    public static TextChunk BrightGreen(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightGreen") });
    public static TextChunk BrightGreen(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightGreen") });

    public static TextChunk BrightYellow(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightYellow") });
    public static TextChunk BrightYellow(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightYellow") });
    public static TextChunk BrightYellow(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightYellow") });
    public static TextChunk BrightYellow(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightYellow") });

    public static TextChunk BrightBlue(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlue") });
    public static TextChunk BrightBlue(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlue") });
    public static TextChunk BrightBlue(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlue") });
    public static TextChunk BrightBlue(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightBlue") });

    public static TextChunk BrightMagenta(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightMagenta") });
    public static TextChunk BrightMagenta(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightMagenta") });
    public static TextChunk BrightMagenta(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightMagenta") });
    public static TextChunk BrightMagenta(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightMagenta") });

    public static TextChunk BrightCyan(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightCyan") });
    public static TextChunk BrightCyan(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightCyan") });
    public static TextChunk BrightCyan(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightCyan") });
    public static TextChunk BrightCyan(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightCyan") });

    public static TextChunk BrightWhite(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightWhite") });
    public static TextChunk BrightWhite(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightWhite") });
    public static TextChunk BrightWhite(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightWhite") });
    public static TextChunk BrightWhite(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = Rgba.ParseColor("brightWhite") });

    #endregion

    #region Background Colors
    
    public static TextChunk BgBlack(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("black") });
    public static TextChunk BgBlack(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("black") });
    public static TextChunk BgBlack(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("black") });
    public static TextChunk BgBlack(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("black") });

    public static TextChunk BgRed(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("red") });
    public static TextChunk BgRed(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("red") });
    public static TextChunk BgRed(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("red") });
    public static TextChunk BgRed(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("red") });

    public static TextChunk BgGreen(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("green") });
    public static TextChunk BgGreen(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("green") });
    public static TextChunk BgGreen(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("green") });
    public static TextChunk BgGreen(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("green") });

    public static TextChunk BgYellow(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("yellow") });
    public static TextChunk BgYellow(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("yellow") });
    public static TextChunk BgYellow(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("yellow") });
    public static TextChunk BgYellow(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("yellow") });

    public static TextChunk BgBlue(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("blue") });
    public static TextChunk BgBlue(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("blue") });
    public static TextChunk BgBlue(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("blue") });
    public static TextChunk BgBlue(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("blue") });

    public static TextChunk BgMagenta(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("magenta") });
    public static TextChunk BgMagenta(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("magenta") });
    public static TextChunk BgMagenta(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("magenta") });
    public static TextChunk BgMagenta(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = Rgba.ParseColor("magenta") });

    #endregion

    #region Style Functions

    public static TextChunk Bold(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bold = true });
    public static TextChunk Bold(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bold = true });
    public static TextChunk Bold(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bold = true });
    public static TextChunk Bold(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bold = true });

    public static TextChunk Italic(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Italic = true });
    public static TextChunk Italic(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Italic = true });
    public static TextChunk Italic(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Italic = true });
    public static TextChunk Italic(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Italic = true });

    public static TextChunk Underline(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Underline = true });
    public static TextChunk Underline(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Underline = true });
    public static TextChunk Underline(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Underline = true });
    public static TextChunk Underline(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Underline = true });

    public static TextChunk Strikethrough(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Strikethrough = true });
    public static TextChunk Strikethrough(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Strikethrough = true });
    public static TextChunk Strikethrough(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Strikethrough = true });
    public static TextChunk Strikethrough(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Strikethrough = true });

    public static TextChunk Dim(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Dim = true });
    public static TextChunk Dim(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Dim = true });
    public static TextChunk Dim(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Dim = true });
    public static TextChunk Dim(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Dim = true });

    public static TextChunk Reverse(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Reverse = true });
    public static TextChunk Reverse(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Reverse = true });
    public static TextChunk Reverse(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Reverse = true });
    public static TextChunk Reverse(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Reverse = true });

    public static TextChunk Blink(string input) => StyledText.ApplyStyle(input, new StyleAttrs { Blink = true });
    public static TextChunk Blink(int input) => StyledText.ApplyStyle(input, new StyleAttrs { Blink = true });
    public static TextChunk Blink(bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Blink = true });
    public static TextChunk Blink(TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Blink = true });

    #endregion

    public static TextChunk Fg(Rgba color, string input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = color });
    public static TextChunk Fg(Rgba color, int input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = color });
    public static TextChunk Fg(Rgba color, bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = color });
    public static TextChunk Fg(Rgba color, TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Fg = color });

    public static TextChunk Bg(Rgba color, string input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = color });
    public static TextChunk Bg(Rgba color, int input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = color });
    public static TextChunk Bg(Rgba color, bool input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = color });
    public static TextChunk Bg(Rgba color, TextChunk input) => StyledText.ApplyStyle(input, new StyleAttrs { Bg = color });
}

public abstract record StylableInput
{
    public record StringStylableInput(string Value) : StylableInput;
    public record IntStylableInput(int Value) : StylableInput;
    public record BoolStylableInput(bool Value) : StylableInput;
    public record TextChunkStylableInput(TextChunk Value) : StylableInput;

    public static StylableInput New(string str) => new StringStylableInput(str);
    public static StylableInput New(int val) => new IntStylableInput(val);
    public static StylableInput New(bool val) => new BoolStylableInput(val);
    public static StylableInput New(TextChunk chunk) => new TextChunkStylableInput(chunk);
}

