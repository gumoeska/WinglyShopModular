using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinglyShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changing_Role_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3213E83F89EE8816", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    access = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3213E83FD2A0C535", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    hasStock = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    idCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3213E83FE8651353", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.idCategory,
                        principalTable: "Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    surname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    image = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    phone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    idRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3213E83F93B1F8BB", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.idRole,
                        principalTable: "Roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    postalCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Address__3213E83F9BF396CD", x => x.id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3213E83FC0727DE4", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carts_Users",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<int>(type: "int", nullable: true),
                    orderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    paymentMethod = table.Column<int>(type: "int", nullable: true),
                    totalValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__3213E83F9A3D929F", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Users",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    idCart = table.Column<int>(type: "int", nullable: true),
                    idProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartDeta__3213E83F29BC9089", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts",
                        column: x => x.idCart,
                        principalTable: "Cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Products",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    idOrder = table.Column<int>(type: "int", nullable: true),
                    idProduct = table.Column<int>(type: "int", nullable: true),
                    idAddress = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3213E83FD22EA4EA", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Addresses",
                        column: x => x.idAddress,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.idOrder,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_idUser",
                table: "Address",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_idUser",
                table: "Cart",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_idCart",
                table: "CartDetail",
                column: "idCart");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_idProduct",
                table: "CartDetail",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Order_idUser",
                table: "Order",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_idAddress",
                table: "OrderDetail",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_idOrder",
                table: "OrderDetail",
                column: "idOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_idProduct",
                table: "OrderDetail",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idCategory",
                table: "Product",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_User_idRole",
                table: "User",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "UQ__User__7838F272EEAE83E7",
                table: "User",
                column: "login",
                unique: true,
                filter: "[login] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
