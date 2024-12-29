using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using OData.Learn.Dal.Models;

var builder = WebApplication.CreateBuilder(args);



var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.EntityType<Order>();

modelBuilder.EntitySet<Customer>("Customers");

builder.Services
	.AddControllers()
	.AddOData(option =>
	
		option.Select()
			.Filter()
			.OrderBy()
			.Expand()
			.Count()
			.SetMaxTop(null)
			.AddRouteComponents(
				routePrefix: "odata",
				modelBuilder.GetEdmModel()
			)
	);

//modelBuilder.EntityType<Order>();
//modelBuilder.EntitySet<Customer>("Customers");


//builder.Services.AddControllers()
//	.AddOData(
//	options =>
//		options
//			.Select()
//			.Filter()
//			.OrderBy()
//			.Expand()
//			.Count()
//			.SetMaxTop(null)
//			.AddRouteComponents(
//				"odata",
//				modelBuilder.GetEdmModel()
//				)
//		);

//app.MapGet("/", () => "Hello World!");
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});
//app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
