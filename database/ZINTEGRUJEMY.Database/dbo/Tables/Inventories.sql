CREATE TABLE [dbo].[Inventories] (
    [SKU]          NVARCHAR (450)  NOT NULL,
    [ProductId]    INT             NOT NULL,
    [Unit]         NVARCHAR (MAX)  NOT NULL,
    [Qty]          INT             NOT NULL,
    [Manufacturer] NVARCHAR (MAX)  NOT NULL,
    [Shipping]     NVARCHAR (MAX)  NOT NULL,
    [ShippingCost] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED ([SKU] ASC)
);

