using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_sketches_SketchId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sketches",
                table: "sketches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Petition",
                table: "Petition");

            migrationBuilder.RenameTable(
                name: "Petition",
                newName: "Petitions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sketches",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipients",
                newName: "RecipientId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Petitions",
                newName: "sketchesSketchId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "sketches",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "SketchId",
                table: "sketches",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "DocumentationID",
                table: "sketches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "sketchesSketchId",
                table: "Petitions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PetitionId",
                table: "Petitions",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sketches",
                table: "sketches",
                column: "SketchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Petitions",
                table: "Petitions",
                column: "PetitionId");

            migrationBuilder.CreateTable(
                name: "Documentation",
                columns: table => new
                {
                    DocumentationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentation", x => x.DocumentationID);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    SupportID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    anonymous = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PetitionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.SupportID);
                    table.ForeignKey(
                        name: "FK_Supports_Petitions_PetitionId",
                        column: x => x.PetitionId,
                        principalTable: "Petitions",
                        principalColumn: "PetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToWho",
                columns: table => new
                {
                    toWhoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SketchId = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToWho", x => x.toWhoId);
                    table.ForeignKey(
                        name: "FK_ToWho_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "RecipientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToWho_sketches_SketchId",
                        column: x => x.SketchId,
                        principalTable: "sketches",
                        principalColumn: "SketchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sketches_DocumentationID",
                table: "sketches",
                column: "DocumentationID");

            migrationBuilder.CreateIndex(
                name: "IX_sketches_UserId",
                table: "sketches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_sketchesSketchId",
                table: "Petitions",
                column: "sketchesSketchId");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_PetitionId",
                table: "Supports",
                column: "PetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_UserId",
                table: "Supports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToWho_RecipientId",
                table: "ToWho",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ToWho_SketchId",
                table: "ToWho",
                column: "SketchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_userId",
                table: "Comments",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_sketches_SketchId",
                table: "Comments",
                column: "SketchId",
                principalTable: "sketches",
                principalColumn: "SketchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_sketches_sketchesSketchId",
                table: "Petitions",
                column: "sketchesSketchId",
                principalTable: "sketches",
                principalColumn: "SketchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sketches_Documentation_DocumentationID",
                table: "sketches",
                column: "DocumentationID",
                principalTable: "Documentation",
                principalColumn: "DocumentationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sketches_Users_UserId",
                table: "sketches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_userId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_sketches_SketchId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_sketches_sketchesSketchId",
                table: "Petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_sketches_Documentation_DocumentationID",
                table: "sketches");

            migrationBuilder.DropForeignKey(
                name: "FK_sketches_Users_UserId",
                table: "sketches");

            migrationBuilder.DropTable(
                name: "Documentation");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "ToWho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sketches",
                table: "sketches");

            migrationBuilder.DropIndex(
                name: "IX_sketches_DocumentationID",
                table: "sketches");

            migrationBuilder.DropIndex(
                name: "IX_sketches_UserId",
                table: "sketches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_userId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Petitions",
                table: "Petitions");

            migrationBuilder.DropIndex(
                name: "IX_Petitions_sketchesSketchId",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "SketchId",
                table: "sketches");

            migrationBuilder.DropColumn(
                name: "DocumentationID",
                table: "sketches");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PetitionId",
                table: "Petitions");

            migrationBuilder.RenameTable(
                name: "Petitions",
                newName: "Petition");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "sketches",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Recipients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sketchesSketchId",
                table: "Petition",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "sketches",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Petition",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sketches",
                table: "sketches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Petition",
                table: "Petition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_sketches_SketchId",
                table: "Comments",
                column: "SketchId",
                principalTable: "sketches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
