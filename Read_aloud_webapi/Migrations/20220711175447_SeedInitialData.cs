using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Read_aloud_webapi.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Members (Name, Age, Address, Job, PhoneNumber, EmailId) VALUES ('Arjun SS', 31, 'Ernakulam', 'Software Engineer', '9048463453', 'arjunss@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Members (Name, Age, Address, Job, PhoneNumber, EmailId) VALUES ('Ashitha K Balan', 31, 'Ernakulam', 'Banker', '9044536343', 'ashithakbalan@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Members (Name, Age, Address, Job, PhoneNumber, EmailId) VALUES ('Aswin SS', 28, 'Trivandrum', 'IAS', '8034163457', 'aswinss@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Members (Name, Age, Address, Job, PhoneNumber, EmailId) VALUES ('Babitha K B', 42, 'Kozhikode', 'Doctor', '8044373453', 'babithakb@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Members (Name, Age, Address, Job, PhoneNumber, EmailId) VALUES ('Saritha K B', 39, 'Kozhikode', 'Government Employee', '7078963453', 'sarithakb@gmail.com')");

            migrationBuilder.Sql("INSERT INTO Assignment (Description, SubmissionDate, MemberId) VALUES ('The alchemist by Paulo ceolho', '2022-08-15', (SELECT Id FROM Members WHERE Name='Arjun SS'))");
            migrationBuilder.Sql("INSERT INTO Assignment (Description, SubmissionDate, MemberId) VALUES ('Norwegian Wood by Murakami', '2022-08-12', (SELECT Id FROM Members WHERE Name='Arjun SS'))");
            migrationBuilder.Sql("INSERT INTO Assignment (Description, SubmissionDate, MemberId) VALUES ('The Paradoxical Prime Minister', '2022-08-16', (SELECT Id FROM Members WHERE Name='Ashitha K Balan'))");
            migrationBuilder.Sql("INSERT INTO Assignment (Description, SubmissionDate, MemberId) VALUES ('Go Set a Watchman', '2022-08-16', (SELECT Id FROM Members WHERE Name='Aswin SS'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Members WHERE NAME = 'Arjun SS' ");
            migrationBuilder.Sql("DELETE FROM Members WHERE NAME = 'Ashitha K Balan' ");
            migrationBuilder.Sql("DELETE FROM Members WHERE NAME = 'Aswin SS' ");
            migrationBuilder.Sql("DELETE FROM Members WHERE NAME = 'Babitha K B' ");
            migrationBuilder.Sql("DELETE FROM Members WHERE NAME = 'Saritha K B' ");
        }
    }
}
