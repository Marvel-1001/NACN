using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndAPI.Migrations
{
    public partial class NACN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberType",
                columns: table => new
                {
                    IdMembertype = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MemberTy__945542D342B5ADED", x => x.IdMembertype);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    IdMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMembertype = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Constituency = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PostalAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhysicalAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: true),
                    Cellphone = table.Column<int>(type: "int", nullable: true),
                    WorkNumber = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Disability = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Pensioner = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Learner = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Employed = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    StageName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ArtDiscipline = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    YearsInIndustry = table.Column<int>(type: "int", nullable: true),
                    PaymentMethod = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PaidMembership = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    OrgasinationName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FinancialYear = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Member__570E7FF0CEB48EC9", x => x.IdMember);
                    table.ForeignKey(
                        name: "FK__Member__IdMember__267ABA7A",
                        column: x => x.IdMembertype,
                        principalTable: "MemberType",
                        principalColumn: "IdMembertype");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_IdMembertype",
                table: "Member",
                column: "IdMembertype");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "MemberType");
        }
    }
}
