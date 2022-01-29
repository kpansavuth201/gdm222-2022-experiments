using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public string weaponName = "";
    public int weaponDamage = 0;
    
    void Start()
    {
        this.gameObject.name = this.gameObject.name +  " [Equip with +" + weaponDamage + " " + weaponName + "]";
    }
}
