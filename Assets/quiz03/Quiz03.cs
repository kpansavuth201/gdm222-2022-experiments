using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz03 : MonoBehaviour
{
    private string ReverseCharacterForEachWords(string text) {
        // To do : Help me write this function

        // Hint : Separate words with String.Split https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
        // string[] words = text.Split(' ');

        // Hint : String can be converted to char array
        // char[] chars = someString.ToCharArray();
        
        // Hint : string can also be converted to char List
        // List<char> charList = new List<char>();
        // charList.AddRange(someString);

        return text;
    }

    // You can write any other helper functions
    //private string MyHelperFunctionToHelpDivideTasks(string inputString) {
    // 
    //}
    
    void Start()
    {
        string exampleInputText = "The quick brown fox jumps over the lazy dog";
        string result = ReverseCharacterForEachWords(exampleInputText);
        Debug.Log(result);
        // result shoud be : ehT kciuq nworb xof spmuj revo eht yzal god
    }
}
