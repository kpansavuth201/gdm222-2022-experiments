using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestValue : MonoBehaviour
{
    void Start()
    {
        int aliceMoney = 10;
        int bobMoney = 5;

        Debug.Log("Initial Alice's money: " + aliceMoney);
        Debug.Log("Initial Bob's money: " + bobMoney);
        Debug.Log("------------------------------");

        aliceMoney = bobMoney;

        Debug.Log("Modified Alice's money: " + aliceMoney);
        Debug.Log("Modified Bob's money: " + bobMoney);
        Debug.Log("------------------------------");

        bobMoney = 999;

        Debug.Log("Assigned Alice's money: " + aliceMoney);
        Debug.Log("Assigned Bob's money: " + bobMoney);
        Debug.Log("------------------------------");
    }
}
