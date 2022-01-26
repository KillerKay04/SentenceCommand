using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public enum AmmoType { Standard, Homing, Split };
    public static AmmoType SelectedAmmoType { get; set; } = AmmoType.Standard;


    public static int ammoStandard = 0;
    public static int ammoHoming = 0;
    public static int ammoSplit = 0;
}
