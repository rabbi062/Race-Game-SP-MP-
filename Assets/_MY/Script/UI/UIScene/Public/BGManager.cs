using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PathologicalGames;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    #region SINGLETON

    public static BGManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region VARIABLE

    private Transform _transMainBg;
    private SpawnPool _spUIModules;

    #endregion


    #region Init METHOD

    private void Start()
    {
        _spUIModules = PoolManager.Pools["UIModulesPool"];
        InitBG();
    }

    private void InitBG()
    {
        _transMainBg = CreateBg("MainBg");
        _transMainBg.gameObject.SetActive(true);
    }
    
    #endregion
    
    Transform CreateBg(string prefabname)
    {
        Transform transTemp = _spUIModules.Spawn(prefabname);
        transTemp.SetParent(transform, false);
        transTemp.gameObject.SetActive(false);
        return transTemp;
    }
    
    
    #region PUBLIC METHOD

    public void Show()
    {
        _transMainBg.gameObject.SetActive (true);
    }

    public void Hide()
    {
        _transMainBg.gameObject.SetActive (false);
    }

    #endregion




}
