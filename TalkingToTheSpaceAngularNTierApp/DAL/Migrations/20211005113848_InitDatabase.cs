using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_profile_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    user_point = table.Column<long>(type: "bigint", nullable: false),
                    user_creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 440, DateTimeKind.Utc).AddTicks(3708))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    message_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message_content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    message_status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    message_creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 451, DateTimeKind.Utc).AddTicks(8434)),
                    message_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    message_sent_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    User_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_message_user_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "reply",
                columns: table => new
                {
                    reply_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reply_content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    reply_status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    reply_creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 453, DateTimeKind.Utc).AddTicks(6205)),
                    reply_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    reply_sent_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    User_ID = table.Column<long>(type: "bigint", nullable: false),
                    Message_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reply", x => x.reply_id);
                    table.ForeignKey(
                        name: "FK_reply_message_Message_ID",
                        column: x => x.Message_ID,
                        principalTable: "message",
                        principalColumn: "message_id");
                    table.ForeignKey(
                        name: "FK_reply_user_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_message_User_ID",
                table: "message",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reply_Message_ID",
                table: "reply",
                column: "Message_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reply_User_ID",
                table: "reply",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reply");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
