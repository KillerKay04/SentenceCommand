using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyController : MonoBehaviour
{
    private PathCreator enemyPath;

    private EnemyGenerator enemySpawn;

    [SerializeField]
    private float speed = 5.0f;

    private float distanceTravelled;

    private void Start()
    {
        enemySpawn = GameObject.FindObjectOfType(typeof(EnemyGenerator)) as EnemyGenerator;
        enemyPath = enemySpawn.AssignPath();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = enemyPath.path.GetPointAtDistance(distanceTravelled);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Base")
        {
            destroyEnemy();
        }
    }

    public void destroyEnemy()
    {
        enemySpawn.decreaseEnemyCount();
        Destroy(this.gameObject);
    }
}
