create procedure GetAllItems 
as
select  id
      ,name
      ,quantity
      ,price
      ,item_category_id
      ,tax from item 
      
      
      go 
create procedure GetAllCategories 
as
select  id
      ,category_name
       from item_categories  

go

sELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'food_order'

go
create procedure GetItemByCategroy 
@CategoryId int 
as
select  id
      ,name
      ,quantity
      ,price
      ,item_category_id
      ,tax from item  
      where item_category_id=@CategoryId
      go
create procedure GetAllOrders 
as
select 
    discount,
    subTotal,
    tax,
    grandTotal,
    order_id,
    date_created
from food_order  
go
create proc getitemsandcatname as
select  i.id,name,quantity,price,item_category_id,tax ,category_name from item i inner join item_categories ic on i.item_category_id=ic.id;


