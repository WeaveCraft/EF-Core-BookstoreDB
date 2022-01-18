# EF-Core-BookstoreDB

Download file at "https://github.com/vihu001/EF-Core-BookstoreDB"

All the Dependencies -> Packages should already be included.
If not, download the following;

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.Extensions.Configuration
ErikEJ.EntityFrameworkCore.DgmlBuilder

Start project, then you should go to Tools -> Nuget Package Manager -> Package Manager Console.
Then type into the Package Manager Console "update-database" and start program (f5).

You should already have the required migrations. If not, do "add-migration a1" -> "update-database" in the Package Manager Console.

You can get test data by starting the project and choosing option "16".
