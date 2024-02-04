using FluentMigrator;

namespace Migrations;

[Migration(202402021315)]
public class _202402021315_IntionalTables : Migration
{
    public override void Up()
    {
        Create.Table("User").WithColumn("Id").AsInt32().PrimaryKey()
            .Identity().WithColumn("Name").AsAnsiString().NotNullable();


        Create.Table("Author").WithColumn("Id").AsInt32().PrimaryKey()
            .Identity().WithColumn("Name").AsAnsiString().NotNullable();

        Create.Table("Genre").WithColumn("Id").AsInt32().PrimaryKey()
            .Identity().WithColumn("Name").AsAnsiString().NotNullable();

        Create.Table("Book").WithColumn("Id").AsInt32().PrimaryKey()
            .Identity().WithColumn("Name").AsAnsiString().NotNullable()
            .WithColumn("Count").AsInt32().Nullable()
            .WithDefaultValue(0).WithColumn("Publication")
            .AsAnsiString().NotNullable().WithColumn("AuthorId").AsInt32()
            .Nullable().ForeignKey("FK_Book_Author", "Author", "Id")
            .WithColumn("GenreId").AsInt32().Nullable()
            .ForeignKey("FK_Book_Genre", "Genre", "Id");


        Create.Table("RentBook").WithColumn("Id").AsInt32().PrimaryKey()
            .Identity().WithColumn("IsBack").AsBoolean()
            .WithDefaultValue(false).WithColumn("UserId").AsInt32()
            .NotNullable()
            .ForeignKey("FK_RentBook_User", "User", "Id")
            .WithColumn("BookId").AsInt32().NotNullable()
            .ForeignKey("FK_RentBook_Book", "Book", "Id");
    }

    public override void Down()
    {
    }
}