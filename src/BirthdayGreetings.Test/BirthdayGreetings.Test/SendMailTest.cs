using Xunit;

namespace BirthdayGreetings.Test;

public class SendMailTest
{
    [Fact]
    void sends_greetings_to_the_first_person_no_matter_the_date()
    {
        var today = new DateTime(2023, 10, 08);
        var flatFile = 
@"last_name, first_name, date_of_birth, email
Doe, John, 1982/10/08, john.doe@foobar.com
Ann, Mary, 1975/09/11, mary.ann@foobar.com";
        var mailer = new FakeMailer();
        var greeter = new Greeter(mailer);
        
        greeter.SendGreetings(today, flatFile);

        var greeting = 
@"Subject: Happy birthday!
Happy birthday, dear John!";

        var mails = mailer.GetReceived();
        var single = mails.ToArray();

        var expected = new Mail(
            To: "john.doe@foobar.com",
            Subject: "Happy birthday!",
            Message: "Happy birthday, dear John!"
            );
        
        Assert.Equal(
            new[]{expected}, 
            single);
    }
}

internal class FakeMailer : Mailer
{
    private readonly List<Mail> _mails;

    public FakeMailer()
    {
        _mails = new List<Mail>();
    }
    internal IEnumerable<Mail> GetReceived() => _mails;

    public void Send(Mail mail)
    {
        _mails.Add(mail);
    }
}
