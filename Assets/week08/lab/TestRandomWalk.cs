using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomWalk : MonoBehaviour
{
    public int WALK_STEP = 999999;

    public float STEP_DURATION = 0.02f;

    public float AMPLITUDE = 0.5f;
  
    public RandomWalkVisualizer randomWalkVisualizer;
    
    IEnumerator Start()
    {
        int curX = 0;
        int curY = 0;

        for(int n = 0; n < WALK_STEP; ++n) {

            int rand = Random.Range(-1, 2);
            curX += rand;
            
            float weight = randomWalkVisualizer.GetWalkWeight(curX, curY);
            weight += AMPLITUDE;
            randomWalkVisualizer.SetWalkWeight(curX, curY, weight);
            
            yield return new WaitForSeconds(STEP_DURATION);
        }
    }
}
