using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{

    public GameObject standardBorder;
    public GameObject HomingBorder;
    public GameObject SplitBorder;

    public GameObject ammoLabelStandard;
    public GameObject ammoLabelHoming;
    public GameObject ammoLabelSplit;

    [SerializeField]
    private GameObject fireButton;

    private Color32 fireRed = new Color32(255, 0, 0, 255);
    private Color32 fireGreen = new Color32(0, 145, 46, 255);
    private Color32 fireYellow = new Color32(255, 174, 0, 255);

    public void selectStandard()
    {
        GlobalVars.SelectedAmmoType = GlobalVars.AmmoType.Standard;
        standardBorder.SetActive(true);
        HomingBorder.SetActive(false);
        SplitBorder.SetActive(false);
        fireButton.GetComponent<Image>().color = fireRed;
    }

    public void selectHoming()
    {
        GlobalVars.SelectedAmmoType = GlobalVars.AmmoType.Homing;
        standardBorder.SetActive(false);
        HomingBorder.SetActive(true);
        SplitBorder.SetActive(false);
        fireButton.GetComponent<Image>().color = fireGreen;
    }

    public void selectSplit()
    {
        GlobalVars.SelectedAmmoType = GlobalVars.AmmoType.Split;
        standardBorder.SetActive(false);
        HomingBorder.SetActive(false);
        SplitBorder.SetActive(true);
        fireButton.GetComponent<Image>().color = fireYellow;
    }

     public void updateValues()
    {
        ammoLabelStandard.transform.GetComponent<TMPro.TextMeshProUGUI>().text = GlobalVars.ammoStandard.ToString();
        ammoLabelHoming.transform.GetComponent<TMPro.TextMeshProUGUI>().text = GlobalVars.ammoHoming.ToString();
        ammoLabelSplit.transform.GetComponent<TMPro.TextMeshProUGUI>().text = GlobalVars.ammoSplit.ToString();
    }
}
