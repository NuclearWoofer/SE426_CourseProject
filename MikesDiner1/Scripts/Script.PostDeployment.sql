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
*/

if not exists (select * from Food)
begin 
    insert into dbo.Food(Title, [Description], Price)
    values
        ('Cheeseburger Meal','Cheeseburger, fries and a drink',5.95),
        ('Chili Dog Meal','Two Chili dogs, fries & Drink.', 4.95),
        ('Vegetarian Meal','Salad & Water.', 1.95);
end