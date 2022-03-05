using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCharInWord : MonoBehaviour
{
    // char []characters;
    
    public static string Reverse(string word) {
        // char []characters = word.ToCharArray();
        
        List<char> charList = new List<char>();
        charList.AddRange(word);

        string result = "";

        while(charList.Count > 0) {
            int lastIndex = charList.Count - 1;
            result += charList[ lastIndex ];
            charList.RemoveAt(lastIndex);            
        }

        // Debug.Log( charList[0] );

        // string a = "hello";
		// string revers = "";
		
		// for(int i = a.Length-1; i >= 0; i--){
		// 	revers += a[i];
		// }
        
        // return answer here
        return result;
    }


    void Start()
    {
        string exampleString = "Hello";
        string reversedString = Reverse(exampleString);
        Debug.Log(reversedString); // olleH
    }
}
