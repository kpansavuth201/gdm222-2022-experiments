using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz04 : MonoBehaviour
{
    void Start()
    {
        string word1 = "danger";
        string word2 = "garden";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // true
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // true

        word1 = "apple";
        word2 = "papel";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // true
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // true

        word1 = "arachnophobia";
        word2 = "noiabhophcara";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // true
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // true

        word1 = "arachnophobia";
        word2 = "noiabhophcera";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // false
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // false

        word1 = "apple";
        word2 = "pineapple";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // false
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // false

        word1 = "aaab";
        word2 = "aaaa";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // false
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // false

        word1 = "yeet";
        word2 = "etya";
        Debug.Log("" + word1 + ", " + word2 + " : " + CheckCharacterBetweenGivenWords(word1, word2)); // false
        Debug.Log("" + word2 + ", " + word1 + " : " + CheckCharacterBetweenGivenWords(word2, word1)); // false
        
    }

    private bool CheckCharacterBetweenGivenWords(string s1, string s2)  {
        return false;        
    }
}
