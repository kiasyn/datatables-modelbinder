using System.Collections.Generic;

namespace DataTablesModelBinder
{
    public class DataTable
    {
        internal int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DataTableSearch Search { get; set; }
        public Dictionary<int, DataTableColumn> Columns { get; set; }
        public Dictionary<int, DataTableOrder> Order { get; set; }

        public DataTable()
        {
            Search = new DataTableSearch();
            Columns = new Dictionary<int, DataTableColumn>();
            Order = new Dictionary<int, DataTableOrder>();
        }

        internal DataTableColumn GetOrCreateColumn(int index)
        {
            if (!Columns.ContainsKey(index))
                Columns[index] = new DataTableColumn(this);
            return Columns[index];
        }

        internal DataTableOrder GetOrCreateOrder(int index)
        {
            if (!Order.ContainsKey(index))
                Order[index] = new DataTableOrder(this);
            return Order[index];
        }
    }
}