using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGraph : MonoBehaviour
{
    public static readonly string[] VERTEX_NAMES = { 
        "German",
        "India",
        "Japan",
        "Korea",
        "Singapore",
        "Norway"
    };

    public const int OFFSET_INDEX = 1;

    public void AddEdge( List< List<int> > adjList, int a, int b) {
        a = a - OFFSET_INDEX;
        b = b - OFFSET_INDEX;

        if( !adjList[a].Contains(b) ) {
            adjList[a].Add(b);
        }

        if( !adjList[b].Contains(a) ) {
            adjList[b].Add(a);
        }
    }

    public void PrintGraph(List< List<int> > adjList)
    {
        for (int i = 0; i < adjList.Count; i++) {
            string message = "Adjacency list of vertex [" + (i + OFFSET_INDEX) + "] : ";

            message += "head";
 
            foreach(int vertex in adjList[i])
            {
                message += " -> ";
                message += (vertex + OFFSET_INDEX);
            }

            Debug.Log(message);
        }
    }

    public void PrintGraphWithMappedName(List< List<int> > adjList)
    {
        for (int i = 0; i < adjList.Count; i++) {
            string message = "Adjacency list of [" + (VERTEX_NAMES[i]) + "] : ";

            message += "head";
 
            foreach(int vertex in adjList[i])
            {
                message += " -> ";
                message += VERTEX_NAMES[vertex];
            }

            Debug.Log(message);
        }
    }

    void Start()
    {        
        List< List<int> > adjList = new List< List<int> >();

        for(int i = 0; i < VERTEX_NAMES.Length; ++i) {
            adjList.Add(new List<int>());
        }

        AddEdge(adjList, 1, 2);
        AddEdge(adjList, 1, 3);
        AddEdge(adjList, 2, 4);
        AddEdge(adjList, 3, 4);
        AddEdge(adjList, 4, 5);
        AddEdge(adjList, 4, 6);

        PrintGraph(adjList);
        PrintGraphWithMappedName(adjList);
    }
}
