using Dapper;
using Npgsql;

public class ContactService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=ContactDB;User Id=postgres;Password=22385564;";

  public List<ContactDto> GetContacts()
  {
   using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"select * from contacts";
      var result = connection.Query<ContactDto>(sql);
      return result.ToList();
    }    
  }
    public List<ContactDto> GetContactByName(string name)
  {
   using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"select c.id, c.name, c.address, c.telephone from contacts c where c.name = '{name}';";
      var result = connection.Query<ContactDto>(sql);
      return result.ToList();
    }    
  }
    public bool AddContact(ContactDto contact)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO contacts (Id, Name, Address, Telephone)" +
      $"VALUES ('{contact.Id}','{contact.Name}', '{contact.Address}', '{contact.Telephone}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
    }
    catch (System.Exception ex)
    {
       System.Console.WriteLine(ex.Message);
       return true;
    }
  }
    public bool UpdateContact(ContactDto contact)
  {
    try
    {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update contacts SET Name='{contact.Name}', Address='{contact.Address}', Telephone='{contact.Telephone}'   where id = '{contact.Id}'";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
    }
    catch (System.Exception ex)
    {
       System.Console.WriteLine(ex.Message);
       return true;
    }
  }
    public bool DeleteContact(int id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from contacts where Id = '{id}'";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }

}