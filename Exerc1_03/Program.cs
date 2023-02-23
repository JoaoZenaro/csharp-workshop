static void FormatString(string stringToFormat)
{
    stringToFormat.Replace("World", "Mars");
}

static string FormatReturningString(string stringToFormat)
{
    return stringToFormat.Replace("Earth", "Mars");
}

var greeting = "Hello World";
FormatString(greeting);

Console.WriteLine(greeting);
var anotherGreeting = "Hello Earth";

Console.WriteLine(FormatReturningString(anotherGreeting));

Console.Read();