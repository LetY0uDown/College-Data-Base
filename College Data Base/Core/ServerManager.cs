namespace College_Data_Base.Core;

public static class ServerManager
{
    public static string? ConnectionString { get; private set; }

    private static string? ServerName;
    private static string? Username;
    private static string? Password;

    public static void InitializeConnection(string serverName, string username, string password)
    {
        ServerName = serverName;
        Username = username;
        Password = password;

        ConnectionString = $"server={ServerName};user={Username};password={Password};database=CollegeDB;";
    }

    public static bool TestConnection()
    {
        bool result = false;

        try
        {
            using AppContext db = new();

            if (db.Database.CanConnect())
                result = true;
        }
        catch
        {
            new WarningWindow("Ошибка подключения", "Возможно вы ввели неверные данные либо сервер не отвечает").Show();
        }        

        return result;
    }

    public static void OfflineConnection()
    {
        ConnectionString = $"server=localhost;user=root;password=password;database=CollegeDB.db;";
    }
}