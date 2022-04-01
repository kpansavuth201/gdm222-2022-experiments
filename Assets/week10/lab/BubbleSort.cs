using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort
{
    public static List<int> Sort(List<int> inputList) {
        List<int> resultList = new List<int>();

        // Copy List
        for(int i = 0; i < inputList.Count; ++i) {
            resultList.Add(inputList[i]);
        }

        for (int i = 0; i < resultList.Count - 1; i++) {
            for (int j = 0; j < resultList.Count - i - 1; j++) {
                if (resultList[j] > resultList[j + 1])
                {
                    // Swap
                    int temp = resultList[j];
                    resultList[j] = resultList[j + 1];
                    resultList[j + 1] = temp;
                }
            }
        }
        
        return resultList;
    }
}
