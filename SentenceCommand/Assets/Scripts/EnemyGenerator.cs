using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyTypes;

    //[SerializeField]
    //public List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private int maxEnemies;

    [SerializeField]
    private Transform spawnLocation;

    private bool isGenerating;
    private int enemyCount = 0;

    private void Start()
    {
        isGenerating = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isGenerating && enemyCount < maxEnemies)
        {
            isGenerating = true;
            StartCoroutine(GenerateEnemy());
        }
    }


    IEnumerator GenerateEnemy()
    {
        yield return new WaitForSeconds(Random.Range(8.0f, 12.0f));
        int enemyType = Random.Range(0, enemyTypes.Length - 1);
        Instantiate(enemyTypes[enemyType], spawnLocation.position, Quaternion.identity);
        enemyCount++;
        isGenerating = false;
    }

    

}
