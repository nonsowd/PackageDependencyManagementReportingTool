using NugetManagementReport.Infrastructure;
using Spectre.Console;

namespace NugetManagementReport.Tool.Presentation;

internal class CliConsole : IConsoleWriter
{
    public void WriteLine() => AnsiConsole.WriteLine();
    public void WriteLine(string value) => AnsiConsole.WriteLine(value);
    public void WriteLine(int value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, int value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(uint value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, uint value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(long value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, long value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(ulong value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, ulong value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(float value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, float value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(double value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, double value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(decimal value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, decimal value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(bool value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, bool value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(char value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, char value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(char[] value) => AnsiConsole.WriteLine(value);
    public void WriteLine(IFormatProvider provider, char[] value) => AnsiConsole.WriteLine(provider, value);
    public void WriteLine(string format, params object[] args) => AnsiConsole.WriteLine(format, args);
    public void WriteLine(IFormatProvider provider, string format, params object[] args) => AnsiConsole.WriteLine(provider, format, args);
}
