using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingVisualizer : MonoBehaviour
{
    private Dictionary<string, GameObject> blockDict = new Dictionary<string, GameObject>();

    public void SetBlockDisplay(int x, int y, Color color) {
        string key = "" + x + "," + y;
        GameObject block = null;

        if(blockDict.ContainsKey(key)) {
            block = blockDict[key];
        } else {
            block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            block.transform.position = new Vector3(x, 0, -y);
            blockDict.Add(key, block);
        }

        block.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
