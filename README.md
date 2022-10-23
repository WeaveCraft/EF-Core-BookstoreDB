# EF-Core-BookstoreDB
School project from Campus Nyköping "Programmering i .Net C# 2"

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

You can get test data by starting the project and choosing option "0".

![Screenshot 2022-10-23 125723](https://user-images.githubusercontent.com/90194213/197388369-d8c29db4-950e-48e8-9a6d-9a2524624d43.png)
