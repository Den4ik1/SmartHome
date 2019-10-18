CREATE TABLE [dbo].[Devices] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Type]        NVARCHAR (MAX) NULL,
    [Condition]   BIT            NOT NULL,
    [Value]       INT            NULL,
    [Information] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED ([ID] ASC)
);

