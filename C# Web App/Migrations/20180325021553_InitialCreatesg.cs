using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HomeDecor.Migrations
{
    public partial class InitialCreatesg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccessRights",
                table: "UserRegistration",
                newName: "AccessRights1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccessRights1",
                table: "UserRegistration",
                newName: "AccessRights");
        }
    }
}
