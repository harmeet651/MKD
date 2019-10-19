# MKD
 mkd test

 1. Download SQL server 2017 preferably (https://docs.microsoft.com/en-us/sql/ssms/release-notes-ssms?view=sql-server-ver15#download-ssms-1791). See the database file inside for the code and steps form microsoft.
 2. Download visual studio community version and ASP .NET framework form microsoft (https://visualstudio.microsoft.com/downloads/).
 3. Clone and open the .sln file inside the project.
 4. Add your connection string in web.config file from tools inside the menu of visual studio (select your server and table name).
 for example <connectionStrings>
    <add name="DBCS" connectionString="Data Source=DESKTOP-H0NHKE3\MSSQLSERVER01;Initial Catalog=mkd;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
 5. In the Add controller, add your email and password (in the very end) to send emails to the user that uses the form.
 6. Run IIS.
