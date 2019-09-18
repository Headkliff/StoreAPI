using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Store.Entity.Models;

namespace Store.Entity.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "" },
            //    values: new object[] { new User { Id = 1, Nickname = "test1", CreateDateTime = DateTime.Now} }

            //    );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
