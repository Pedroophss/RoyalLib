using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalLib.Infra.Migrations
{
    public partial class books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    total_copies = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    copies_in_use = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    isbn = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.book_id);
                });

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
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
