using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReferences : MonoBehaviour
{
    public class Person {
        public string Name;
        public int Money;

        public string ToString() {
            return Name + " has money: " + Money;
        }
    }
    void Start()
    {
        Person alice = new Person();
        alice.Name = "Alice";
        alice.Money = 10;

        Person bob = new Person();
        bob.Name = "Bob";
        bob.Money = 5;

        Debug.Log("Initial alice's data: " + alice.ToString());
        Debug.Log("Initial bob's data: " + bob.ToString());
        Debug.Log("------------------------------");

        alice = bob;

        Debug.Log("Modified alice's data: " + alice.ToString());
        Debug.Log("Modified bob's data: " + bob.ToString());
        Debug.Log("------------------------------");

        bob.Money = 999;

        Debug.Log("Assigned alice's data: " + alice.ToString());
        Debug.Log("Assigned bob's data: " + bob.ToString());
        Debug.Log("------------------------------");
    }
}
