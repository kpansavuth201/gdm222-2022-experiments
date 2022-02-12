using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Quiz01 : MonoBehaviour
{
    public bool Apply = false;
    
    public GameObject objectToSpawnPrefab;
    public int spawnAmount = 0;

    public int spawnDistance;

    private void Generate() {
        for(int i = 0; i < spawnAmount; ++i) {
            Vector3 spawnPos = new Vector3(0f, 0f, i * spawnDistance);
            Instantiate(objectToSpawnPrefab, spawnPos, Quaternion.identity);
        }
    }
    
    void Update()
    {
        if ( Apply ) {
            Apply = false;
            Generate();
        }
    }
}
