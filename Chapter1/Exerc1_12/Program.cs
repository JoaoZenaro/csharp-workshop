﻿static async Task ReadFile(FileStream fileStream)
{
    using (var reader = new StreamReader(fileStream))
    {
        var content = await reader.ReadToEndAsync();
        var lines = content.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}

using (var file = new StreamWriter("products.csv", append: true))
 {
            file.Write("\nOne more macbook without details.");
 }

using (var fileStream = new FileStream("products.csv", FileMode.Open, FileAccess.Read))
{
    await ReadFile(fileStream);
}