using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;

public class ReadWriteTextFile : MonoBehaviour
{
    public TextAsset textAsset;

    public const string FILE_NAME = "Map"; 

    private string exampleString = "Lorem ipsum dolor sit amet";
    
    // Start is called before the first frame update
    async void Start()
    {
        // Debug.Log(ReadTextAsset());
        // Debug.Log(ReadTextFile(FILE_NAME));
        // WriteTextFile(FILE_NAME, "\nHello World");

        string data = ReadTextFile(FILE_NAME);

        string []lines = data.Split('\n');

        for(int i = 0; i < lines.Length; ++i) {
            if( !string.IsNullOrEmpty(lines[i]) ) {
                GenerateCubeFromStringData( lines[i] );
            }
        }
    }

    private GameObject GenerateCubeFromStringData (string positionData) {
        string []temp = positionData.Split(',');

        for(int i = 0; i < temp.Length; ++i) {
            Debug.Log( temp[i] );
        }

        float x = float.Parse( temp[0] );
        float y = float.Parse( temp[1] );
        float z = float.Parse( temp[2] );

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(x, y * 0.5f, z);
        cube.transform.localScale = new Vector3(1, y, 1);

        return cube;
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
        } else {
            File.AppendAllText(filePath, text);
        }

    }

    private string ReadTextFile(string fileName) {
        string filePath = GetFilePath(fileName);
        Debug.Log(filePath);
        return File.ReadAllText(filePath);
    }
}
