using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalTree : MonoBehaviour
{
    public GameObject TreeBranchPrefab;
    
    public GameObject StarterBranch;

    private Transform GetBranchEndTransform(GameObject branchObj) {
        return branchObj.transform.Find("end");
    }
    
    private GameObject GenerateBranch(
        GameObject prefab,
        Transform branchEnd,
        float scale,
        float angle
    ) {
        // Instantiate new branch
        GameObject branch = GameObject.Instantiate(prefab);

        // Make that new branch be child of branchEnd
        branch.transform.parent = branchEnd;

        // Reset new branch local position to zero
        branch.transform.localPosition = new Vector3(0f, 0f, 0f);

        // Set new branch local scale
        branch.transform.localScale = new Vector3(scale, scale, scale);

        // Set new branch local eulerAngle Z
        branch.transform.localEulerAngles = new Vector3(0f, 0f, angle);

        return branch;
    }
    
    
    void Start()
    {
        ManualSpawn();
        
        //RecursiveSpawn(3);
    }

    private void ManualSpawn() {
        GameObject firstBranch = GenerateBranch(
            TreeBranchPrefab,
            GetBranchEndTransform(StarterBranch),
            0.8f,
            30f
        );
        GameObject secondBranch = GenerateBranch(
            TreeBranchPrefab,
            GetBranchEndTransform(StarterBranch),
            0.8f,
            -30f
        );
        GameObject thirdBranch = GenerateBranch(
            TreeBranchPrefab,
            GetBranchEndTransform(firstBranch),
            0.8f,
            30f
        );
        GameObject forthBranch = GenerateBranch(
            TreeBranchPrefab,
            GetBranchEndTransform(firstBranch),
            0.8f,
            -30f
        );
    }

    private void RecursiveSpawn(int iteration) {

    }
}
