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
		