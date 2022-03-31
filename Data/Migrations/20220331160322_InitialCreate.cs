using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReqSystem.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IsBilling = table.Column<bool>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsAnnual = table.Column<bool>(nullable: false),
                    BudgetCodeNumber = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colleges_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colleges_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colleges_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SemesterId = table.Column<int>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fees_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ReqUserId = table.Column<string>(nullable: true),
                    CollegeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Divisions_AspNetUsers_ReqUserId",
                        column: x => x.ReqUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DivisionId = table.Column<int>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    VendorCode = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Department_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ReqUserId = table.Column<string>(nullable: true),
                    BudgetId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitions_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisitions_AspNetUsers_ReqUserId",
                        column: x => x.ReqUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisitions_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    RequisitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ItemNumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    NumberInStock = table.Column<int>(nullable: false),
                    SuggestedVendorId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    RequisitionId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Vendors_SuggestedVendorId",
                        column: x => x.SuggestedVendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PricePerUnit = table.Column<double>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    CollegeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateContracts_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateContracts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_DepartmentId",
                table: "AcademicPrograms",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_AddressId",
                table: "Colleges",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_BudgetId",
                table: "Colleges",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_SemesterId",
                table: "Colleges",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequisitionId",
                table: "Comments",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_BudgetId",
                table: "Department",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DivisionId",
                table: "Department",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CollegeId",
                table: "Divisions",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ReqUserId",
                table: "Divisions",
                column: "ReqUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_BudgetId",
                table: "Fees",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_SemesterId",
                table: "Fees",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RequisitionId",
                table: "Items",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SuggestedVendorId",
                table: "Items",
                column: "SuggestedVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_BudgetId",
                table: "Requisitions",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_ReqUserId",
                table: "Requisitions",
                column: "ReqUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_VendorId",
                table: "Requisitions",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_StateContracts_CollegeId",
                table: "StateContracts",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateContracts_ItemId",
                table: "StateContracts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_AddressId",
                table: "Vendors",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "StateContracts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "AspNetUsers");
        }
    }
}
