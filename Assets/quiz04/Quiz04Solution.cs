using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz04Solution : MonoBehaviour
{
    private bool CheckCharacterBetweenGivenWords(string s1, string s2)  {
        if(s1.Length != s2.Length) {
            return false;
        }

        Dictionary<string, int> dictS1 = new Dictionary<string, int>();
        for(int i = 0; i < s1.Length; ++i) {
            string key = s1[i].ToString();
            if(dictS1.ContainsKey(key)) {
                ++dictS1[key];
            } else {
                dictS1.Add(key, 1);
            }
        }

        Dictionary<string, int> dictS2 = new Dictionary<string, int>();
        for(int i = 0; i < s2.Length; ++i) {
            string key = s2[i].ToString();
            if(dictS2.ContainsKey(key)) {
                ++dictS2[key];
            } else {
                dictS2.Add(key, 1);
            }
        }

        List<string> keyList = new List<string>(dictS1.Keys);
        foreach(string key in keyList) {
            if(!dictS2.ContainsKey(key)) {
                return false;
            }
            if(dictS1[key] != dictS2[key]) {
                return false;
            }
        }

        return true;        
    }
}
