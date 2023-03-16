namespace DataAccess;

internal class Secrets
{
    private const string connection = "Server=tcp:230206net-p2-server.database.windows.net,1433;Initial Catalog=TeamC;Persist Security Info=False;User ID=teamC;Password=M00dS0c!@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public static string getConnectionString() => connection;
}