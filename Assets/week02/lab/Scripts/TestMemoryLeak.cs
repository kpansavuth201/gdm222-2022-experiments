using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For more references, check https://docs.unity3d.com/Manual/performance-garbage-collector.html

public class TestMemoryLeak : MonoBehaviour
{
    public class Car {
        public float Speed = 10.0f;
    }
    
    void Start()
    {
        Car tesla = new Car();
        tesla = new Car();
    }

    public void ForceGarbageCollect() {
        //https://docs.unity3d.com/ScriptReference/Scripting.GarbageCollector.GCMode.html
    }
}
