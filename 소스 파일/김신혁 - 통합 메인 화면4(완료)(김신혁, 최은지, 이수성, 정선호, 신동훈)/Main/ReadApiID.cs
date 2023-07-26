using System.Collections.Generic;
using System.IO;

public class ReadApiID
{
    public static List<string> readID()
    {
        List<string> id = new List<string>();
        string filePath = @"id.secret";
        string[] lines = File.ReadAllLines(filePath);
        id.Add(lines[0]);
        id.Add(lines[1]);
        return id;
    }
}