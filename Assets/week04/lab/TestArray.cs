using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArray : MonoBehaviour
{
    int []arrayA = new int[5];
    int []arrayB = new int[5];

    void Start()
    {
        arrayA[0] = 99;

        Debug.Log("arrayA[0] : " + arrayA[0]);

        arrayB[0] = 77;

        arrayA = arrayB;

        Debug.Log("----------------");
        Debug.Log("arrayA[0] : " + arrayA[0]);  // 77
        Debug.Log("arrayB[0] : " + arrayB[0]);  // 77

        arrayB[0] = 10;

        Debug.Log("----------------");
        Debug.Log("arrayA[0] : " + arrayA[0]);
        Debug.Log("arrayB[0] : " + arrayB[0]);
    }
}
