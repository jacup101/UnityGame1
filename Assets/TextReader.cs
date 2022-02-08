using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReader
{
    private string fileName;
    private string directory = ".\\Assets\\Levels\\";
    public TextReader(string tryRead)
    {
        fileName = tryRead + ".balllevel";
    }
    public string[] read()
    {
        return System.IO.File.ReadAllLines(directory + fileName);
    }
}
