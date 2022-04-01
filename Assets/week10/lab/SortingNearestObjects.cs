using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingNearestObjects : MonoBehaviour
{
    public GameObject PlayerObject;

    private List<GameObject> objectList = new List<GameObject>();

    private const int NUMBER_OF_OBJECTS = 20;

    private const int NUMBER_OF_RENDER_OBJECT = 10;
    
    private void Awake() {
        Initialize();
    }
    
    void Start()
    {
        
    }

    private async void Initialize() {
        for(int i = 0; i < NUMBER_OF_OBJECTS; ++i) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(
                Random.Range(-20f,20f),
                0.5f,
                Random.Range(-20f,20f)
            );

            objectList.Add(cube);
        }
    }

    void Update() {
       RenderOnlyNearestObject();
    }

    private void RenderOnlyNearestObject() {
        for(int i = 0; i < objectList.Count; ++i) {
            bool isRender = (i < NUMBER_OF_RENDER_OBJECT);
            objectList[i].SetActive(isRender);
        }
    }
}
