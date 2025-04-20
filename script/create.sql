CREATE TABLE Warriors (
                          Id NVARCHAR(10) PRIMARY KEY,
                          Name NVARCHAR(50) NOT NULL,
                          IsAlive BIT NOT NULL,
                          Stamina INT NOT NULL
);
GO

CREATE TABLE Mages (
                       Id NVARCHAR(10) PRIMARY KEY,
                       Name NVARCHAR(50) NOT NULL,
                       IsAlive BIT NOT NULL,
                       Mana INT NULL
);
GO

CREATE TABLE Rogues (
                        Id NVARCHAR(10) PRIMARY KEY,
                        Name NVARCHAR(50) NOT NULL,
                        IsAlive BIT NOT NULL,
                        StealthCode NVARCHAR(20) NOT NULL,
                        GuildName NVARCHAR(100) NOT NULL
);
GO
