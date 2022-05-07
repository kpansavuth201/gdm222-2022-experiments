using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestDelegate : MonoBehaviour
{    
    
    public delegate void DelegateNoArg ( );
    
    public DelegateNoArg myFuncList;

    public DelegateNoArg OnMouseClicked;

    private int clickCount = 0;
    
    private void PrintHelloWorld ( ) {
        Debug.Log("Hello World");
    }

    private void IncreaseClickCount() {
        clickCount = clickCount + 1;
    }

    private void LogMouseClick() {
        Debug.Log("Mouse clicked : " + clickCount);
    }
    
    void Start()
    {
        // PrintHelloWorld();
        
        // myFuncList += PrintHelloWorld;
        // myFuncList.Invoke();

        OnMouseClicked += IncreaseClickCount;
        OnMouseClicked += LogMouseClick;
    }

    void Update() {

        if( Input.GetMouseButtonDown(0) ) {
            OnMouseClicked.Invoke();
        }
    }
}
