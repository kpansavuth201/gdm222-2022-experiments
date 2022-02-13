using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz02 : MonoBehaviour
{
    private void AddNode(PersonNode currentNode, PersonNode newNode) {
        // To do : please help me write this function
    }
                                        
    private void RemoveNode(PersonNode headNode, PersonNode nodeToRemove) {
        // To do : please help me write this function
    }

    private void PrintLinkedList(PersonNode headNode) {
        string result = "";
        PersonNode currentNode = headNode;

        while(currentNode != null) {
            result += currentNode.Name;
            
            if(currentNode.NextNode != null) {
                result +=" ,";                
            }
            currentNode = currentNode.NextNode;
        }

        Debug.Log(result);
    }

    void Start() {
        PersonNode alice = new PersonNode("Alice");
        PersonNode bob = new PersonNode("Bob");
        PersonNode catherine = new PersonNode("Catherine");
        PersonNode john = new PersonNode("John");
        PersonNode headNode = alice;
        alice.NextNode = bob;
        bob.NextNode = catherine;

        PrintLinkedList(headNode); // Alice ,Bob ,Catherine

        // Add John node after alice node
        AddNode(alice, john);

        PrintLinkedList(headNode); //Alice ,John ,Bob ,Catherine

        PersonNode mary = new PersonNode("Mary");
        AddNode(bob, mary);

        PrintLinkedList(headNode); //Alice ,John ,Bob ,Mary ,Catherine

        RemoveNode(headNode, bob);

        PrintLinkedList(headNode); //Alice ,John ,Mary ,Catherine

        RemoveNode(headNode, mary);

        PrintLinkedList(headNode); //Alice ,John ,Catherine
    }
}
