using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonNode {
    public string Name;

    public PersonNode NextNode;

    public PersonNode(string initialName) {
        Name = initialName;
    }
}

public class TestLinkedList : MonoBehaviour
{
    private void AddNode(PersonNode currentNode, PersonNode newNode) {
        // To do
    }
                                        
    private void RemoveNode(PersonNode nodeToRemove) {
        // To do
    }

    private PersonNode FindLastNode(PersonNode headNode) {
        PersonNode lastNode = null;
        PersonNode findingNode = headNode;

        Debug.Log("Start finding last node");
        Debug.Log("findingNode : " + findingNode.Name);
        int count = 0;

        while( findingNode.NextNode != null) {
            Debug.Log("found next node : " + findingNode.NextNode.Name);
            findingNode = findingNode.NextNode;

            count = count + 1;
            Debug.Log("count : " + count);
        }

        lastNode = findingNode;
        Debug.Log("lastNode : " + lastNode.Name);

        return lastNode;
    }

    void Start() {
        // PersonNode headNode = new PersonNode("Alice");
        // PersonNode secondNode = new PersonNode("Bob");
        // PersonNode thirdNode = new PersonNode("Catherine");

        // headNode.NextNode = secondNode;
        // secondNode.NextNode = thirdNode;

        // Debug.Log("secondNode.NextNode name : " + secondNode.NextNode.Name);

        // Debug.Log("headNode name : " + headNode.Name);
        // if( headNode.NextNode == null ) {
        //     Debug.Log("headNode NextNode is null");
        // } else {
        //     Debug.Log("headNode NextNode is not null");
        // }


        PersonNode currentNode = null;
        PersonNode headNode = new PersonNode("Alice");
        currentNode = headNode;

        currentNode.NextNode = new PersonNode("Bob");

        currentNode = currentNode.NextNode;

        currentNode.NextNode = new PersonNode("Catherine");

                      //Bob       Catherine  
        currentNode = currentNode.NextNode;

        currentNode = null;

        PersonNode lastNode = FindLastNode(headNode);
        Debug.Log("Last node : " + lastNode.Name );
    }
}
