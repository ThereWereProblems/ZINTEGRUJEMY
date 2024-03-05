CREATE TABLE [dbo].[Prices] (
    [SKU]                           NVARCHAR (450)  NOT NULL,
    [Id]                            NVARCHAR (MAX)  NOT NULL,
    [NettPrice]                     DECIMAL (18, 2) NOT NULL,
    [NettPriceAfterDiscount]        DECIMAL (18, 2) NOT NULL,
    [VAT]                           DECIMAL (18, 2) NOT NULL,
    [NettPriceAfterDiscountPerUnit] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED ([SKU] ASC)
);

