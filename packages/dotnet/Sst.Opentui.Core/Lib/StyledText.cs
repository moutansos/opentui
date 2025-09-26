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

    private static TextChunk ApplyStyle(TextChunk input, StyleAttrs style)
    {
        Rgba? fg = style.Fg ?? input.Fg;
        Rgba? bg = style.Bg ?? input.Bg;
        
        throw new NotImplementedException(); //TODO: Pick up here
    }
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

