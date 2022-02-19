using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScope : MonoBehaviour
{
    void Start()
    {
        TestScope();
    }

    int x = 10;
    
    private void TestScope()
    {
        for(int i = 0; i < 10; ++i) {
            Debug.Log("for loop i : " + i);
        }
        
        
        Debug.Log("x from out of function : " + x); //10

        x = 5;

        Debug.Log("x after modified : " + x); //5

        {
            int x = 99;
            x = 9;
            Debug.Log("x from first scope " + x); // 9
        }

        Debug.Log("x after end first  scope: " + x); // 5
        x = 3;
        Debug.Log("x after another modified : " + x); // 3

        {
            int x = 77;
            x = 7;
            Debug.Log("x from second scope " + x); // 7
        }

        Debug.Log("final x : " + x); // 3
    }
}
