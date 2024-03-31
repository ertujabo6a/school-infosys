using System.Text;
using Xunit.Abstractions;

namespace ICS.Common.Tests;

public class XUnitTestOutputConverter(ITestOutputHelper output) : TextWriter
{
    // Taken from project https://github.com/nesfit/ICS
    // File https://github.com/nesfit/ICS/blob/master/src/CookBook/CookBook.Common.Tests/XUnitTestOutputConverter.cs
    // License https://github.com/nesfit/ICS/blob/master/LICENSE

    public override Encoding Encoding => Encoding.UTF8;

    public override void WriteLine(string? message) => output.WriteLine(message);

    public override void WriteLine(string format, params object?[] args) => output.WriteLine(format, args);
}
