using System.Text;

var stringBuilder = new StringBuilder();
var stringWriter = new StringWriter(stringBuilder);

var originalOutput = Console.Out;
var originalError = Console.Error;

Console.SetOut(stringWriter);
Console.SetError(stringWriter);

Console.WriteLine("Hello, World!");
Console.WriteLine();
Console.Error.WriteLine("This is an error message.");


var lines = stringBuilder
    .ToString()
    .Split(Environment.NewLine);

if (lines[0] != "Hello, World!") throw new Exception("First line does not match expected output.");
if (lines[1] != "") throw new Exception("Second line is not empty as expected.");
if (lines[2] != "This is an error message.") throw new Exception("Third line does not match expected error message.");
if (lines[3] != "") throw new Exception("Fourth line is not empty as expected.");


Console.SetOut(originalOutput);
Console.SetError(originalError);


Console.WriteLine("All assertions passed.");
