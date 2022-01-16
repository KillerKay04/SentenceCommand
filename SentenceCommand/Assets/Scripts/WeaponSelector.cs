using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{

    public GameObject standardBorder;
    public GameObject HomingBorder;
    public GameObject DuckfootBorder;

    public int selected = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("SelectedWeapon", selected);
    }

    public void selectStandard()
    {
        selected = 0;
        standardBorder.SetActive(true);
        HomingBorder.SetActive(false);
        DuckfootBorder.SetActive(false);
        updateSelectedPref();
    }

    public void selectHoming()
    {
        selected = 1;
        standardBorder.SetActive(false);
        HomingBorder.SetActive(true);
        DuckfootBorder.SetActive(false);
        updateSelectedPref();
    }

    public void selectDuckfoot()
    {
        selected = 2;
        standardBorder.SetActive(false);
        HomingBorder.SetActive(false);
        DuckfootBorder.SetActive(true);
        updateSelectedPref();
    }

    private void updateSelectedPref()
    {
        PlayerPrefs.SetInt("SelectedWeapon", selected);
    }
}
