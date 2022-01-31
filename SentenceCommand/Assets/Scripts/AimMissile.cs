using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimMissile : MonoBehaviour
{
    [SerializeField]
    private GameObject cannon;
    [SerializeField]
    private Slider aimButton;

    private float previousRotation;

    // Start is called before the first frame update
    void Awake()
    {
        this.aimButton.onValueChanged.AddListener(this.OnAimChanged);

        this.previousRotation = this.aimButton.value;
    }


    void OnAimChanged(float newRotation)
    {
        float deltaRotation = newRotation - this.previousRotation;
        this.cannon.transform.Rotate (Vector3.forward * deltaRotation * -1);

        this.previousRotation = newRotation;
    }
}
