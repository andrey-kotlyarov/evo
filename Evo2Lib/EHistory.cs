using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public class EHistory
    {
        private List<EHistoryItem> _items;

        public List<EHistoryItem> items { get { return _items; } }


        public EHistory()
        {
            _items = new List<EHistoryItem>();
        }

        public void Add(EGrid grid)
        {
            _items.Insert(0, new EHistoryItem(grid));
        }
    }
}
