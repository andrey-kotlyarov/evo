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
        private EHistoryItem _bestItem;
        


        public List<EHistoryItem> items { get { return _items; } }
        public EHistoryItem bestItem { get { return _bestItem; } }


        public EHistory()
        {
            _items = new List<EHistoryItem>();
            _bestItem = new EHistoryItem();
        }

        public void Add(EGrid grid)
        {
            EHistoryItem item = new EHistoryItem(grid);
            _items.Insert(0, item);

            if (_bestItem.iteration < item.iteration)
            {
                _bestItem = item;
            }
            else if (_bestItem.iteration == item.iteration)
            {
                if (_bestItem.averageHealth < item.averageHealth)
                {
                    _bestItem = item;
                }
            }

            return;
        }
        
    }
}
