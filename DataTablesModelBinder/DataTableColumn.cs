
namespace DataTablesModelBinder
{
    public class DataTableColumn
    {
        private DataTable DataTable;

        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DataTableSearch Search { get; set; }

        internal DataTableColumn(DataTable dt)
        {
            DataTable = dt;
            Search = new DataTableSearch();
        }
    }
}