
CREATE PROCEDURE [dbo].[PRODUCT_GROUP_GetList]

AS
Select	
	max(Id) as ProductId,
	Product_Group_ID as ProductGroup_ID,
	(select top 1 Product_Name from PRODUCT as p where p.ID = PRODUCT.Product_Group_ID) as  ProductGroup_Name
  From PRODUCT
  group by Product_Group_ID
GO


