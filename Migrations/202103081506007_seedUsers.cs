namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'792442d3-3c1c-4ff5-afcb-f0ac4e593b38', N'testarcs1@gmail.com', 0, N'ALARd4b2k9GnnJFno1TJYLqcJnkm6soAwm8GGMIymQ4yFtMqCJhqN0G5gdlXU08nhw==', N'fb193802-a918-4ef7-b890-dbea55c9ffa8', NULL, 0, 0, NULL, 1, 0, N'testarcs1@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'966b957b-b52d-46e4-bcbe-2c32272dca9f', N'cool.miteshjha@gmail.com', 0, N'AHYQw2LjkqyzXpNV2CW8eNvNX3aW3AFk4aGYciWL0IjFESXvaC2ZJAgUc+2Uur44VQ==', N'e8862e4f-4e0a-474d-8499-04989848206c', NULL, 0, 0, NULL, 1, 0, N'cool.miteshjha@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6a44dd84-57c2-4ad6-94ee-2420131caac3', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'792442d3-3c1c-4ff5-afcb-f0ac4e593b38', N'6a44dd84-57c2-4ad6-94ee-2420131caac3')
");
        } 
        
        public override void Down()
        {
        }
    }
}
