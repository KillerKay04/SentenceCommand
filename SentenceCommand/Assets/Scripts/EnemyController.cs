using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private PathCreator pathCreator;
    [SerializeField]
    private float speed = 5.0f;

    private float distanceTravelled;


    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Base")
        {
            Destroy(this.gameObject);
        }
    }
}
