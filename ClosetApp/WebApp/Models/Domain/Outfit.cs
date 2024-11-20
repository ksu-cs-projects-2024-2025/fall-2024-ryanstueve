using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Domain
{
    public class Outfit : ICollection<ClothingItem>
    {
        public int Count => _outfit.Count;

        public bool IsReadOnly => false;

        private List<ClothingItem> _outfit = new List<ClothingItem>();

        public void Add(ClothingItem item)
        {
            _outfit.Add(item);
        }

        public void Clear()
        {
            _outfit.Clear();
        }

        public bool Contains(ClothingItem item)
        {
            return _outfit.Contains(item);
        }

        public void CopyTo(ClothingItem[] array, int arrayIndex)
        {
            _outfit.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ClothingItem> GetEnumerator()
        {
            return _outfit.GetEnumerator();
        }

        public bool Remove(ClothingItem item)
        {
            return _outfit.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _outfit.GetEnumerator();
        }
    }
}
