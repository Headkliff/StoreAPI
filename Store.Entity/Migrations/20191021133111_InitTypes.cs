﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class InitTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] {"Name", "CreateDateTime" },
                values: new object[] {"Brick", DateTime.UtcNow}
            );
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Abrasive", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Bathrooms", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Concrete mixers", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Furniture for home", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Decorative rock", DateTime.UtcNow }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}