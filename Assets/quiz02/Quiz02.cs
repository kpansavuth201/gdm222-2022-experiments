using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz02 : MonoBehaviour
{
    private void AddNode(PersonNode currentNode, PersonNode newNode) {
        // To do : please help me write this function
        PersonNode tempNode = currentNode.NextNode;

        currentNode.NextNode = newNode;

        newNode.NextNode = tempNode;
    }
                                        
    private void RemoveNode(PersonNode headNode, PersonNode nodeToRemove) {
        // To do : please help me write this function
        PersonNode nodeBefore = null;
        PersonNode nodeAfter = nodeToRemove.NextNode;

        PersonNode curNode = headNode;
        while(nodeBefore == null) {
            if( curNode.NextNode == nodeToRemove ) {
                nodeBefore = curNode;
            } else {
                curNode = curNode.NextNode;
                if( curNode == null ) {
                    break;
                }
            }            
        }

        nodeBefore.NextNode = nodeAfter;
        nodeToRemove.NextNode = null;
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
