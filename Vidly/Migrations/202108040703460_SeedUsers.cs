namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'03b240c1-9ac7-423a-9c28-42260d0ddb66', N'nhoxpiin2306@gmail.com', 0, N'AMMB0g34NpH4FQIH9ZJJwQMAF/476LB6Yux/JWfyDpepJhK5JI6oz+mD/oTmX6gLyg==', N'e41c311e-7840-4222-a096-8858df58b759', NULL, 0, 0, NULL, 1, 0, N'nhoxpiin2306@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2542d54-d280-4b90-bebe-30bfcd9b8e1f', N'ngocthien2306@gmail.com', 0, N'AHp0HOKhUKtcMdVpBFn5ucFd0QkRxUUBFmK4WkABSD35SsscQ1NQ9OadN22tkF/ykg==', N'c69a3643-4c16-4d98-b7b9-74d2128cb41c', NULL, 0, 0, NULL, 1, 0, N'ngocthien2306@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7ea44188-c461-44ac-91c5-0c9e8c4f11c1', N'CanManagerMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd2542d54-d280-4b90-bebe-30bfcd9b8e1f', N'7ea44188-c461-44ac-91c5-0c9e8c4f11c1')

");
        }
        
        public override void Down()
        {

        }
    }
}
