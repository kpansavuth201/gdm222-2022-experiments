using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingNearestObjects : MonoBehaviour
{
    public GameObject PlayerObject;

    private List<GameObject> objectList = new List<GameObject>();

    private const int NUMBER_OF_OBJECTS = 20;

    private const int NUMBER_OF_RENDER_OBJECT = 5;
    
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
        SortObjectListByNearestDistance();
        RenderOnlyNearestObject();
    }

    private void SortObjectListByNearestDistance() {
        // Bubble Sort
        for (int i = 0; i < objectList.Count - 1; i++) {
            for (int j = 0; j < objectList.Count - i - 1; j++) {
                float distanceA = Vector3.Distance(
                    PlayerObject.transform.position,
                    objectList[j].transform.position
                );
                float distanceB = Vector3.Distance(
                    PlayerObject.transform.position,
                    objectList[j + 1].transform.position
                );

                if(distanceA > distanceB) {
                    // Swap
                    GameObject temp = objectList[j];
                    objectList[j] = objectList[j + 1];
                    objectList[j + 1] = temp;
                }
            }
        }

        // Try change sorting logic to selection sort
    }

    private void RenderOnlyNearestObject() {        
        for(int i = 0; i < objectList.Count; ++i) {
            bool isRender = (i < NUMBER_OF_RENDER_OBJECT);
            objectList[i].SetActive(isRender);
        }
    }
}
