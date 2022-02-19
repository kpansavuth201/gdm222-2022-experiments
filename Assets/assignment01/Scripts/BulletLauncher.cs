using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    private List<GameObject> bulletList = new List<GameObject>();

    public ObjectPool ObjectPool;
    
    private const float BULLET_SPEED = 3f;
    private const float OUT_OF_SCREEN_DISTANCE = 10f;

    void Start()
    {
        TestFireBullets();
    }

    void Update() {
        UpdateBulletsMovement();
        RemoveOutOfScreenBullets();
    }

    private void UpdateBulletsMovement() {
        for(int i = 0; i < bulletList.Count; ++i) {
            GameObject bullet = bulletList[i];
            bullet.transform.position += Vector3.forward * BULLET_SPEED * Time.deltaTime;
        }
    }

    private void RemoveOutOfScreenBullets() {
        for(int i = 0; i < bulletList.Count; ++i) {
            if(bulletList[i].transform.position.z > OUT_OF_SCREEN_DISTANCE) {
                ObjectPool.ReturnObjectToPool(bulletList[i]);
                bulletList.RemoveAt(i);
                i = i - 1;
            }
        }
    }

    private void TestFireBullets() {
        StartCoroutine(CoFireBullet());
    }

    private IEnumerator CoFireBullet() {
        while(true) {
            yield return new WaitForSeconds(1f);
            FireBullet( ObjectPool.BorrowObjectFromPool() );
        }
    }

    private void FireBullet(GameObject bullet) {
        bullet.transform.position = Vector3.zero;
        bulletList.Add(bullet);
    }
}
