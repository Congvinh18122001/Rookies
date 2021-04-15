using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class InitCreated01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_BorrowingRequests_BorrowingRequestID",
                table: "RequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_Users_UserID",
                table: "RequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_RequestDetails_BorrowingRequestID",
                table: "RequestDetails");

            migrationBuilder.DropColumn(
                name: "BorrowingRequestID",
                table: "RequestDetails");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "RequestDetails",
                newName: "RequestID");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetails_UserID",
                table: "RequestDetails",
                newName: "IX_RequestDetails_RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_BorrowingRequests_RequestID",
                table: "RequestDetails",
                column: "RequestID",
                principalTable: "BorrowingRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_BorrowingRequests_RequestID",
                table: "RequestDetails");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "RequestDetails",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetails_RequestID",
                table: "RequestDetails",
                newName: "IX_RequestDetails_UserID");

            migrationBuilder.AddColumn<int>(
                name: "BorrowingRequestID",
                table: "RequestDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_BorrowingRequestID",
                table: "RequestDetails",
                column: "BorrowingRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_BorrowingRequests_BorrowingRequestID",
                table: "RequestDetails",
                column: "BorrowingRequestID",
                principalTable: "BorrowingRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_Users_UserID",
                table: "RequestDetails",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
