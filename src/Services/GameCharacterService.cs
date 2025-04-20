using System.Data;
using Microsoft.Data.SqlClient;
using Models;
using Models.mage;
using Models.rogue;

namespace Services;

public class GameCharacterService : IGameCharacterService
{
    private readonly string _connectionString;

    public GameCharacterService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Warrior> GetAllWarriors()
    {
        var warriors = new List<Warrior>();
        var query = "SELECT * FROM Warriors";

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            {
                try
                {
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            var warrior = new Warrior
                            (reader.GetString(0),
                                reader.GetString(1),
                                reader.GetBoolean(2),
                                reader.GetInt32(3)
                            );
                            warriors.Add(warrior);
                        }
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        return warriors;
    }

    public bool AddWarrior(Warrior warrior)
    {
        String query = "INSERT INTO Warriors (Id, Name, IsAlive, Stamina) VALUES (@Id, @Name, @IsAlive, @Stamina)";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", warrior.Id);
            command.Parameters.AddWithValue("@Name", warrior.Name);
            command.Parameters.AddWithValue("@IsAlive", warrior.IsAlive);
            command.Parameters.AddWithValue("@Stamina", warrior.Stamina);
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        return rowsAffected > 0;
    }
    
    public bool UpdateWarrior(string id, Warrior warrior)
    {
        String query = "UPDATE Warriors Set Name = @Name, IsAlive = @IsAlive, Stamina = @Stamina WHERE Id = @Id";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", warrior.Name);
            command.Parameters.AddWithValue("@IsAlive", warrior.IsAlive);
            command.Parameters.AddWithValue("@Stamina", warrior.Stamina);
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        return rowsAffected > 0;
    }

    public List<Mage> GetAllMages()
    {
        var mages = new List<Mage>();
        var query = "SELECT * FROM Mages";

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            {
                try
                {
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            int? mana = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                            var mage = new Mage
                            (reader.GetString(0),
                                reader.GetString(1),
                                reader.GetBoolean(2),
                                mana
                            );
                            mages.Add(mage);
                        }
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        return mages;
    }
    
    public bool AddMage(Mage mage)
    {
        String query = "INSERT INTO Mages (Id, Name, IsAlive, Mana) VALUES (@Id, @Name, @IsAlive, @Mana)";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", mage.Id);
            command.Parameters.AddWithValue("@Name", mage.Name);
            command.Parameters.AddWithValue("@IsAlive", mage.IsAlive);
            command.Parameters.AddWithValue("@Mana", mage.Mana);
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        return rowsAffected > 0;
    }

    public bool UpdateMage(string id, Mage mage)
    {
        String query = "UPDATE Mages Set Name = @Name, IsAlive = @IsAlive, Mana = @Mana WHERE Id = @Id";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", mage.Id);
            command.Parameters.AddWithValue("@Name", mage.Name);
            command.Parameters.AddWithValue("@IsAlive", mage.IsAlive);
            command.Parameters.AddWithValue("@Mana", (object?) mage.Mana ?? DBNull.Value);
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        return rowsAffected > 0;
    }

    public List<Rogue> GetAllRogues()
    {
        var rogues = new List<Rogue>();
        var query = "SELECT * FROM Rogues";

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            {
                try
                {
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            var rogue = new Rogue
                            (
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetBoolean(2),
                                reader.GetString(3),
                                reader.GetString(4)
                            );
                            rogues.Add(rogue);
                        }
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        return rogues;
    }
    
    public bool AddRogue(Rogue rogue)
    {
        String query = "INSERT INTO Rogues (Id, Name, IsAlive, StealthCode, GuildName) VALUES (@Id, @Name, @IsAlive, @StealthCode, @GuildName)";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", rogue.Id);
            command.Parameters.AddWithValue("@Name", rogue.Name);
            command.Parameters.AddWithValue("@IsAlive", rogue.IsAlive);
            command.Parameters.AddWithValue("@StealthCode", rogue.StealthCode);
            command.Parameters.AddWithValue("GuildName", rogue.GuildName);
            
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        return rowsAffected > 0;;
    }

    public bool UpdateRogue(string id, Rogue rogue)
    {
        String query = "UPDATE Rogues Set Name = @Name, IsAlive = @IsAlive, StealthCode = @StealthCode, GuildName = @GuildName WHERE Id = @Id";
        int rowsAffected = 0;
        
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", rogue.Id);
            command.Parameters.AddWithValue("@Name", rogue.Name);
            command.Parameters.AddWithValue("@IsAlive", rogue.IsAlive);
            command.Parameters.AddWithValue("@StealthCode", rogue.StealthCode);
            command.Parameters.AddWithValue("GuildName", rogue.GuildName);
            
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        return rowsAffected > 0;;
    }

    public bool ReviveCharacter(string id)
    {
        if(id.StartsWith("W-")) return ReviveWarrior(id);
            
    }

    public bool DeleteCharacter(string id)
    {
        throw new NotImplementedException();
    }
}