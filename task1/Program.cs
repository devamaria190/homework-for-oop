using System;

public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private string loggingMode;
    private string databaseConnection;

    private ConfigurationManager() { }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public void SetLoggingMode(string mode)
    {
        loggingMode = mode;
    }

    public void SetDatabaseConnection(string connection)
    {
        databaseConnection = connection;
    }

    public void DisplaySettings()
    {
        Console.WriteLine($"Logging Mode: {loggingMode}");
        Console.WriteLine($"Database Connection: {databaseConnection}");
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        configManager.SetLoggingMode("Verbose");
        configManager.SetDatabaseConnection("ConnectionString123");

        ConfigurationManager anotherInstance = ConfigurationManager.Instance;
        anotherInstance.DisplaySettings();
    }
}
