using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireMissile : MonoBehaviour
{ 

    [SerializeField]
    private GameObject missileSpawn;

    [SerializeField]
    private GameObject standardMissile;

    [SerializeField]
    private GameObject homingMissile;

    [SerializeField]
    private GameObject splitMissile;
    
    [SerializeField]
    private float missileSpeed = 2.0f;
    

    

    // Audio
    private AudioGameScene ags;

    // WeaponSelector
    private GameObject weaponSelector;

    void Start()
    {
        // Audio
        ags = GameObject.FindObjectOfType(typeof(AudioGameScene)) as AudioGameScene;

        // weaponSelector
        weaponSelector = GameObject.Find("AmmoTypes");        
    }

    public void FireAtEnemy()
    {
        if (ammoCheck() > 0) 
        {

            // Audio
            ags.PlayFireMissile();
            
            //todo: probably need to combine the below with the next switch statement but keeping separate for now
            switch (GlobalVars.SelectedAmmoType) 
            {

                case GlobalVars.AmmoType.Standard:
                    
                    GameObject standardMissileFired = Instantiate(standardMissile, missileSpawn.transform.position, missileSpawn.transform.rotation);
                    standardMissileFired.GetComponent<Rigidbody2D>().velocity = missileSpeed * transform.localScale.y * missileSpawn.transform.up;
                    break;

                case GlobalVars.AmmoType.Homing:
  
                    GameObject homingMissileFired = Instantiate(homingMissile, missileSpawn.transform.position, missileSpawn.transform.rotation);
                    homingMissileFired.GetComponent<Rigidbody2D>().velocity = missileSpeed * transform.localScale.y * missileSpawn.transform.up;
                    break;

                case GlobalVars.AmmoType.Split:

                    for (int fireAngle = -20; fireAngle < 30; fireAngle += 20) {
                        Quaternion missileRotation = missileSpawn.transform.rotation;
                        GameObject missileFired = Instantiate(splitMissile, missileSpawn.transform.position, (missileRotation *= Quaternion.Euler(0, 0, fireAngle)));
                        missileFired.GetComponent<Rigidbody2D>().velocity = missileSpeed * transform.localScale.y * missileFired.transform.up;
                    }
                    break;

                
            }
            // decrement ammo counter of selected ammoType
            switch (GlobalVars.SelectedAmmoType)
            {
                case GlobalVars.AmmoType.Standard:
                    GlobalVars.ammoStandard--;
                    break;
                case GlobalVars.AmmoType.Homing:
                    GlobalVars.ammoHoming--;
                    break;
                case GlobalVars.AmmoType.Split:
                    GlobalVars.ammoSplit--;
                    break;
            }
            // tell weapon selector to update its labels
            weaponSelector.transform.GetComponent<WeaponSelector>().updateValues();

            //Debug.Log("Enemy destroyed");
            //ags.PlayUFOHit();
               
        
        }
    }

    private int ammoCheck()
    {
        
        // check how much ammo from global vars, depending on which ammoType is currently selected
        switch (GlobalVars.SelectedAmmoType)
        {
            case GlobalVars.AmmoType.Standard:
                return GlobalVars.ammoStandard;
            case GlobalVars.AmmoType.Homing:
                return GlobalVars.ammoHoming;
            case GlobalVars.AmmoType.Split:
                return GlobalVars.ammoSplit;
            default:
                // something has gone wrong, and there isn't a selected ammo type
                return -1;
        }
        
    }   
    
}
