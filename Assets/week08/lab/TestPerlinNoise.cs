using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPerlinNoise : MonoBehaviour
{
    public float Amplitude = 10f;

    public float Scatter = 5f;

    public float Spacing = 1f;

    public int MAX_X = 40;
    public int MAX_Y = 40;

    private int xAmount = 0;
    private int yAmount = 0;

    private Dictionary<string, GameObject> cubeDict = new Dictionary<string, GameObject>();
    
    void Start()
    {
        cubeDict.Clear();
        
        for(int x = 0; x < MAX_X; ++x) {
            for(int y = 0; y < MAX_Y; ++y) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(
                    x * Spacing,
                    Mathf.PerlinNoise(
                            (float)x / (float)MAX_X * Scatter,
                            (float)y / (float)MAX_Y * Scatter
                    ) * Amplitude,
                    y * Spacing
                );
                cube.transform.localScale = Vector3.one;

                string key = "" + x + "," + y;
                cubeDict.Add(key, cube);
            }
        }

        xAmount = MAX_X;
        yAmount = MAX_Y;
    }

    void Update() {
        for(int x = 0; x < xAmount; ++x) {
            for(int y = 0; y < yAmount; ++y) {
                string key = "" + x + "," + y;
                GameObject cube = cubeDict[key];

                Vector3 position = new Vector3(
                    x * Spacing,
                    Mathf.PerlinNoise(
                            (float)x / (float)xAmount * Scatter,
                            (float)y / (float)yAmount * Scatter
                    ) * Amplitude,
                    y * Spacing
                );

                cube.transform.position = position;
            }
        }
    }
}
