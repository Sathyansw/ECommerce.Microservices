use ECommerceIdentityDb


SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

select * from AspNetUsers
select * from AspNetRoles
select * from AspNetRoleClaims
select * from AspNetUserClaims
select * from AspNetUserLogins
select * from AspNetUserRoles
select * from AspNetUserTokens

truncate table AspNetUsers

delete from  AspNetUsers

