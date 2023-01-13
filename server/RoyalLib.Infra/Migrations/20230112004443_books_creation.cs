using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalLib.Infra.Migrations
{
    public partial class books_creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "books");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "books",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "books",
                newName: "isbn");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "books",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "TotalCopies",
                table: "books",
                newName: "total_copies");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "books",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "books",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CopiesInUse",
                table: "books",
                newName: "copies_in_use");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "books",
                newName: "book_id");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "books",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "books",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                table: "books",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "books",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "total_copies",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "books",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "books",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "copies_in_use",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "book_id");

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "book_id", "category", "copies_in_use", "first_name", "isbn", "last_name", "title", "total_copies", "type" },
                values: new object[,]
                {
                    { 1, "Fiction", 80, "Jane", "1234567891", "Austen", "Pride and Prejudice", 100, "Hardcover" },
                    { 2, "Fiction", 65, "Harper", "1234567892", "Lee", "To Kill a Mockingbird", 75, "Paperback" },
                    { 3, "Fiction", 45, "J.D.", "1234567893", "Salinger", "The Catcher in the Rye", 50, "Hardcover" },
                    { 4, "Non-Fiction", 22, "F. Scott", "1234567894", "Fitzgerald", "The Great Gatsby", 50, "Hardcover" },
                    { 5, "Biography", 35, "Paulo", "1234567895", "Coelho", "The Alchemist", 50, "Hardcover" },
                    { 6, "Mystery", 11, "Markus", "1234567896", "Zusak", "The Book Thief", 75, "Hardcover" },
                    { 7, "Sci-Fi", 14, "C.S.", "1234567897", "Lewis", "The Chronicles of Narnia", 100, "Paperback" },
                    { 8, "Sci-Fi", 40, "Dan", "1234567898", "Brown", "The Da Vinci Code", 50, "Paperback" },
                    { 9, "Fiction", 35, "John", "1234567899", "Steinbeck", "The Grapes of Wrath", 50, "Hardcover" },
                    { 10, "Non-Fiction", 35, "Douglas", "1234567900", "Adams", "The Hitchhiker's Guide to the Galaxy", 50, "Paperback" },
                    { 11, "Fiction", 8, "Herman", "8901234567", "Melville", "Moby-Dick", 30, "Hardcover" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "book_id", "category", "first_name", "isbn", "last_name", "title", "total_copies", "type" },
                values: new object[] { 12, "Non-Fiction", "Harper", "9012345678", "Lee", "To Kill a Mockingbird", 20, "Paperback" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "book_id", "category", "copies_in_use", "first_name", "isbn", "last_name", "title", "total_copies", "type" },
                values: new object[] { 13, "Non-Fiction", 1, "J.D.", "0123456789", "Salinger", "The Catcher in the Rye", 10, "Hardcover" });

            migrationBuilder.CreateIndex(
                name: "books_isbn_idx",
                table: "books",
                column: "isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "books_title_idx",
                table: "books",
                column: "title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropIndex(
                name: "books_isbn_idx",
                table: "books");

            migrationBuilder.DropIndex(
                name: "books_title_idx",
                table: "books");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13);

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Books",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "isbn",
                table: "Books",
                newName: "Isbn");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Books",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "total_copies",
                table: "Books",
                newName: "TotalCopies");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Books",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Books",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "copies_in_use",
                table: "Books",
                newName: "CopiesInUse");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "Books",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "TotalCopies",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CopiesInUse",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }
    }
}
