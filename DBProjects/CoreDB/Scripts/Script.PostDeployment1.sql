/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
CoreDB Post-Deployment Script
*/

:r .\Post-Deployment\dbo.Countries.Table.sql
:r .\Post-Deployment\dbo.Districts.Table.sql
:r .\Post-Deployment\dbo.Employees.Table.sql
:r .\Post-Deployment\dbo.Genders.Table.sql
:r .\Post-Deployment\dbo.NationalIdTypes.Table.sql
:r .\Post-Deployment\dbo.Places.Table.sql
:r .\Post-Deployment\dbo.Regions.Table.sql