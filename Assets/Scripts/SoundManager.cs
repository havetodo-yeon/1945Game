using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] eventSounds;
    static public SoundManager Instance;
    public AudioSource sound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void SetAudio(int num)
    {
        sound.PlayOneShot(eventSounds[num]);
    }
}
