using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using TestingWebApp.Pages;

namespace TestingWebApp.Repositories;

public class TodoRepository
{
    public IDbConnection CreateConnection()
    {
        return new MySqlConnection("Server=localhost;Port=3306;Database=testingwebapp;Uid=root;Pwd=Ruben2002;");
    }

    public IEnumerable<Todo> Get()
    {
        using var connection = CreateConnection();
        return connection.Query<Todo>("SELECT * FROM Todo").ToList();
    }

    public Todo Create(Todo todo)
    {
        string sql = @"INSERT INTO Todo (Description, Completed) VALUES (@Description, @Completed);
            SELECT * FROM Todo WHERE TodoId = LAST_INSERT_ID()";
        
        using var connection = CreateConnection();
        var result = connection.QuerySingle<Todo>(sql, new { Description = todo.Description, Completed = todo.Completed });
        return result;
    }

    public bool Delete(int todoId)
    {
        string sql = @"DELETE FROM Todo WHERE TodoId = @TodoId";
        
        using var connection = CreateConnection();
        int NumRowsAffected = connection.Execute(sql, new { TodoId = todoId });
        return NumRowsAffected == 1;
    }
    
    public bool Update(Todo todo)
    {
        string sql = @"UPDATE Todo SET Description = @Description, Completed = @Completed WHERE TodoId = @TodoId";
        
        using var connection = CreateConnection();
        var result = connection.Execute(sql, new { TodoId = todo.TodoId, Description = todo.Description, Completed = todo.Completed });
        return result == 1;
    }
}