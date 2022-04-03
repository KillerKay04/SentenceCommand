using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    private PathCreator enemyPath;

    private EnemyGenerator enemySpawn;

    [SerializeField]
    private float speed = 5.0f;

    private float distanceTravelled;

    //to call shield fade in/out
    private GameObject baseShield;

    // for sound effects (Audio Game Scene)
    private AudioGameScene ags;

    private void Start()
    {
        baseShield = GameObject.FindGameObjectWithTag("Base");

        enemySpawn = GameObject.FindObjectOfType(typeof(EnemyGenerator)) as EnemyGenerator;
        enemyPath = enemySpawn.AssignPath();
        // instantiate audio controller
        ags = GameObject.FindObjectOfType(typeof(AudioGameScene)) as AudioGameScene;
        // not certain this is the correct spot for this
        ags.PlayUFOSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = enemyPath.path.GetPointAtDistance(distanceTravelled);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("generating explosion...");
        Instantiate(explosion, this.transform.position, Quaternion.identity);

        if (collider.gameObject.tag == "Base") {
            //calls the setShielded method from Shield script
            baseShield.GetComponent<Shield>().setShielded();

            // if hits base, play damage sound
            // TODO, if base hit, but not destroyed play damaged
            // else play destroyed and end game.
            ags.PlayBaseDamaged();
            destroyEnemy();

        }
        else if (collider.gameObject.tag == "Cannon") {
            ags.PlayUFOHit();
            destroyEnemy();
        }
    }

    public void destroyEnemy()
    {
        enemySpawn.decreaseEnemyCount();
        Destroy(this.gameObject);
    }

  
}
