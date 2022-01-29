using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldFromAnotherStart : MonoBehaviour
{
    public string id;
    
    void Start()
    {
        Debug.Log("Hello World from another Start function with id: " + id);
    }
}
