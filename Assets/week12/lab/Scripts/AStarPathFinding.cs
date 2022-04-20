using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// References:
// https://www.raywenderlich.com/3016-introduction-to-a-pathfinding

public class AStarPathFinding : MonoBehaviour
{
    public PathFindingVisualizer Visualizer;
    
    public class Node {

        public Node(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public Node ParentNode = null;

        public int X; // Coordinate in X axis
        public int Y; // Coordinate in Y axis

        // G is the movement cost from the start point to the current square.
        public float G; 

        // H is the estimated movement cost from the current square to the destination point
        public float H;

        // F is sum of G and H
        public float F {
            get{
                return G + H;
            }
        }

        public void CalculateHScore(int destX, int destY) {
            int diffX = Mathf.Abs(destX - X);
            int diffY = Mathf.Abs(destY - Y);

            this.H = diffX + diffY;
        }

        public void CalculateGScore(Node anyAdjacentNode) {
            this.G = anyAdjacentNode.G + 1;
        }

        public void Print() {
            Debug.Log("(" + X + "," + Y + ") " + "G:" + G + " H:" + H + " F:" + F);
        }
    }

    public const int GRID_SIZE = 9;

    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays
    // Jagged Arrays (array that contain arrays, array of array)
    // "W" - Wall
    // "." - Floor
    // "S" - Start Point
    // "D" - Destination Point
    public string[][] grid = new string[][] {
        new string[] { "W", "W", "W", "W", "W", "W", "W", "W", "W" },   // Y
        new string[] { "W", ".", ".", ".", ".", ".", ".", ".", "W" },   // |
        new string[] { "W", ".", ".", ".", "W", ".", ".", ".", "W" },   // |
        new string[] { "W", ".", ".", ".", "W", ".", ".", ".", "W" },   // |
        new string[] { "W", ".", ".", ".", "W", ".", ".", ".", "W" },   // |
        new string[] { "W", ".", "S", ".", "W", ".", ".", ".", "W" },   // |
        new string[] { "W", ".", "W", ".", "W", ".", "D", ".", "W" },   // |
        new string[] { "W", ".", ".", ".", ".", ".", ".", ".", "W" },   // |
        new string[] { "W", "W", "W", "W", "W", "W", "W", "W", "W" },   // V

        // X ------------------------------------------------------->
    };
    
    public const int DESTINATION_X = 6;
    public const int DESTINATION_Y = 6;

    private Node SearchForLowestFScoreNodeInList(List<Node> anyList) {
        float minF = float.MaxValue;
        Node nodeWithLowestFScore = null;

        // If many node has same F value, we check the most recently added node in the list first
        // for(int i = 0; i < anyList.Count ; ++i) {
        for(int i = anyList.Count-1; i >= 0 ; --i) {
            Node currNode = anyList[i];
            if(currNode.F < minF) {
                minF = currNode.F;
                nodeWithLowestFScore = currNode;
            }
        }

        return nodeWithLowestFScore;
    }

    private bool CheckIfNodeListContainsDestination(List<Node> anyList) {
        for(int i = 0; i < anyList.Count; ++i) {
            Node currNode = anyList[i];
            int x = currNode.X;
            int y = currNode.Y;
            if( grid[y][x] == "D" ) { // Check of node if destination node from grid
                return true;
            }
        }

        return false;
    }

    private List<Node> RetrieveWalkableAdjacentNodeList(Node anyNode) {
        List<Node> adjacentNodeList = new List<Node>();
        
        // Up
        if(anyNode.Y > 0) {
            int x = anyNode.X;
            int y = anyNode.Y - 1;
            if(grid[y][x] != "W") {
                adjacentNodeList.Add(new Node(x, y));
            }
        }
        // Down
        if(anyNode.Y < GRID_SIZE - 1) {
            int x = anyNode.X;
            int y = anyNode.Y + 1;
            if(grid[y][x] != "W") {
                adjacentNodeList.Add(new Node(x, y));
            }
        }
        // Left
        if(anyNode.X > 0) {
            int x = anyNode.X - 1;
            int y = anyNode.Y;
            if(grid[y][x] != "W") {
                adjacentNodeList.Add(new Node(x, y));
            }
        }
        // Right
        if(anyNode.X < GRID_SIZE - 1) {
            int x = anyNode.X + 1;
            int y = anyNode.Y;
            if(grid[y][x] != "W") {
                adjacentNodeList.Add(new Node(x, y));
            }
        }

        // Calculate G and H score for each adjacent node
        // Also add parent node pointer
        for(int i = 0; i < adjacentNodeList.Count; ++i) {
            adjacentNodeList[i].CalculateGScore(anyNode);
            adjacentNodeList[i].CalculateHScore(DESTINATION_X, DESTINATION_Y);
            adjacentNodeList[i].ParentNode = anyNode;
        }

        return adjacentNodeList;
    }

    public bool CheckIfListContainNode( List<Node> anyNodeList, Node anyNode ) {
        for(int i = 0; i < anyNodeList.Count; ++i) {
            if(anyNodeList[i].X == anyNode.X
                && anyNodeList[i].Y == anyNode.Y) {
                    return true;
                }
        }

        return false;
    }
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        bool foundPath = false;
        List<Node> openList = new List<Node>();
        List<Node> closeList = new List<Node>();

        Node startNode = new Node(2, 5); // Start Point
        startNode.G = 0; // Since this is start node, G is zero
        startNode.CalculateHScore(DESTINATION_X, DESTINATION_Y);
        openList.Add(startNode); // Add start point to open list

        WaitForSeconds wait = new WaitForSeconds(1f);

        // Display grid
        DisplayGrid(startNode);        
        
        do {
            // Pick current node from a node in the open list with the lowest F score
            Node currentNode = SearchForLowestFScoreNodeInList(openList);
            
            closeList.Add(currentNode); // add the current node to the closed list

            openList.Remove(currentNode); // remove it to the open list

            // if we added the destination to the closed list, we've found a path
            if(CheckIfNodeListContainsDestination(closeList)) { 
                foundPath = true;
                Debug.Log("PATH FOUND");
                break; // break the loop if path found
            }

            // Retrieve all its walkable adjacent nodes
            List<Node> adjacentNodeList = RetrieveWalkableAdjacentNodeList(currentNode);

            for(int i = 0; i < adjacentNodeList.Count; ++i) {
                Node adjacentNode = adjacentNodeList[i];
                
                // if this adjacent node is already in the closed list ignore it
                if( CheckIfListContainNode(closeList, adjacentNode)) {
                    // Go to the next adjacent node
                    continue;
                }

                // If open list not contains adjacent node
                if( !CheckIfListContainNode(openList, adjacentNode) ) {
                    // Add it to the open list
                    openList.Add(adjacentNode);
                }
            }

            yield return wait; // Add delay time so we can see what's going on step by step

            // Set block color for open and close list
            SetColorOfNodesInOpenAndCloseList(openList, closeList);            

        } while( openList.Count > 0 ); // We continue the process of open list is not empty

        if(foundPath) {
            // Set color to found path
            if(closeList.Count > 0) {
                // Last node in the close list should be destination node
                Node lastNode = closeList[ closeList.Count - 1 ];
                if(lastNode.X == DESTINATION_X && lastNode.Y == DESTINATION_Y) {
                    Node destinationNode = lastNode;
                    SetColorOfFoundPath(destinationNode);
                }
            }
        } else {
            Debug.Log("ERROR: Not shortest path found");
        }
    }

    private void DisplayGrid(Node startNode) {
        for(int x = 0; x < GRID_SIZE; ++x) {
            for(int y = 0; y < GRID_SIZE; ++y) {
                Color color = Color.gray;
                if(grid[y][x] == "W") {
                    color = Color.black;
                }
                Visualizer.SetBlockDisplay(x, y, color);
            }
        }
        Visualizer.SetBlockDisplay(startNode.X, startNode.Y, Color.magenta);
        Visualizer.SetBlockDisplay(DESTINATION_X, DESTINATION_Y, Color.yellow);
    }

    private void SetColorOfNodesInOpenAndCloseList(List<Node> openList, List<Node> closeList) {
        for(int i = 0; i < openList.Count; ++i) {
            Visualizer.SetBlockDisplay(openList[i].X, openList[i].Y, Color.green);
        }
        for(int i = 0; i < closeList.Count; ++i) {
            Visualizer.SetBlockDisplay(closeList[i].X, closeList[i].Y, Color.red);
        }
    } 

    private void SetColorOfFoundPath(Node anyNode) {
        Node trackBackNode = anyNode;
        while(trackBackNode != null) {
            trackBackNode.Print();
            Visualizer.SetBlockDisplay(trackBackNode.X, trackBackNode.Y, Color.blue);
            trackBackNode = trackBackNode.ParentNode;
        }
    }
}
