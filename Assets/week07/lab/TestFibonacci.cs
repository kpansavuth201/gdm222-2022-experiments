using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFibonacci : MonoBehaviour
{    
    void Start()
    {
        for( int n = 1; n < 10; ++n )
            Debug.Log( "Fibonacci (Iterative Approach) n " + n + " : " + RecursiveUtility.FibonacciIterative(n) );
        
        for( int n = 1; n < 10; ++n )
            Debug.Log( "Fibonacci (Recursive Approach) n " + n + " : " + RecursiveUtility.FibonacciRecursive(n) );
    }
}
