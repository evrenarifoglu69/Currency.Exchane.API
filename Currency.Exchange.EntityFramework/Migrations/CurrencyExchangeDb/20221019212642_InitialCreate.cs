using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currency.Exchange.EntityFramework.Migrations.CurrencyExchangeDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ToCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "AED", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9804), false, null, null, "UAE dirham	" },
                    { 2, "AFN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9812), false, null, null, "Afghan afghani" },
                    { 3, "ALL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9813), false, null, null, "Albanian lek" },
                    { 4, "AMD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9815), false, null, null, "Armenian dram " },
                    { 6, "ANG", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9816), false, null, null, "Netherlands Antillean guilder " },
                    { 7, "AOA", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9817), false, null, null, "Angolan kwanza" },
                    { 8, "ARS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9818), false, null, null, "Argentine peso" },
                    { 9, "AUD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9820), false, null, null, "Australian dollar " },
                    { 10, "AWG", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9821), false, null, null, "Aruban florin " },
                    { 11, "AZN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9822), false, null, null, "Azerbaijan manat" },
                    { 12, "BAM", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9823), false, null, null, "Bosnia and Herzegovina convertible mark " },
                    { 13, "BBD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9824), false, null, null, "Barbadian dollar" },
                    { 14, "BDT", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9826), false, null, null, "Bangladeshi taka" },
                    { 15, "BGN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9827), false, null, null, "Bulgarian lev " },
                    { 16, "BHD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9828), false, null, null, "Bahraini dinar" },
                    { 17, "BIF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9829), false, null, null, "Burundi franc " },
                    { 18, "BMD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9830), false, null, null, "Bermudian dollar" },
                    { 19, "BND", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9832), false, null, null, "Brunei dollar " },
                    { 20, "BOB", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9833), false, null, null, "Bolivian boliviano" },
                    { 21, "BRL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9834), false, null, null, "Brazilian real" },
                    { 22, "BSD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9835), false, null, null, "Bahamian dollar " },
                    { 23, "BTN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9837), false, null, null, "Bhutanese ngultrum" },
                    { 24, "BWP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9838), false, null, null, "Botswana pula " },
                    { 25, "BYN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9839), false, null, null, "Belarusian ruble" },
                    { 26, "BZD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9840), false, null, null, "Belize dollar " },
                    { 27, "CAD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9841), false, null, null, "Canadian dollar " },
                    { 28, "CDF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9843), false, null, null, "Congolese franc " },
                    { 29, "CHF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9844), false, null, null, "Swiss franc " },
                    { 30, "CLP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9845), false, null, null, "Chilean peso" },
                    { 31, "CNY", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9846), false, null, null, "Chinese Yuan Renminbi " },
                    { 32, "COP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9847), false, null, null, "Colombian peso" },
                    { 33, "CRC", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9849), false, null, null, "Costa Rican colon " },
                    { 34, "CUP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9850), false, null, null, "Cuban peso" },
                    { 35, "CVE", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9851), false, null, null, "Cabo Verdean escudo " },
                    { 36, "CZK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9852), false, null, null, "Czech koruna" },
                    { 37, "DJF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9853), false, null, null, "Djiboutian franc" },
                    { 38, "DKK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9855), false, null, null, "Danish krone" },
                    { 39, "DOP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9856), false, null, null, "Dominican peso" },
                    { 40, "DZD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9857), false, null, null, "Algerian dinar" },
                    { 41, "EGP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9858), false, null, null, "Egyptian pound" },
                    { 42, "ERN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9859), false, null, null, "Eritrean nakfa" },
                    { 43, "ETB", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9861), false, null, null, "Ethiopian birr" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 44, "EUR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9862), false, null, null, "European euro " },
                    { 45, "FJD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9863), false, null, null, "Fijian dollar " },
                    { 46, "FKP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9864), false, null, null, "Falkland Islands pound" },
                    { 47, "GBP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9865), false, null, null, "Pound sterling" },
                    { 48, "GEL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9867), false, null, null, "Georgian lari " },
                    { 49, "GGP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9868), false, null, null, "Guernsey Pound" },
                    { 50, "GHS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9869), false, null, null, "Ghanaian cedi " },
                    { 51, "GIP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9870), false, null, null, "Gibraltar pound " },
                    { 52, "GMD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9871), false, null, null, "Gambian dalasi" },
                    { 53, "GNF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9872), false, null, null, "Guinean franc " },
                    { 54, "GTQ", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9874), false, null, null, "Guatemalan quetzal" },
                    { 55, "GYD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9875), false, null, null, "Guyanese dollar " },
                    { 56, "HKD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9876), false, null, null, "Hong Kong dollar" },
                    { 57, "HNL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9877), false, null, null, "Honduran lempira" },
                    { 58, "HRK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9878), false, null, null, "Croatian kuna " },
                    { 59, "HTG", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9880), false, null, null, "Haitian gourde" },
                    { 60, "HUF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9881), false, null, null, "Hungarian forint" },
                    { 61, "IDR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9882), false, null, null, "Indonesian rupiah " },
                    { 62, "ILS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9883), false, null, null, "Israeli new shekel" },
                    { 63, "ILS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9884), false, null, null, "Israeli new shekel" },
                    { 64, "IMP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9886), false, null, null, "Manx pound" },
                    { 65, "INR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9887), false, null, null, "Indian rupee" },
                    { 66, "IQD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9888), false, null, null, "Iraqi dinar " },
                    { 67, "IRR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9889), false, null, null, "Iranian rial" },
                    { 68, "ISK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9890), false, null, null, "Icelandic krona " },
                    { 69, "JEP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9892), false, null, null, "Jersey pound" },
                    { 70, "JMD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9893), false, null, null, "Jamaican dollar " },
                    { 71, "JOD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9922), false, null, null, "Jordanian dinar " },
                    { 72, "JPY", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9923), false, null, null, "Japanese yen" },
                    { 73, "KES", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9924), false, null, null, "Kenyan shilling " },
                    { 74, "KGS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9925), false, null, null, "Kyrgyzstani som " },
                    { 75, "KHR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9927), false, null, null, "Cambodian riel" },
                    { 76, "KMF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9928), false, null, null, "Comorian franc" },
                    { 77, "KPW", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9929), false, null, null, "North Korean won" },
                    { 78, "KRW", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9930), false, null, null, "South Korean won" },
                    { 79, "KWD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9931), false, null, null, "Kuwaiti dinar " },
                    { 80, "KYD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9932), false, null, null, "Cayman Islands dollar " },
                    { 81, "KZT", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9934), false, null, null, "Kazakhstani tenge " },
                    { 82, "LAK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9935), false, null, null, "Lao kip " },
                    { 83, "LBP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9936), false, null, null, "Lebanese pound" },
                    { 84, "LKR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9937), false, null, null, "Sri Lankan rupee" },
                    { 85, "LRD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9938), false, null, null, "Liberian dollar " }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 86, "LSL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9939), false, null, null, "Lesotho loti" },
                    { 87, "LYD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9941), false, null, null, "Libyan dinar" },
                    { 88, "MAD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9942), false, null, null, "Moroccan dirham " },
                    { 89, "MDL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9943), false, null, null, "Moldovan leu" },
                    { 90, "MGA", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9944), false, null, null, "Malagasy ariary " },
                    { 91, "MKD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9945), false, null, null, "Macedonian denar" },
                    { 92, "MMK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9946), false, null, null, "Myanmar kyat" },
                    { 93, "MNT", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9948), false, null, null, "Mongolian tugrik" },
                    { 94, "MOP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9949), false, null, null, "Macanese pataca " },
                    { 95, "MRU", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9950), false, null, null, "Mauritanian ouguiya " },
                    { 96, "MUR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9951), false, null, null, "Mauritian rupee " },
                    { 97, "MVR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9952), false, null, null, "Maldivian rufiyaa " },
                    { 98, "MWK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9954), false, null, null, "Malawian kwacha " },
                    { 99, "MXN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9955), false, null, null, "Mexican peso" },
                    { 100, "MYR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9956), false, null, null, "Malaysian ringgit " },
                    { 101, "MZN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9957), false, null, null, "Mozambican metical" },
                    { 102, "NAD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9958), false, null, null, "Namibian dollar " },
                    { 103, "NGN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9960), false, null, null, "Nigerian naira" },
                    { 104, "NIO", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9961), false, null, null, "Nicaraguan cordoba" },
                    { 105, "NOK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9962), false, null, null, "Norwegian krone " },
                    { 106, "NOK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9963), false, null, null, "Norwegian krone " },
                    { 109, "NPR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9964), false, null, null, "Nepalese rupee" },
                    { 110, "NZD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9965), false, null, null, "New Zealand dollar" },
                    { 111, "OMR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9967), false, null, null, "Omani rial" },
                    { 112, "PEN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9968), false, null, null, "Peruvian sol" },
                    { 113, "PGK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9969), false, null, null, "Papua New Guinean kina" },
                    { 114, "PHP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9970), false, null, null, "Philippine peso " },
                    { 115, "PKR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9971), false, null, null, "Pakistani rupee " },
                    { 116, "PLN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9973), false, null, null, "Polish zloty" },
                    { 117, "PYG", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9974), false, null, null, "Paraguayan guarani" },
                    { 118, "RSD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9975), false, null, null, "Serbian dinar " },
                    { 119, "RUB", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9976), false, null, null, "Russian ruble " },
                    { 120, "RWF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9977), false, null, null, "Rwandan franc " },
                    { 121, "SAR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9978), false, null, null, "Saudi Arabian riyal " },
                    { 122, "SBD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9980), false, null, null, "Solomon Islands dollar" },
                    { 123, "SCR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9981), false, null, null, "Seychellois rupee " },
                    { 124, "SDG", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9982), false, null, null, "Sudanese pound" },
                    { 125, "SEK", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9983), false, null, null, "Swedish krona " },
                    { 126, "SGD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9984), false, null, null, "Singapore dollar" },
                    { 127, "SHP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9986), false, null, null, "Saint Helena pound" },
                    { 128, "SLL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9987), false, null, null, "Sierra Leonean leone" },
                    { 129, "SOS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9988), false, null, null, "Somali shilling " }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 130, "SRD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9989), false, null, null, "Surinamese dollar " },
                    { 131, "SSP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9990), false, null, null, "South Sudanese pound" },
                    { 132, "STN", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9992), false, null, null, "Sao Tome and Principe dobra " },
                    { 133, "SYP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9993), false, null, null, "Syrian pound" },
                    { 134, "SZL", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9994), false, null, null, "Swazi lilangeni " },
                    { 135, "TJS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9995), false, null, null, "Tajikistani somoni" },
                    { 136, "TMT", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9996), false, null, null, "Turkmen manat " },
                    { 137, "TND", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9997), false, null, null, "Tunisian dinar" },
                    { 138, "TOP", "1", new DateTime(2022, 10, 20, 0, 26, 41, 919, DateTimeKind.Local).AddTicks(9998), false, null, null, "Tongan pa’anga" },
                    { 139, "TRY", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local), false, null, null, "Turkish lira" },
                    { 140, "TTD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(1), false, null, null, "Trinidad and Tobago dollar" },
                    { 141, "TWD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(2), false, null, null, "New Taiwan dollar " },
                    { 142, "TZS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(3), false, null, null, "Tanzanian shilling" },
                    { 143, "UAH", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(4), false, null, null, "Ukrainian hryvnia " },
                    { 144, "USD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(5), false, null, null, "United States dollar" },
                    { 145, "UZS", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(7), false, null, null, "Uzbekistani som " },
                    { 146, "VES", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(8), false, null, null, "Venezuelan bolivar" },
                    { 147, "VND", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(9), false, null, null, "Vietnamese dong " },
                    { 148, "VUV", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(10), false, null, null, "Vanuatu vatu" },
                    { 149, "WST", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(11), false, null, null, "Samoan tala " },
                    { 150, "XAF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(12), false, null, null, "Central African CFA franc " },
                    { 151, "XCD", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(14), false, null, null, "East Caribbean dollar " },
                    { 152, "XDR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(15), false, null, null, "SDR (Special Drawing Right) " },
                    { 153, "XOF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(16), false, null, null, "West African CFA franc" },
                    { 154, "XPF", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(17), false, null, null, "CFP franc " },
                    { 155, "YER", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(18), false, null, null, "Yemeni rial " },
                    { 156, "ZAR", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(20), false, null, null, "South African rand" },
                    { 157, "ZMW", "1", new DateTime(2022, 10, 20, 0, 26, 41, 920, DateTimeKind.Local).AddTicks(21), false, null, null, "Zambian kwacha" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
