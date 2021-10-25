namespace HuffmanCoding.Models
{
    public class Leaf
    {
        public Leaf? Parent { get; set; }
        public Leaf? Left { get; set; }
        public Leaf? Right { get; set; }

        public uint Count { get; private set; }
        public char? Char { get;  }

        public Leaf(char? @char, uint count)
        {
            Count = count;
            Char = @char;
        }
        public Leaf()
        {

        }
        public Leaf(uint count):this(null, count)
        {

        }
        public Leaf(CharInfo charInfo):this(charInfo.Char, charInfo.Count)
        {

        }

        public Leaf WithLeft(Leaf leaf)
        {
            Left = leaf;
            leaf.Parent = this;
            Count += leaf.Count;
            return this;
        }

        public Leaf WithRight(Leaf leaf)
        {
            Right = leaf;
            leaf.Parent = this;
            Count += leaf.Count;
            return this;
        }

        public string Code { get; private set; }
        public Leaf WithFilledCodes()
        {
            if (Left == null && Right == null)
                Code = "1";
            else
                Fill("");

            return this;
        }

        void Fill(string upCode)
        {
            Code = upCode;
            Left?.Fill(upCode + "0");
            Right?.Fill(upCode + "1");
        }

        public void FillList(List<Leaf> list)
        {
            list.Add(this);

            Left?.FillList(list);
            Right?.FillList(list);
        }

       
        public int GetLevelCount()
        {
            return Math.Max(Left?.GetLevelCount() ?? 0, Right?.GetLevelCount() ?? 0) + 1;
        }

        public string Title
        {
            get
            {
                if (Char != null)
                    return $"{Char} | {Count}";
                return Count.ToString();
            }
        }

        public string Id => GetHashCode().ToString();

        public void FillConnections(VisData data, int level)
        {
            data.Nodes.Add(new VisNode 
            {
                Id = Id,
                Label = Title,
                Level = level
            });

            if(Left != null)
            {
                data.Connections.Add(new VisNodeConnection { From = Id, To = Left.Id });
                Left.FillConnections(data, level + 1);
            }

            if (Right != null)
            {
                data.Connections.Add(new VisNodeConnection { From = Id, To = Right.Id });
                Right.FillConnections(data, level + 1);
            }
        }
    }
}
