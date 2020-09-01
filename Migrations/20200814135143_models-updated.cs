using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VEMS.Migrations
{
    public partial class modelsupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Options_OptionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserExams_UserExamId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Users_ApplicationUserId",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExamId",
                table: "UserExams",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "UserExams",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserExamId",
                table: "UserAnswers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OptionId",
                table: "UserAnswers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Options_OptionId",
                table: "UserAnswers",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserExams_UserExamId",
                table: "UserAnswers",
                column: "UserExamId",
                principalTable: "UserExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Users_ApplicationUserId",
                table: "UserExams",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Options_OptionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserExams_UserExamId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Users_ApplicationUserId",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExamId",
                table: "UserExams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "UserExams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserExamId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "OptionId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Options_OptionId",
                table: "UserAnswers",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserExams_UserExamId",
                table: "UserAnswers",
                column: "UserExamId",
                principalTable: "UserExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Users_ApplicationUserId",
                table: "UserExams",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
