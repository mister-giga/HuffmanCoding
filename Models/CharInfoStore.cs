using System.Diagnostics.CodeAnalysis;

namespace HuffmanCoding.Models
{
    public class CharInfoStore 
    {
        readonly Dictionary<char, CharInfo> store;
        public CharInfoStore()
        {
            store = new Dictionary<char, CharInfo>(new CharComparer());
        }

        public IEqualityComparer<char> Comparer => store.Comparer;

        public bool TryAdd(char @char, out CharInfo charInfo)
        {
            if (!store.ContainsKey(@char))
            {
                store[@char] = charInfo = new CharInfo(@char);
                return true;
            }
            charInfo = store[@char];
            return false;
        }

        public void SetCount(char @char, uint count)
        {
            if (store.TryGetValue(@char, out var val))
                val.Count = count;
        }

        public bool SetBlocked(char @char, bool isBlocked)
        {
            TryAdd(@char, out var info);

            if(info.IsBlocked != isBlocked)
            {
                info.IsBlocked = isBlocked;
                return true;
            }
            return false;
        }

        public void ResetData(string text)
        {
            foreach (var value in store.Values)
                value.Count = 0;

            foreach (var group in text.GroupBy(x => x))
            {
                TryAdd(group.Key, out var info);
                info.Count += (uint)group.Count();
            }
        }

        public IEnumerable<CharInfo> Enumerate()
        {
            foreach (var item in store.Values)
            {
                yield return item;
            }
        }

        class CharComparer : IEqualityComparer<char>
        {
            public bool Equals(char x, char y) => char.ToLower(x) == char.ToLower(y);

            public int GetHashCode([DisallowNull] char obj) => char.ToLower(obj).GetHashCode();
        }



        public Leaf? ExtractTree()
        {
            var items = store.Values.Where(x => x.Count > 0 && !x.IsBlocked).Select(x => new Leaf(x.Char, x.Count)).OrderBy(x => x.Count).ToList();

            while (items.Any())
            {
                if(items.Count >= 2)
                {
                    var firstTwo = items.Take(2).ToArray();
                    var topNode = new Leaf().WithLeft(firstTwo[0]).WithRight(firstTwo[1]);
                    items = items.Skip(2).Append(topNode).OrderBy(x => x.Count).ToList();
                }
                else
                {
                    return items[0].WithFilledCodes();
                }
            }

            return null; 


        }
    }
}
