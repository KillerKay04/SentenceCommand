using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

    //[SerializeField]
    private GameObject homeBase;

    private GameObject closestEnemy;

    private float rotationSpeed = 250f;

    private float homingSpeed = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() 
    {
        homeBase = GameObject.FindGameObjectWithTag("Base");
        rb = GetComponent<Rigidbody2D>();

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0) 
        {
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
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (closestEnemy != null) 
        {
            Vector2 direction = (Vector2)closestEnemy.transform.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotationSpeed;
            rb.velocity = transform.up * homingSpeed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "SceneEdge") 
        {
            destroyMissile();
        }
    }

    public void destroyMissile() 
    {
        Destroy(this.gameObject);
    }
}