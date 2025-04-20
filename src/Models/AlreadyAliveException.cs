namespace Models;

public class AlreadyAliveException(string message) : Exception(message)
{
}