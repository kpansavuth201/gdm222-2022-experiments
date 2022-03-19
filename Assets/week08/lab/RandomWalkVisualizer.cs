using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkVisualizer : MonoBehaviour
{    
    public class Coordinate {
        public int X;
        public int Y;

        public Coordinate(int x, int y) {
            this.X = x;
            this.Y = y;
        }
    }

    private Dictionary<string, GameObject> cubeDict = new Dictionary<string, GameObject>();

    private string GetKeyFromCoordinate(Coordinate coordinate) {
        return "" + coordinate.X + "," + coordinate.Y;
    }

    private Coordinate GetCoordinateFromKey(string key) {
        string []splitStr = key.Split(',');
        Coordinate coordinate = new Coordinate(
            int.Parse(splitStr[0]),
            int.Parse(splitStr[1])
        );
        return coordinate;
    }

    public void SetWalkWeight(int x, int y, float amount) {
        SetWalkWeight(new Coordinate(x, y), amount);
    }
    
    public void SetWalkWeight(Coordinate coordinate, float amount) {
        string key = GetKeyFromCoordinate(coordinate);
        GameObject cube = null;
        if(cubeDict.ContainsKey(key)) {
            cube = cubeDict[key];
        } else {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(coordinate.X, 0f, coordinate.Y);
            cubeDict.Add(key, cube);
        }

        cube.transform.localScale = new Vector3(1f, amount, 1f);
        Vector3 pos = cube.transform.position;
        pos.y = amount * 0.5f;
        cube.transform.position = pos;
    }

    public float GetWalkWeight(int x, int y) {
        return GetWalkWeight(new Coordinate(x, y));
    }

    public float GetWalkWeight(Coordinate coordinate) {
        string key = GetKeyFromCoordinate(coordinate);
        GameObject cube = null;
        if(cubeDict.ContainsKey(key)) {
            cube = cubeDict[key];
        } else {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(coordinate.X, 0f, coordinate.Y);
            cubeDict.Add(key, cube);
        }

        return cube.transform.localScale.y;
    }
}
