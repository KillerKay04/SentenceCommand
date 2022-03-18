using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireMissile : MonoBehaviour
{ 

    [SerializeField]
    private GameObject homeBase;

    [SerializeField]
    private GameObject missileSpawn;

    [SerializeField]
    private GameObject missile;

    [SerializeField]
    private GameObject userScoreText;

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
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (ammoCheck() > 0)
        {
            {
                // Audio
                ags.PlayFireMissile();

                GameObject missileFired = Instantiate(missile, missileSpawn.transform.position, Quaternion.identity);
                missileFired.GetComponent<Rigidbody2D>().velocity = 10 * transform.localScale.y * missileSpawn.transform.up;

                if (enemies.Length > 0)
                {
                    //GameObject closestEnemy = null;
                    //float enemyDistance = Mathf.Infinity;
                    //Vector2 basePosition = homeBase.transform.position;

                    //foreach (GameObject enemy in enemies)
                    //{
                    //    Vector2 enemyVector = enemy.transform.position;
                    //    Vector2 enemyToBase = enemyVector - basePosition;
                    //    float currentDistance = enemyToBase.sqrMagnitude;
                    //    if (currentDistance < enemyDistance)
                    //    {
                    //        closestEnemy = enemy;
                    //        enemyDistance = currentDistance;
                    //    }

                    //    //draws ray to closest enemy for testing purposes
                    //    //Debug.Log(enemyToBase);
                    //    //Vector2 directionBaseToEnemy = homeBase.transform.position - enemy.transform.position;
                    //    //Debug.DrawRay(enemy.transform.position, directionBaseToEnemy, Color.green);
                    //    //RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, directionBaseToEnemy);
                    //}
                    //EnemyController enemyFunctions = closestEnemy.GetComponent<EnemyController>();
                    //addToScore(enemyDistance);
                    //enemyFunctions.destroyEnemy();

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
