using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{

    public GameObject standardBorder;
    public GameObject HomingBorder;
    public GameObject SplitBorder;

    public GameObject ammoLabelStandard;
    public GameObject ammoLabelHoming;
    public GameObject ammoLabelSplit;

    public void selectStandard()
    {
        GlobalVars.SelectedAmmoType = GlobalVars.AmmoType.Standard;
        standardBorder.SetActive(true);
        HomingBorder.SetActive(false);
        SplitBorder.SetActive(false);
    }

    public void selectHoming()
    {
        GlobalVars.SelectedAmmoType = GlobalVars.AmmoType.Homing;
        standardBorder.SetActive(false);
        HomingBorder.SetActive(true);
        SplitBorder.SetActive(false);
    }

    public void selectSplit()
    {
        GlobalVars.SelectedAmmoType = GlobalVars.AmmoType.Split;
        standardBorder.SetActive(false);
        HomingBorder.SetActive(false);
        SplitBorder.SetActive(true);
    }

     public void updateValues()
    {
        ammoLabelStandard.transform.GetComponent<TMPro.TextMeshProUGUI>().text = GlobalVars.ammoStandard.ToString();
        ammoLabelHoming.transform.GetComponent<TMPro.TextMeshProUGUI>().text = GlobalVars.ammoHoming.ToString();
        ammoLabelSplit.transform.GetComponent<TMPro.TextMeshProUGUI>().text = GlobalVars.ammoSplit.ToString();
    }
}
