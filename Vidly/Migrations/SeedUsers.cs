namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5c90d91c-a859-4532-aa39-82719b963ff4', N'guest@gmail.com', 0, N'AGTPPIYeNmUDVip/uCopLDV6KDnYLuXxZYBcSA9ifKVlwufMbc1WaWwzqvugdRBjYw==', N'5d5d647d-ca56-405e-8129-45f892d85eb7', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd3955c52-a083-41df-b5a3-0a7ffced5d6e', N'admin@vidly.com', 0, N'AG9amDdB64twVrSXmP4HRL9IKaSbqhatkN+Rcuvpmdbb/zIL5J/uceAvS9vsGY7NFA==', N'6eff1845-f175-4b0c-ae00-0b6d200feb15', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8eec5bd0-01d4-49b8-8d2a-90d46f43ac12', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd3955c52-a083-41df-b5a3-0a7ffced5d6e', N'8eec5bd0-01d4-49b8-8d2a-90d46f43ac12')
");
        }
        
        public override void Down()
        {
        }
    }
}
