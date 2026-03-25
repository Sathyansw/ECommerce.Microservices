use ECommerceIdentityDb


SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

select * from ECommerceIdentityDb.dbo.AspNetUsers
select * from ECommerceIdentityDb.dbo.AspNetRoles
select * from ECommerceIdentityDb.dbo.AspNetRoleClaims
select * from ECommerceIdentityDb.dbo.AspNetUserClaims
select * from ECommerceIdentityDb.dbo.AspNetUserLogins
select * from ECommerceIdentityDb.dbo.AspNetUserRoles
select * from ECommerceIdentityDb.dbo.AspNetUserTokens



select * from  ECommerceIdentityDb.dbo.AspNetUsers

----------------------------------------------------------------------------------------------------------------------------------

use ECommerceCatalogDb

select * from ECommerceCatalogDb.dbo.Categories
select * from ECommerceCatalogDb.dbo.Products



delete from ECommerceCatalogDb.dbo.Categories
delete from ECommerceCatalogDb.dbo.Products



SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Products';

----------------------------------------------------------------------------------------------------------------------------------

use ECommerceCartDb

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

select * from ECommerceIdentityDb.dbo.AspNetUsers
select * from ECommerceCatalogDb.dbo.Products


select * from ECommerceCartDb.dbo.ShoppingCarts
select * from ECommerceCartDb.dbo.ShoppingCartItems

delete from ECommerceCartDb.dbo.ShoppingCarts
delete from ECommerceCartDb.dbo.ShoppingCartItems
----------------------------------------------------------------------------------------------------------------------------------

use ECommerceOrderDb

select * from ECommerceOrderDb.dbo.OrdersHeaders
select * from ECommerceOrderDb.dbo.OrderItems

delete from ECommerceOrderDb.dbo.OrdersHeaders
delete from ECommerceOrderDb.dbo.OrderItems

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'OrdersHeaders'

ALTER TABLE OrdersHeaders
ALTER COLUMN UserId UNIQUEIDENTIFIER

ALTER TABLE OrderItems
ALTER COLUMN OrderHeaderId UNIQUEIDENTIFIER

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'OrderItems'

use ECommercePaymentDb

select * from ECommercePaymentDb.dbo.PaymentProcesss

