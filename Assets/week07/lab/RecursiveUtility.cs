using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveUtility
{
    // Iterative Approach
    public static int FibonacciIterative(int n) {
        int firstnumber = 0, secondnumber = 1, result = 0;  
   
        if (n == 0) return 0; //To return the first Fibonacci number   
        if (n == 1) return 1; //To return the second Fibonacci number   


        for (int i = 2; i <= n; i++)  
        {            
            
            result = firstnumber + secondnumber;

            firstnumber = secondnumber;  
            secondnumber = result;  
        }

        return result;  
    }

    // Recursive Approach
    public static int FibonacciRecursive(int n) {
        Debug.Log("FibonacciRecursive " + n);
        if (n == 0) return 0; //To return the first Fibonacci number   
        if (n == 1) return 1; //To return the second Fibonacci number   
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);  
    }

    // SumTo
    // 1 + 2 + 3 + 4 + 5 + 6 + ... + n
    // SumTo(4)     + 5
    // SumTo(9)     + 10
    // SumTo(n - 1) + n
    public static int SumTo(int n) {
        if(n == 0) {
            return 0;
        }

        int result = SumTo(n - 1) + n;
        Debug.Log("SumTo n: " + n + ", result: " + result);
        return result;
    }
}
