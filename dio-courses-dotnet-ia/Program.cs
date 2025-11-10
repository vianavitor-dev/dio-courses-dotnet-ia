// Reading files in C#

try
{
    string[] rows = System.IO.File.ReadAllLines("files/data.txt");

    foreach (string row in rows)
    {
        Console.WriteLine(row);
    }
}
catch (System.IO.FileNotFoundException fnfEx) // Specific exception for file not found
{
    Console.WriteLine($"File not found: {fnfEx.Message}");
}
catch (Exception ex) // Generic exception handling
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
