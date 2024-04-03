using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color noFundsColor;
    public Vector3 posOffest;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + posOffest;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // to prevent selection of nodes under menu
        {
            return;
        }
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        
        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        
        Destroy(turret); // get rid of old turret
        
        // build upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPos(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        
        Debug.Log("turret upgraded!");
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        
        // build turret
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPos(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Debug.Log("turret built.");
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // to prevent selection of nodes under menu
        {
            return;
        }
        
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor; // color the nodes when hovered over
        }
        else
        {
            rend.material.color = noFundsColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; // change color back to default
    }
}
