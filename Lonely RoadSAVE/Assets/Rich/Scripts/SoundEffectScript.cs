using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectScript : MonoBehaviour
{
    public AudioSource OwnSound;
    public SoundLibraryScriptable RandomAudio;
    public int audioToPlay,SFXGroup = 0;
    public int avilableAudios;
    public AudioClip cliptoplay;
    public float lifetime;
    private void Awake()
    {
        SFXGroup = (int)transform.position.z;
        OwnSound = GetComponent<AudioSource>();
        audioToPlay = UnityEngine.Random.Range(0, avilableAudios);
        cliptoplay = RandomAudio.SoundEffectGroups[SFXGroup].effect[audioToPlay];
        OwnSound.clip= cliptoplay;
        OwnSound.Play();
        //Debug.Log(cliptoplay.length);
    }
    private void FixedUpdate()
    {
        lifetime += 1 * Time.deltaTime;
        if(lifetime >= cliptoplay.length+0.5f) Destroy(this.gameObject);

    }
}
