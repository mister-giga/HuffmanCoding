namespace HuffmanCoding.Models
{
    public class CharInfo
    {
        public char Char { get; }
        public uint Count { get; set; }
        public bool IsBlocked { get; set; } 
        public CharInfo(char @char)
        {
            Char = char.ToLower(@char);
        }

        public override int GetHashCode() => Char.GetHashCode();
        public override bool Equals(object? obj) => obj != null && Char.Equals((obj as CharInfo)?.Char);
    }
}
