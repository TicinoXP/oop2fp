using Xunit;

namespace BirthdayGreetings.Test.Test;

public class DummyTest
{
    [Fact]
    void a_dummy_passing_test()
    {
        var greetings = DummyClass.Run();
        
        Assert.NotEmpty(greetings);
    }
}
