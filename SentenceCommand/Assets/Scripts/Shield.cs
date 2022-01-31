using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private bool isShielded = false;

    private float fadeOut = 0.99f;

    private Material shieldMat;

    // Start is called before the first frame update
    void Start()
    {
        //gets material from sprite renderer
        shieldMat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //if collision on trigger below will run shield animation via shader
        if (isShielded)
        {
            shieldMat.SetFloat("_ShieldFade", fadeOut);
            fadeOut -= Time.deltaTime;

            if (fadeOut <= 0f)
            {
                fadeOut = 0f;
                isShielded = false;
                Debug.Log("no longer shielded");
            }

        }

    }

    public void setShielded()
    {
        Debug.Log("shield called");
        isShielded = true;
        fadeOut = 0.99f;
        shieldMat.SetFloat("_ShieldFade", fadeOut);
    }
}
