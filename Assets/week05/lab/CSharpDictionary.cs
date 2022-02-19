using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpDictionary : MonoBehaviour
{
    private Dictionary<string, int> playerScoreDictionary;

    void Start()
    {
        playerScoreDictionary = new Dictionary<string, int>();
        playerScoreDictionary.Add( "playerA", 8 );
        playerScoreDictionary.Add( "playerB", 10 );
        playerScoreDictionary.Add( "playerC", 5 );

        // playerScoreDictionary.Remove( "playerA" );

        // string key = "playerA";
        // if(  playerScoreDictionary.ContainsKey(key) ) {
        //     Debug.Log(key + " score is : " + playerScoreDictionary[key] );
        // } else {
        //     Debug.Log("playerScoreDictionary does not contains key : " + key);
        // }

        List<string> keyList = new List<string>(playerScoreDictionary.Keys);

        for(int i = 0; i < keyList.Count; ++i) {
            string key = keyList[i];
            Debug.Log( key + " score is : " + playerScoreDictionary[key] );
        }

        // playerScoreDictionary.Clear();
    }
}
