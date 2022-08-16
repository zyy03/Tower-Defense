using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake(){
        if(instance != null){
            Debug.LogError("More than one buildManager!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurrentPrefab;
    public GameObject missileTurrentPrefab;

    private TurrentBlueprint turrentToBuild;

    public bool CanBuild{ get { return turrentToBuild != null; } }
    public bool HasMoney{ get { return PlayerStats.Money >= turrentToBuild.cost; } }

    public void BuildTurrentOn(Node node){
        if(PlayerStats.Money < turrentToBuild.cost){
            Debug.Log("Not Enough Money!");
            return;
        }
        PlayerStats.Money -= turrentToBuild.cost;
        GameObject turrent = (GameObject)Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turrent = turrent;

        Debug.Log("Turrent built! Monry Left: " + PlayerStats.Money);
    }

    public void SelectTurrentToBuild(TurrentBlueprint turrent){
        turrentToBuild = turrent;
    }
}
   
