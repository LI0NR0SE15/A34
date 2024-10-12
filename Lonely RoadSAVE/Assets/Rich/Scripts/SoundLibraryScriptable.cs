using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "EffectsAndMusicLibrary", menuName = "ScriptableObjects/EffectsAndMusicLibrary", order = 2)]
[System.Serializable]
public class effects
{
    public string effectType;
    public AudioClip[] effect;
}
public class SoundLibraryScriptable : ScriptableObject

{
    public AudioClip[] music;
    public effects[] SoundEffectGroups;

}
