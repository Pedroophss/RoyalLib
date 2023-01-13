namespace RoyalLib.Infra.EntityFramework.Mappings;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalLib.Domain.Entities;

public class BookMap : IEntityTypeConfiguration<BookEntity>
{
    public static BookEntity[] InitialBooks = new BookEntity[]
    {
        new()
        {
            Id = 1,
            Title = "Pride and Prejudice",
            FirstName = "Jane",
            LastName = "Austen",
            TotalCopies = 100,
            CopiesInUse = 80,
            Type = "Hardcover",
            Isbn = "1234567891",
            Category = "Fiction",
        },
        new()
        {
            Id = 2,
            Title =  "To Kill a Mockingbird",
            FirstName =  "Harper",
            LastName =  "Lee",
            TotalCopies =  75,
            CopiesInUse =  65,
            Type =  "Paperback",
            Isbn =  "1234567892",
            Category =  "Fiction",
        },
        new()
        {
            Id = 3,
            Title = "The Catcher in the Rye",
            FirstName = "J.D.",
            LastName = "Salinger",
            TotalCopies = 50,
            CopiesInUse = 45,
            Type = "Hardcover",
            Isbn = "1234567893",
            Category = "Fiction",
        },
        new()
        {
            Id = 4,
            Title = "The Great Gatsby",
            FirstName = "F. Scott",
            LastName = "Fitzgerald",
            TotalCopies = 50,
            CopiesInUse = 22,
            Type = "Hardcover",
            Isbn = "1234567894",
            Category = "Non-Fiction",
        },
        new()
        {
            Id = 5,
            Title = "The Alchemist",
            FirstName = "Paulo",
            LastName = "Coelho",
            TotalCopies = 50,
            CopiesInUse = 35,
            Type = "Hardcover",
            Isbn = "1234567895",
            Category = "Biography",
        },
        new()
        {
            Id = 6,
            Title = "The Book Thief",
            FirstName = "Markus",
            LastName = "Zusak",
            TotalCopies = 75,
            CopiesInUse = 11,
            Type = "Hardcover",
            Isbn = "1234567896",
            Category = "Mystery",
        },
        new()
        {
            Id = 7,
            Title = "The Chronicles of Narnia",
            FirstName = "C.S.",
            LastName = "Lewis",
            TotalCopies = 100,
            CopiesInUse = 14,
            Type = "Paperback",
            Isbn = "1234567897",
            Category = "Sci-Fi",
        },
        new()
        {
            Id = 8,
            Title = "The Da Vinci Code",
            FirstName = "Dan",
            LastName = "Brown",
            TotalCopies = 50,
            CopiesInUse = 40,
            Type = "Paperback",
            Isbn = "1234567898",
            Category = "Sci-Fi",
        },
        new()
        {
            Id = 9,
            Title = "The Grapes of Wrath",
            FirstName = "John",
            LastName = "Steinbeck",
            TotalCopies = 50,
            CopiesInUse = 35,
            Type = "Hardcover",
            Isbn = "1234567899",
            Category = "Fiction",
        },
        new()   
        {
            Id = 10,
            Title = "The Hitchhiker's Guide to the Galaxy",
            FirstName = "Douglas",
            LastName = "Adams",
            TotalCopies = 50,
            CopiesInUse = 35,
            Type = "Paperback",
            Isbn = "1234567900",
            Category = "Non-Fiction",
        },
        new()
        { 
            Id = 11,
            Title = "Moby-Dick",
            FirstName = "Herman",
            LastName = "Melville",
            TotalCopies = 30,
            CopiesInUse = 8,
            Type = "Hardcover",
            Isbn = "8901234567",
            Category = "Fiction",
        },
        new()
        {
            Id = 12,
            Title = "To Kill a Mockingbird",
            FirstName = "Harper",
            LastName = "Lee",
            TotalCopies = 20,
            CopiesInUse = 0,
            Type = "Paperback",
            Isbn = "9012345678",
            Category = "Non-Fiction",
        },
        new()
        {
            Id = 13,
            Title = "The Catcher in the Rye",
            FirstName = "J.D.",
            LastName = "Salinger",
            TotalCopies = 10,
            CopiesInUse = 1,
            Type = "Hardcover",
            Isbn = "0123456789",
            Category = "Non-Fiction",
        },
    };

    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.ToTable("books");

        builder.HasKey(x => x.Id);
        builder.Property(f => f.Id)
               .HasColumnName("book_id")
               .HasColumnType("int")
               .UseIdentityColumn();

        builder.Property(p => p.Title)
               .HasColumnName("title")
               .HasColumnType("varchar(100)")
               .HasMaxLength(100);

        builder.Property(p => p.FirstName)
               .HasColumnName("first_name")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.Property(p => p.FirstName)
               .HasColumnName("first_name")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.Property(p => p.LastName)
               .HasColumnName("last_name")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.Property(p => p.TotalCopies)
               .HasColumnName("total_copies")
               .HasDefaultValue(0);

        builder.Property(p => p.CopiesInUse)
               .HasColumnName("copies_in_use")
               .HasDefaultValue(0);

        builder.Property(p => p.Type)
               .HasColumnName("type")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.Property(p => p.Isbn)
               .HasColumnName("isbn")
               .HasColumnType("varchar(80)")
               .HasMaxLength(80);

        builder.Property(p => p.Category)
               .HasColumnName("category")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.HasIndex(b => b.Isbn)
               .IsUnique()
               .HasDatabaseName("books_isbn_idx");

        builder.HasIndex(b => b.Title)
               .HasDatabaseName("books_title_idx");

        builder.HasData(InitialBooks);
    }
}
