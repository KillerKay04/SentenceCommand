using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireMissile : MonoBehaviour
{ 

    [SerializeField]
    private GameObject homeBase;

    [SerializeField]
    private GameObject fireButton;

    public void FireAtEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (ammoCheck() > 0)
        {
            {
                if (enemies.Length > 0)
                {
                    GameObject closestEnemy = null;
                    float enemyDistance = Mathf.Infinity;
                    Vector2 basePosition = homeBase.transform.position;

                    foreach (GameObject enemy in enemies)
                    {
                        Vector2 enemyVector = enemy.transform.position;
                        Vector2 enemyToBase = enemyVector - basePosition;
                        float currentDistance = enemyToBase.sqrMagnitude;
                        if (currentDistance < enemyDistance)
                        {
                            closestEnemy = enemy;
                            enemyDistance = currentDistance;
                        }

                        //Debug.Log(enemyToBase);
                        //Vector2 directionBaseToEnemy = homeBase.transform.position - enemy.transform.position;
                        //Debug.DrawRay(enemy.transform.position, directionBaseToEnemy, Color.green);
                        //RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, directionBaseToEnemy);
                    }
                    EnemyController enemyFunctions = closestEnemy.GetComponent<EnemyController>();
                    enemyFunctions.destroyEnemy();
                    Debug.Log("Enemy destroyed");
                }
            }
        }
    }

    private int ammoCheck()
    {
        int ammoCount = 0;

        string ammoText = fireButton.transform.Find("AmmoLabel").GetComponent<TMP_Text>().text;

        int.TryParse(ammoText, out ammoCount);

        Debug.Log(ammoCount);

        return ammoCount;
    }


}
