using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCodeFirst.Migrations
{
    public partial class FillTablesEmployeeOfficeEmployeeProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO " +
                "Office (Title, Location) " +
                "VALUES " +
                "('Main', 'USA'), " +
                "('Euro', 'Ukraine'), " +
                "('Asia', 'China')");

            migrationBuilder.Sql(
                "SET IDENTITY_INSERT Title On " +
                "INSERT INTO " +
                "Title (TitleId, Name) " +
                "VALUES " +
                "(1, 'Chief Executive Officer'), " +
                "(2, 'Vice President of Engineering'), " +
                "(3, 'Engineering Manager'), " +
                "(4, 'Senior Tool Designer'), " +
                "(5, 'Design Engineer'), " +
                "(6, 'Research and Development Manager'), " +
                "(7, 'Research and Development Engineer'), " +
                "(8, 'Production Technician - WC60')");

            migrationBuilder.Sql(
                "INSERT INTO " +
                "Employee (FirstName, LastName, HiredDate, DateOfBirth, OfficeId, TitleId) " +
                "VALUES " +
                "('Ken', 'Sanchez', '2014-11-23', NULL, (SELECT OfficeId FROM Office WHERE Title = 'Main'), 1), " +
                "('Terri', 'Duffy', '2017-10-10', '1980-11-23',  (SELECT OfficeId FROM Office WHERE Title = 'Asia'), 5), " +
                "('Roberto', 'Tamburello', '2015-01-10', '1982-11-23',  (SELECT OfficeId FROM Office WHERE Title = 'Euro'), 4), " +
                "('Rob ', 'Walters', '2013-01-10', NULL, (SELECT OfficeId FROM Office WHERE Title = 'Main'), 3), " +
                "('Gail', 'Erickson', '2012-05-13', '1985-11-23', (SELECT OfficeId FROM Office WHERE Title = 'Asia'), 3), " +
                "('Jossef', 'Goldberg', '2011-11-29', '1987-11-23', (SELECT OfficeId FROM Office WHERE Title = 'Main'), 4), " +
                "('Dylan', 'Miller', '2009-06-22', '1989-11-23', (SELECT OfficeId FROM Office WHERE Title = 'Euro'), 5), " +
                "('Diane', 'Margheim', '2011-11-10', '1991-12-13', (SELECT OfficeId FROM Office WHERE Title = 'Asia'), 2), " +
                "('Gigi ', 'Matthew', '2013-07-09', '1983-11-23', (SELECT OfficeId FROM Office WHERE Title = 'Euro'), 5), " +
                "('Michael', 'Raheem', '2014-06-14', '1981-11-23', (SELECT OfficeId FROM Office WHERE Title = 'Main'), 5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               "DELETE FROM Office");

            migrationBuilder.Sql(
               "DELETE FROM Title");

            migrationBuilder.Sql(
               "DELETE FROM Employee");
        }
    }
}
