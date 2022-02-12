using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipArmour : MonoBehaviour
{
    public string armourName = "";
    public int armourDefence = 0;
    
    void Start()
    {
        this.gameObject.name = this.gameObject.name +  " [Equip with +" + armourDefence + " " + armourName + "]";
    }
}
