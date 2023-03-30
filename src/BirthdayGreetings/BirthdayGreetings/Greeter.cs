namespace BirthdayGreetings;

internal class Greeter
{
    private readonly Mailer _mailer;

    internal Greeter(Mailer mailer)
    {
        _mailer = mailer;
    }

    internal void SendGreetings(DateTime today, string flatFile)
    {
        var contents = flatFile.Split("\r\n").Skip(1).Take(1);

        foreach (var content in contents)
        {
            var parts = content.Split(",");
            var lastName = parts[0].Trim();
            var firstName = parts[1].Trim();
            var birthDate = parts[2].Trim();
            var email = parts[3].Trim();

            _mailer.Send(
                new Mail(
                    To: email,
                    Subject: "Happy birthday!",
                    Message: $"Happy birthday, dear {firstName}!"));
        }
        
    }
}
