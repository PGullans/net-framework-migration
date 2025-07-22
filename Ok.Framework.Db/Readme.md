# Run DB Migration

Using Update-Database (Package Manager Console):

Verify the Web.Config Connection String points to the correct Database

1. Open the Package Manager Console in Visual Studio. (Tools > NuGet Package Manager > Package Manager Console)
2. Select Ok.Framework.Db as the appropriate startup project: from the dropdown.
3. Run the command: Update-Database.

# Reset Database

Update-Database -Target:0