

class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

// Клас для відправки електронних листів
class EmailSender
{
    private readonly ILog _logger;

    public EmailSender(ILog logger)
    {
        _logger = logger;
    }

    public void Send(Email email)
    {
        // Відправка повідомлення
        // ...

        // Логування через переданий логер
        _logger.Log($"Email from '{email.From}' to '{email.To}' was sent.");
    }
}

// Інтерфейс для логування
interface ILog
{
    void Log(string message);
}

// Логер для виведення в консоль
class ConsoleLogger : ILog
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        ILog logger = new ConsoleLogger();
        EmailSender es = new EmailSender(logger);

        es.Send(e1);
        es.Send(e2);
        es.Send(e3);
        es.Send(e4);
        es.Send(e5);
        es.Send(e6);

        Console.ReadKey();
    }
}
