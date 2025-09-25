using Sst.Opentui.Core;

namespace packages.dotnet.Sst.Opentui.Core.Lib;

public class ColorInput
{
    // TODO: Implement color parsing and storage or convert all to Rgba

    public static ColorInput FromString(string str) => new ColorInput();
    public static ColorInput FromRgba(Rgba color) => new ColorInput();
}

public class StyleAttrs
{
    public ColorInput? Fg { get; set; }
    public ColorInput? Bg { get; set; }
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
        TextChunk[] newChunks;

        //TODO: Start back up here. Need to finish porting "insert" logic
    }
}

