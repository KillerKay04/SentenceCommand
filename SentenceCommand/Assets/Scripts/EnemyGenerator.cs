using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyTypes;

    [SerializeField]
    private PathCreator[] enemyPaths;

    [SerializeField]
    private int maxEnemies;

    [SerializeField]
    private Transform spawnLocation;

    private bool isGenerating;

    private int enemyCount = 0;

    public List<GameObject> enemyList = new List<GameObject>();

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
        yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
        int enemyType = Random.Range(0, enemyTypes.Length);
        enemyList.Add(Instantiate(enemyTypes[enemyType], spawnLocation.position, Quaternion.identity));
        enemyCount++;
        isGenerating = false;
    }

    public PathCreator AssignPath()
    {
        return enemyPaths[Random.Range(0, enemyPaths.Length)];
    }

    public void decreaseEnemyCount()
    {
        enemyCount--;
        Debug.Log(enemyCount);
    }
    

}
