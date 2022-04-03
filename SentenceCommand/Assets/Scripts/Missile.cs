using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
        {   
        if (collider.gameObject.tag == "SceneEdge" || collider.gameObject.tag == "Enemy") {
            destroyMissile();
        }
    }

    public void destroyMissile() {
        Destroy(this.gameObject);
    }
}
