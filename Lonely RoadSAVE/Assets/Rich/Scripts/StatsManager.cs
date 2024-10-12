using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public SaveingDataScriptable SDS;
    const string GameDataString = "GameDataString";
    void saveData() {
        string playerdata = SDS.GetData();
#if UNITY_EDITOR
        PlayerPrefs.SetString(GameDataString, playerdata);
#endif
    }
    void loadData() {
#if UNITY_EDITOR
        string newPlayerData =PlayerPrefs.GetString(GameDataString);
        Debug.Log(newPlayerData);
        SDS.SetData(newPlayerData);
#endif
    }

    private void Update() {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            saveData();
        }
        else if(Input.GetKeyDown(KeyCode.L)){ 
            loadData();
        }
#endif
    }
}
