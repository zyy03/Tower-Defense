using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurrentBlueprint standardTurrent;
    public TurrentBlueprint missileTurrent;
    
    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurrent() {
        Debug.Log("Standard Turrent Purchased");
        buildManager.SelectTurrentToBuild(standardTurrent);
    }

    public void SelectMissileTurrent() {
        Debug.Log("Missile Turrent Purchased");
        buildManager.SelectTurrentToBuild(missileTurrent);
    }
}
