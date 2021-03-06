# Migration Section
for enabling migration you need to open NuGet Package Manager and
type Enable-Migrations(it is must to have a DBContext class in your Model)

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }
}
Be sure you use

using System.Data.Entity;

Now,
after any changes Give a Name For adding migration like: add-migration MigrationName

For Update same migration use add-migration MigrationName -force

Than use update-database for generating database

For Seeding Data into Database, Create a migration (add-migration MigrationName)
than,     
public partial class MigrationName : DbMigration
    {
        public override void Up()
        {										   [TABLE NAME]
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DuretionInMonths, DiscountRates)VALUES(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DuretionInMonths, DiscountRates)VALUES(2,30,1,10)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DuretionInMonths, DiscountRates)VALUES(3,90,3,15)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DuretionInMonths, DiscountRates)VALUES(4,300,12,20)");
        }
		use command:update-database in PMC(Package Manager Console)

# Implementing validation

Adding Validation 

Decorate properties of your model with data annotations. Then, in the controller:
if	(!ModelState.IsValid)
				return	View(…);	

                And in the view:
@Html.ValidationMessageFor(m	=>	m.Name)	

Styling Validation Errors 
In site.css:
.input-validation-error	{
				color:	red;
}		
.field-validation-error	{
				border:	2px	solid	red;
}	

*Data Annotations*

• [Required]
• [StringLength(255)]
• [Range(1, 10)]
• [Compare(“OtherProperty”)]
• [Phone]
• [EmailAddress]
• [Url]
• [RegularExpression(“…”)]

# Custom Validation

public	class	Min18IfAMember	:	ValidationAttribute
{
					protected	override	ValidationResult	IsValid(object	value,	
ValidationContext	validationContext)
					{
										…
										if	(valid)	return	ValidationResult.Success;
										else	return	new	ValidationResult(“error	message”);
					}
}	
		
        #Validation Summary 
        @Html.ValidationSummary(true,	“Please	fix	the	following	errors”);	

        ##Client-side Validation 
@section	scripts	{	
					@Scripts.Render(“~/bundles/jqueryval”)
}		

# Anti-forgery Tokens

In the view:
@Html.AntiForgeryToken()	
In the controller:
[ValidateAntiForgeryToken]
public	ActionResult	Save()	{	}	


# Building Web APIs:
*RESTful Convention*
 
Request Description
GET /api/customers Get all customers
GET /api/customers/1 Get customer with ID 1
POST /api/customers Add a new customer (customer data in the request body)
PUT /api/customers/1 Update customer with ID 1 (customer data in the request body)
DELETE /api/customers/1 Delete customer with ID 1

*Building an API* 

public	IHttpActionResult	GetCustomers()	{}	

[HttpPost]
public	IHttpActionResult	CreateCustomer(CustomerDto	customer)	{}	
[HttpPut]
public	IHttpActionResult	UpdateCustomer(int	id,	CustomerDto	
customer)	{}	
[HttpDelete]
public	IHttpActionResult	DeleteCustomer(int	id)	{}	

*Helper methods
• NotFound()
• Ok()
• Created()
• Unauthorized()

# AutoMapper
Create a mapping profile first:
public	class	MappingProfile	:	Profile	
{
					public	MappingProfile()
					{
										Mapper.CreateMap<Customer,	CustomerDto>();
					}
}	
Load the mapping profile during application startup (in global.asax.cs):
protected	void	Application_Start()
{
				Mapper.Initialize(c	=>	c.AddProfile<MappingProfile>());
}	
To map objects:
var	customerDto	=	Mapper.Map<Customer,	CustomerDto>(customer);	

Or to map to an existing object:
Mapper.Map(customer,	customerDto);	

# Enabling camel casing
In WebApiConfig:
public	static	void	Register(HttpConfiguration	config)
{
				var	settings	=	
config.Formatters.JsonFormatter.SerializerSettings;
				settings.ContractResolver	=	new	
CamelCasePropertyNamesContractResolver();
				settings.Formatting	=	Formatting.Indented;
}

Property ‘Id’ is part of object’s key information and cannot be modified.
This exception happens at the following line:
Mapper.Map(movieDto,	movie);	
The exception is thrown when AutoMapper attempts to set the Id of movie:
customer.Id	=	customerDto.Id;	
Id is the key property for the Movie class, and a key property should not be changed.
That’s why we get this exception. To resolve this, you need to tell AutoMapper to ignore
Id during mapping of a MovieDto to Movie.
In MappingProfile:
CreateMap<Movie,	MovieDto>()
				.ForMember(m	=>	m.Id,	opt	=>	opt.Ignore());	
The same configuration should be applied to mapping of customers:
CreateMap<Customer,	CustomerDto>()
				.ForMember(c	=>	c.Id,	opt	=>	opt.Ignore());

				##Client-side Development##
# Calling an API Using jQuery 
$.ajax({
				url:	“…”,
				method:	“…”,	//	DELETE,	POST,	PUT,	optional	for	GET
				success:	function(result){
								…
				}
});	
*Bootbox*

bootbox.confirm(“Are	you	sure?”,	function(result){
				if	(result)	{	
				}
});	

*DataTables* - Zero Configuration
$(“#customers”).DataTable();	
 
 *DataTables* - Ajax Source
$(“#customers”).DataTable({
				ajax:	{
								url:	“…”,
								dataSrc:	“”
				},
				columns:	[
									{	data:	“name”	},
									{	
											data:	“id”,
											render:	function(data,	type,	row){
															return	“…”;
											}
									}
				]
});	

*DataTables* - Removing Records
var	table	=	$(“…”).DataTable(…);	
var	$tr	=	$(“…”);
table.rows(tr).remove().draw();	

# Data Caching 

*Use Data Caching with Expensive Queries*

In the demo, I stored the list of genres in the cache. Getting the list of genres would
issue a “SELECT * FROM Genres” query to the database, and given that this is a
simple and fast query, caching the result would just waste server’s resources.
Use data caching for complex queries over large tables that take several seconds to
execute. This way, you can argue that using additional memory on the server can be
better (but not necessarily) than querying your database several times. You need to
profile before and after your optimization to ensure your assumptions are correct and
are not based on some theory you read in a book or tutorial.

MemoryCache.Add() 

If you want to have more control over the objects you put in their cache, it’s better to use
the Add method of MemoryCache class.

MemoryCache.Default.Add(
				new	CacheItem(“Key”,value),	
				cacheItemPolicy);

As you see, the second argument to this method is a cacheItemPolicy object. With this
object you can set the expiration date/time (both absolute and sliding) and you can also
register callbacks to be called when the item is removed from the cache.

# Performance Optimization

*Rules of thumb* 
• Do not sacrifice the maintainability of your code to premature optimization.
• Be realistic and think like an “engineer”.
• Be pragmatic and ensure your efforts have observable results and give value.
And remember: premature optimization is the root of all evils.

*Database tier*

Schema
Every table must have a primary key.
• Tables should have relationships.
• Put indexes on columns where you filter records on. But remember: too many
indexes can have an adverse impact on the performance.
• Avoid Entity-Attribute-Value (EAV) pattern.

Queries
Keep an eye on EF queries using Glimpse. If a query is slow, use a stored
procedure.
• Use Execution Plan in SQL Server to find performance bottlenecks in your
queries.

If after all your optimizations, you still have slow queries, consider creating a
denormalised “read” database for your queries. But remember, this comes with the cost
of maintaining two databases in sync. A simpler approach is to use caching.

*Application tier*

On pages where you have costly queries on data that doesn’t change frequently,
use OutputCache to cache the rendered HTML.
• You can also store the results of the query in cache (using MemoryCache), but
use this approach only in actions that are used for displaying data, not modifying
it.
• Async does not improve performance. It improves scalability given that you’re
not using a single instance of SQL Server on the back-end. You should be using
a SQL cluster, or a NoSQL database (eg MongoDB, RavenDB, etc) or SQL
Azure.
• Disable session in web.config.
• Use release builds in production.

Client Tier 

• Put JS and CSS files in bundles. 
• Put the script bundles near the end of the <body> element. Modernizr is an
exception. It needs to be in the head.
• Return small, lightweight DTOs from your APIs.
• Render HTML markup on the client. That’s the case with single page
applications (SPA).
• Compress images.
• Use image sprites. This is beyond the scope of the course and you need to read
about them yourself.
• Reduce the data you store in cookies because they’re sent back and forth with
every request.
• Use content delivery networks (CDN). Again, beyond the scope of the course.
Implementations vary depending on where you host your application. 