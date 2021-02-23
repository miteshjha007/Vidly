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