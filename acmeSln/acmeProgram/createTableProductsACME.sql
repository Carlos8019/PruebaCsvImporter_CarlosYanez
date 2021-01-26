-- Create a new table called 'TableName' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.tblProductsACME', 'U') IS NOT NULL
DROP TABLE dbo.tblProductsACME
GO
-- Create the table in the specified schema
CREATE TABLE dbo.tblProductsACME
(
    pointOfSale [NVARCHAR](250) NULL ,
    product [NVARCHAR](250) NULL ,
    dateValue [NVARCHAR](250) NULL ,
    stock [NVARCHAR](250) NULL ,
);
GO
-- Create a new table called 'tblErrorInsertACME' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.tblErrorInsertACME', 'U') IS NOT NULL
DROP TABLE dbo.tblErrorInsertACME
GO
-- Create the table in the specified schema
CREATE TABLE dbo.tblErrorInsertACME
(
    jsonRawData NVARCHAR(MAX),
    dateInsert DATETIME

);
GO