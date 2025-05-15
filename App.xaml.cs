using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Task2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string CONNECTION_STRING = "Server=127.0.0.1;Database=task2;Uid=root;Pwd=;";
    private static MySqlConnection _connection;
    public static MySqlConnection Connection => _connection;
    
    public App()
    {
        Connect();
    }

    /// <summary>
    /// Connect to db
    /// </summary>
    private async Task Connect()
    {
        await using var con = new MySqlConnection(CONNECTION_STRING);
        await con.OpenAsync();
        _connection = con;
    }
}