using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSorting : MonoBehaviour
{
    private List<int> GenerateRandomList(int amount) {
        List<int> resultList = new List<int>();

        for(int i = 0; i < amount; ++i) {
            int randNum = Random.Range(-99, 100);
            resultList.Add(randNum);
        }

        return resultList;
    }

    private void PrintList(string prefix, List<int> inputList) {
        string message = "";

        message += prefix;

        for(int i = 0; i < inputList.Count; ++i) {
            message += inputList[i];
            if(i < inputList.Count - 1) {
                message += ", ";
            }
        }
        Debug.Log(message);
    }

    private List<int> GetAnswerSortedList(List<int> inputList) {
        List<int> answerList = new List<int>(inputList);
        answerList.Sort();
        return answerList;
    }

    private bool CheckSimilarList(List<int> listA, List<int> listB) {
        if(listA.Count != listB.Count) {
            return false;
        }

        for(int i = 0; i < listA.Count; ++i) {
            if(listA[i] != listB[i]) {
                return false;
            }
        }

        return true;
    }
    
    void Start()
    {
        List<int> exampleInputList = GenerateRandomList(10);
        PrintList("Example Input : ", exampleInputList);

        TestSelectionSort(exampleInputList);
        TestBubbleSort(exampleInputList);
    }

    private void TestSelectionSort(List<int> inputList) {
        List<int> sortedList = SelectionSort.Sort(inputList);
        PrintList("SelectionSort result : ", sortedList);

        List<int> answerList = GetAnswerSortedList(inputList);
        Debug.Log("Sorting correction : " + CheckSimilarList(sortedList, answerList));
    }

    private void TestBubbleSort(List<int> inputList) {
        List<int> sortedList = BubbleSort.Sort(inputList);
        PrintList("BubbleSort result : ", sortedList);

        List<int> answerList = GetAnswerSortedList(inputList);
        Debug.Log("Sorting correction : " + CheckSimilarList(sortedList, answerList));
    }
}
