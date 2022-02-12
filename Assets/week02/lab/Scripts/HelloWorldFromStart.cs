using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldFromStart : MonoBehaviour
{
    public string id;
    
    void Start()
    {
        Debug.Log("Hello World from Start function with id: " + id);
    }
}
