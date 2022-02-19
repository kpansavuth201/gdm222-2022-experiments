using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   public GameObject BulletPrefab;

   private List<GameObject> objectInPoolList = new List<GameObject>();

   private const int MAX_OBJECT_AMOUNT = 10;

   private void CreateObjectsToFillPool() {
       // Instantiate objects here then fill them in pool
   }

   void Awake() {
       CreateObjectsToFillPool();
   }
   
   public GameObject BorrowObjectFromPool() {
       // Please help me write this function

       // Remove `Instantiate` command and fetch object from pool
       return Instantiate(BulletPrefab);
   }

   public void ReturnObjectToPool(GameObject objectToReturn) {
        // Please help me write this function

        // Remove `Destroy` command and return object to pool
        Destroy(objectToReturn);
   }
}
