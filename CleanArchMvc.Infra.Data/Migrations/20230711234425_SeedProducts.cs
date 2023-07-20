using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Products(Name,Description,Price,Stock,Image,CategoryId)" +
                "VALUES('Carderno de Matemática','Caderno de Matemática com 300 folhas capa dura',15.89,40,'cadernoMatematica.png',1)");

            mb.Sql("insert into Products(Name,Description,Price,Stock,Image,CategoryId)" +
                "VALUES('Iphone 10','Iphone 10 5gb',3500,10,'iphone10.png',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE from Products");
        }
    }
}
