using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigData : MonoBehaviour
{
    public SaveingDataScriptable DataScriptableObject;
    public float volume, soundEffects, illumination;
    public int lenguage;
    public Slider vol, ill, SEf;
    public TMP_Dropdown leng;
    const string GameDataString = "GameDataString";
    public AudioMixer GeneralVolume;
    private void Awake()
    {
        PlayerPrefs.GetFloat("Volume", volume);
        PlayerPrefs.GetFloat("SoundEfectVolume", soundEffects);
        PlayerPrefs.GetFloat("IlluminationValue", illumination);
        PlayerPrefs.GetInt("Lenguage", lenguage);
        vol.value=DataScriptableObject.volume;
        SEf.value=DataScriptableObject.soundEffects;
        ill.value=DataScriptableObject.illumination;
        leng.value = DataScriptableObject.lenguage;
        GeneralVolume.SetFloat("MusicVolume", volume - 80);
        GeneralVolume.SetFloat("SoundFXVolume", soundEffects - 80);
    }
    public void changeVolume() {
        volume = vol.value;
        DataScriptableObject.volume = volume;
        GeneralVolume.SetFloat("MusicVolume", volume-80);
    }
    public void ChangeEffects() {
        soundEffects = SEf.value;
        DataScriptableObject.soundEffects = soundEffects;
        GeneralVolume.SetFloat("SoundFXVolume", soundEffects - 80);
    }
    public void ChangeLenguage() {
        lenguage = leng.value;
        DataScriptableObject.lenguage = lenguage;
        Debug.Log(leng.value);
    }
    public void changeIlumination() { 
        illumination = ill.value;
        DataScriptableObject.illumination=illumination;
    }
    public void GoToOtherScene() {
        string playerdata = DataScriptableObject.GetData();
        PlayerPrefs.SetString(GameDataString, playerdata);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void loadData()
    {
#if UNITY_EDITOR
        string newPlayerData = PlayerPrefs.GetString(GameDataString);
        Debug.Log(newPlayerData);
        DataScriptableObject.SetData(newPlayerData);
        vol.value = DataScriptableObject.volume;
        SEf.value = DataScriptableObject.soundEffects;
        ill.value = DataScriptableObject.illumination;
        leng.value = DataScriptableObject.lenguage;
#endif
    }
}
