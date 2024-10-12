using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "SaveProgress", menuName = "ScriptableObjects/SaveProgress", order = 1)]
public class SaveingDataScriptable : ScriptableObject
{

    public UnityEngine.Vector2 position;
    public float volume;
    public float soundEffects;
    public float illumination;
    public float progressPorsentage;
    [Header("1 is Spanish, 2 is english.")] public int lenguage;
    const string divider = "/";

    public string GetData() {
        StringBuilder DataToSave = new StringBuilder();
        DataToSave.Append(position);
        DataToSave.Append(divider);
        DataToSave.Append(volume);
        DataToSave.Append(divider);
        DataToSave.Append(soundEffects);
        DataToSave.Append(divider);
        DataToSave.Append(illumination);
        DataToSave.Append(divider);
        DataToSave.Append(progressPorsentage);
        DataToSave.Append(divider);
        DataToSave.Append(lenguage);
        return DataToSave.ToString();
    }
    public void SetData(string _data) {
        Debug.Log("saved data: " + _data);
        string[] dataDivided = _data.Split('/');
        for (int i = 0; i < dataDivided.Length; i++) {
            Debug.LogFormat("DATA{0} is haveing a value of: {1}", i, dataDivided[i]);
         }
        string[] vectorDivider = dataDivided[0].Split(',', '(', ')');
        position = new UnityEngine.Vector2(float.Parse(vectorDivider[1]), float.Parse(vectorDivider[2]));
        volume = float.Parse(dataDivided[1]);
        soundEffects = float.Parse(dataDivided[2]);
        illumination = float.Parse(dataDivided[3]);
        progressPorsentage = float.Parse(dataDivided[4]);
        lenguage = Int16.Parse(dataDivided[5]);

    }

}