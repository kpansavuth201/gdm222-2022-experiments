using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleItemInList : MonoBehaviour
{ 
    List<string> cardList = new List<string>();
    
    void Start()
    {
        cardList.Clear();
        cardList.Add("DIAMOND");
        cardList.Add("HEART");
        cardList.Add("CLUB");
        cardList.Add("SPADE");

        Debug.Log("Card List before shuffle");
        foreach(string card in cardList) {
            Debug.Log(card);
        }

        List<string> resultList = Shuffle(cardList);

        Debug.Log("Card List after shuffle");
        foreach(string card in resultList) {
            Debug.Log(card);
        }
    }  

    private List<string> Shuffle(List<string> inputList) {
        List<string> clonedList = new List<string>(inputList);
        List<string> resultList = new List<string>();

        while(clonedList.Count > 0) {
            int randIndex = Random.Range(0, clonedList.Count);
            string pickedCard = clonedList[randIndex];
            resultList.Add(pickedCard);
            clonedList.RemoveAt(randIndex);
        }

        return resultList;
    }
}
