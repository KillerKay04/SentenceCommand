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
    private GameObject userScoreText;
    
    [SerializeField]
    private float missileSpeed = 2.0f;
    
    private int currentScore = 0;

    

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

                    //Quaternion missileRotation_1 = missileSpawn.transform.rotation;
                    //GameObject SplitMissileFired_1 = Instantiate(splitMissile, missileSpawn.transform.position, (missileRotation_1 *= Quaternion.Euler(0, 0, 20)));
                    //SplitMissileFired_1.GetComponent<Rigidbody2D>().velocity =  missileSpeed * transform.localScale.y * SplitMissileFired_1.transform.up;

                    //Quaternion missileRotation_2 = missileSpawn.transform.rotation;
                    //GameObject SplitMissileFired_2 = Instantiate(splitMissile, missileSpawn.transform.position, missileRotation_2);
                    //SplitMissileFired_2.GetComponent<Rigidbody2D>().velocity = missileSpeed * transform.localScale.y * SplitMissileFired_2.transform.up;

                    //Quaternion missileRotation_3 = missileSpawn.transform.rotation;
                    //GameObject SplitMissileFired_3 = Instantiate(splitMissile, missileSpawn.transform.position, (missileRotation_3 *= Quaternion.Euler(0, 0, -20)));
                    //SplitMissileFired_3.GetComponent<Rigidbody2D>().velocity = missileSpeed * transform.localScale.y * SplitMissileFired_3.transform.up;
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
        /*
        int ammoCount = 0;

        string ammoText = fireButton.transform.Find("AmmoLabel").GetComponent<TMP_Text>().text;

        int.TryParse(ammoText, out ammoCount);

        Debug.Log(ammoCount);

        return ammoCount;
        */
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

    private void addToScore(float distancePoints)
    {
        currentScore += (int)distancePoints * 10;
        userScoreText.GetComponent<TMP_Text>().text = currentScore.ToString();
    }

    /*
     private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            destroyEnemy();

        }
    }
    */
    
}
