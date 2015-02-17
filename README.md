# datatables-modelbinder

Correctly binds a datatable for jquery-datatables

Requires Newtonsoft.Json

Only binds the data, does not do any automatic sorting or automagic fetching from databases

Example:
```
public class HomeController : Controller
{
	public ActionResult SalesTable( [ModelBinder(typeof(DataTableModelBinder))] DataTable datatable )
	{
		var data = fetchData( datatable );
		return JsonConvert.SerializeObject( data );
	}
}

```