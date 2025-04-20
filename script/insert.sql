INSERT INTO Warriors (Id, Name, IsAlive, Stamina) VALUES
    ('W-1', 'Garen', 0, 85),
    ('W-2', 'Darius', 1, 10),
    ('W-3', 'Pantheon', 1, 5);
GO

INSERT INTO Mages (Id, Name, IsAlive, Mana) VALUES
    ('M-1', 'Veigar', 0, NULL),
    ('M-2', 'Lux', 1, 100),
    ('M-3', 'Brand', 1, 30);
GO

INSERT INTO Rogues (Id, Name, IsAlive, StealthCode, GuildName) VALUES
    ('R-1', 'Talon', 0, 'RG-1001', 'Black Fang'),
    ('R-2', 'Zed', 1, 'RG-2002', 'Shadow Clan'),
    ('R-3', 'Evelynn', 1, 'WRONGCODE', 'Black Fang');
GO
