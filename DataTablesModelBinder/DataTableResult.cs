using Newtonsoft.Json;

namespace DataTablesModelBinder
{
    public class DataTableResult
    {
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }
        [JsonProperty(PropertyName = "recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty(PropertyName = "recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty(PropertyName = "data")]
        public dynamic Data { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string ErrorMessage { get; set; }

        public DataTableResult(DataTable dt, int totalCount, int filteredCount, dynamic data, string error = null)
        {
            Draw = dt.Draw;
            RecordsTotal = totalCount;
            RecordsFiltered = filteredCount;
            Data = data;
            ErrorMessage = error;
        }
    }
}