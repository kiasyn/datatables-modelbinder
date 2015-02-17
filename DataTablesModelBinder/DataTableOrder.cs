
namespace DataTablesModelBinder
{
    public enum DataTableOrderDirection { Ascending, Descending, None };

    public class DataTableOrder
    {
        private DataTable DataTable;
        internal int ColumnNumber { get; set; }
        public DataTableColumn Column { get { return DataTable.GetOrCreateColumn(ColumnNumber); } }
        public DataTableOrderDirection Direction { get; set; }

        internal DataTableOrder(DataTable dt)
        {
            DataTable = dt;
        }
    }
}