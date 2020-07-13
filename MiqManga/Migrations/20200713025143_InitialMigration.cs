using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiqManga.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FreeWalls",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeWalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostType",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 2048, nullable: true),
                    PasswordSalt = table.Column<string>(maxLength: 2048, nullable: true),
                    Role = table.Column<byte>(nullable: false),
                    AvatarPath = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    PosterPath = table.Column<string>(maxLength: 255, nullable: true),
                    CoverPath = table.Column<string>(maxLength: 255, nullable: true),
                    Rating = table.Column<double>(nullable: true),
                    Language = table.Column<byte>(nullable: true),
                    OwnerId = table.Column<long>(nullable: true),
                    PostTypeId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_PostType_PostTypeId",
                        column: x => x.PostTypeId,
                        principalTable: "PostType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    Path = table.Column<string>(maxLength: 256, nullable: true),
                    PostId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    OwnerId = table.Column<long>(nullable: true),
                    Content = table.Column<string>(maxLength: 1024, nullable: true),
                    IsSpoiler = table.Column<byte>(nullable: true),
                    ParentId = table.Column<long>(nullable: false),
                    ParentTypeId = table.Column<long>(nullable: true),
                    ChapterId = table.Column<long>(nullable: true),
                    FreeWallId = table.Column<long>(nullable: true),
                    PostId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_FreeWalls_FreeWallId",
                        column: x => x.FreeWallId,
                        principalTable: "FreeWalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_ParentType_ParentTypeId",
                        column: x => x.ParentTypeId,
                        principalTable: "ParentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "DateAdd(HOUR, 3, GetUtcDate())"),
                    IsDeleted = table.Column<byte>(nullable: true, defaultValueSql: "0"),
                    Path = table.Column<string>(maxLength: 255, nullable: true),
                    ChapterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_PostId",
                table: "Chapters",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ChapterId",
                table: "Comments",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FreeWallId",
                table: "Comments",
                column: "FreeWallId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentTypeId",
                table: "Comments",
                column: "ParentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ChapterId",
                table: "Pages",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OwnerId",
                table: "Posts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostTypeId",
                table: "Posts",
                column: "PostTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "FreeWalls");

            migrationBuilder.DropTable(
                name: "ParentType");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PostType");
        }
    }
}
