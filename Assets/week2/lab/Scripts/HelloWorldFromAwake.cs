using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldFromAwake : MonoBehaviour
{
    public string id;
    
    void Awake()
    {
        Debug.Log("Hello World from Awake function with id: " + id);
    }
}
