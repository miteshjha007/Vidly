#Migration Section
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

#Implementing validation

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

##<<Custom Validation>>

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

##Anti-forgery Tokens

In the view:
@Html.AntiForgeryToken()	
In the controller:
[ValidateAntiForgeryToken]
public	ActionResult	Save()	{	}	


#Building Web APIs:
**RESTful Convention 
Request Description
GET /api/customers Get all customers
GET /api/customers/1 Get customer with ID 1
POST /api/customers Add a new customer (customer data in the request body)
PUT /api/customers/1 Update customer with ID 1 (customer data in the request body)
DELETE /api/customers/1 Delete customer with ID 1

*Building an API 

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

##AutoMapper
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

##Enabling camel casing
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
