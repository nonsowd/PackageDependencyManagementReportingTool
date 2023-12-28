namespace NugetManagementReport.Infrastructure;

/// <summary>
/// A console capable of writing ANSI escape sequences.
/// </summary>
public interface IConsoleWriter
{
    /// <summary>
    /// Writes an empty line to the console.
    /// </summary>
    void WriteLine();

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(string value);

    /// <summary>
    /// Writes the text representation of the specified 32-bit signed integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(int value);

    /// <summary>
    /// Writes the text representation of the specified 32-bit signed integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, int value);

    /// <summary>
    /// Writes the text representation of the specified 32-bit unsigned integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(uint value);

    /// <summary>
    /// Writes the text representation of the specified 32-bit unsigned integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, uint value);

    /// <summary>
    /// Writes the text representation of the specified 64-bit signed integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(long value);

    /// <summary>
    /// Writes the text representation of the specified 64-bit signed integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, long value);

    /// <summary>
    /// Writes the text representation of the specified 64-bit unsigned integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(ulong value);

    /// <summary>
    /// Writes the text representation of the specified 64-bit unsigned integer value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, ulong value);

    /// <summary>
    /// Writes the text representation of the specified single-precision floating-point
    /// value, followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(float value);

    /// <summary>
    /// Writes the text representation of the specified single-precision floating-point
    /// value, followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, float value);

    /// <summary>
    /// Writes the text representation of the specified double-precision floating-point
    /// value, followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(double value);

    /// <summary>
    /// Writes the text representation of the specified double-precision floating-point
    /// value, followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, double value);

    /// <summary>
    /// Writes the text representation of the specified decimal value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(decimal value);

    /// <summary>
    /// Writes the text representation of the specified decimal value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, decimal value);

    /// <summary>
    /// Writes the text representation of the specified boolean value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(bool value);

    /// <summary>
    /// Writes the text representation of the specified boolean value,
    /// followed by the current line terminator, to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, bool value);

    /// <summary>
    /// Writes the specified Unicode character, followed by the current
    /// line terminator, value to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(char value);

    /// <summary>
    /// Writes the specified Unicode character, followed by the current
    /// line terminator, value to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, char value);

    /// <summary>
    /// Writes the specified array of Unicode characters, followed by the current
    /// line terminator, value to the console.
    /// </summary>
    /// <param name="value">The value to write.</param>
    void WriteLine(char[] value);

    /// <summary>
    /// Writes the specified array of Unicode characters, followed by the current
    /// line terminator, value to the console.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="value">The value to write.</param>
    void WriteLine(IFormatProvider provider, char[] value);

    /// <summary>
    /// Writes the text representation of the specified array of objects,
    /// followed by the current line terminator, to the console
    /// using the specified format information.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An array of objects to write.</param>
    void WriteLine(string format, params object[] args);

    /// <summary>
    /// Writes the text representation of the specified array of objects,
    /// followed by the current line terminator, to the console
    /// using the specified format information.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An array of objects to write.</param>
    void WriteLine(IFormatProvider provider, string format, params object[] args);
}
