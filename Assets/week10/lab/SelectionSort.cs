using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort
{
    public static List<int> Sort(List<int> inputList) {
        List<int> resultList = new List<int>();

        // Copy List
        for(int i = 0; i < inputList.Count; ++i) {
            resultList.Add(inputList[i]);
        }
        
        for(int n = 0; n < resultList.Count - 1; ++n) {
            int minIndex = n;

            // Find min index
            for(int i = n + 1; i < resultList.Count; ++i) {
                if(resultList[i] < resultList[minIndex]) {
                    minIndex = i;
                }
            }

            // Swap
            int temp = resultList[minIndex];
            resultList[minIndex] = resultList[n];
            resultList[n] = temp;
        }
        
        return resultList;
    }
}
