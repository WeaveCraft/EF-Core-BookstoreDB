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


![Screenshot 2022-10-23 125942](https://user-images.githubusercontent.com/90194213/197388400-1df83fd6-9ed1-4515-b5d1-e1147ccbc2a2.png)
