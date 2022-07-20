# BattItaliaAPI
 
Install QueryFirst, Add file qfconfig.json in the root folder
```
{
  "defaultConnection": "Server=;Database=;User Id=;Password=;",
  "provider": "System.Data.SqlClient",
  "connectEditor2DB": true
}
```
Add same connString to Web.config

Execute sql_api.sql on a MS SQL Server

Change Domain in SwaggerConfig.cs
```
c.RootUrl(req => @"http://");
```
