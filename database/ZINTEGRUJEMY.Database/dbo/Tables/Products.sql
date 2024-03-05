CREATE TABLE [dbo].[Products] (
    [SKU]          NVARCHAR (450) NOT NULL,
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [EAN]          NVARCHAR (MAX) NOT NULL,
    [ProducerName] NVARCHAR (MAX) NOT NULL,
    [Category]     NVARCHAR (MAX) NOT NULL,
    [IsWire]       BIT            NOT NULL,
    [Available]    BIT            NOT NULL,
    [IsVendor]     BIT            NOT NULL,
    [DefaultImage] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([SKU] ASC)
);

