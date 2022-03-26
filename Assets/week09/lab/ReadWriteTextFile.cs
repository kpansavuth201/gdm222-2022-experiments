using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;

public class ReadWriteTextFile : MonoBehaviour
{
    public TextAsset textAsset;

    public const string FILE_NAME = "hello"; 

    private string exampleString = "Lorem ipsum dolor sit amet";
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ReadTextAsset());
        Debug.Log(ReadTextFile(FILE_NAME));
        //WriteTextFile(FILE_NAME, exampleString);
    }

    private string ReadTextAsset() {
        return textAsset.text;
    }

    private string GetFilePath(string fileName) {
        return "Assets/week09/Resources/" + fileName + ".txt";
    }

    private void WriteTextFile(string fileName, string text) {
        string filePath = GetFilePath(fileName);
        Debug.Log(filePath);
        if (!File.Exists(filePath))
        {            
            File.WriteAllText(filePath, text);
        }

        File.AppendAllText(filePath, text);
    }

    private string ReadTextFile(string fileName) {
        string filePath = GetFilePath(fileName);
        return File.ReadAllText(filePath);
    }
}
