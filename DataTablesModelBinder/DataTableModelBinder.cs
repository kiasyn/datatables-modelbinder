using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace DataTablesModelBinder
{
    public class DataTableModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            DataTable dt = new DataTable();
            dt.Draw = int.Parse(request.Params.Get("draw"));
            dt.Start = int.Parse(request.Params.Get("start"));
            dt.Length = int.Parse(request.Params.Get("length"));

            dt.Search.Regex = request.Params.Get("Regex");
            dt.Search.Value = request.Params.Get("Value");

            Regex columnRegex = new Regex(@"columns\[(\d+)\]\[(\w+)\](\[(\w+)\])?");
            Regex orderRegex = new Regex(@"order\[(\d+)\]\[(\w+)\]");

            for (int i = 0; i < request.Params.Count; i++)
            {
                string key = request.Params.Keys[i], value = request.Params[i];

                Match match = columnRegex.Match(key);
                while (match.Success)
                {
                    int columnNumber = int.Parse(match.Groups[1].Captures[0].Value);
                    string paramName = match.Groups[2].Captures[0].Value;
                    string subParamName = null;

                    if (match.Groups[4].Success)
                        subParamName = match.Groups[4].Captures[0].Value;
                    DataTableColumn column = dt.GetOrCreateColumn(columnNumber);

                    switch (paramName)
                    {
                        case "name":
                            column.Name = value;
                            break;
                        case "data":
                            column.Data = value;
                            break;
                        case "orderable":
                            column.Orderable = bool.Parse(value);
                            break;
                        case "searchable":
                            column.Searchable = bool.Parse(value);
                            break;
                        case "search":
                            switch (subParamName)
                            {
                                case "regex":
                                    column.Search.Regex = value;
                                    break;
                                case "value":
                                    column.Search.Value = value;
                                    break;
                            }
                            break;
                    }
                    match = match.NextMatch();
                }

                match = orderRegex.Match(key);
                while (match.Success)
                {
                    int columnNumber = int.Parse(match.Groups[1].Captures[0].Value);
                    string paramName = match.Groups[2].Captures[0].Value;

                    DataTableOrder order = dt.GetOrCreateOrder(columnNumber);

                    switch (paramName)
                    {
                        case "column":
                            order.ColumnNumber = int.Parse(value);
                            break;
                        case "dir":
                            order.Direction = string.IsNullOrEmpty(value) ? DataTableOrderDirection.None : value == "asc" ? DataTableOrderDirection.Ascending : DataTableOrderDirection.Descending;
                            break;
                    }
                    match = match.NextMatch();
                }
            }

            return dt;
        }
    }
}