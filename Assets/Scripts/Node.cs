using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turrent;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition(){
        return transform.position + positionOffset;
    }

    void OnMouseDown(){
        if(!buildManager.CanBuild) return;
        if(turrent != null){
            Debug.Log("Cant Build There!");
            return;
        }
        buildManager.BuildTurrentOn(this);
    }

    void OnMouseEnter(){
        if(!buildManager.CanBuild) return; 

        if(buildManager.HasMoney){
            rend.material.color = hoverColor;
        }else{
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }
}
