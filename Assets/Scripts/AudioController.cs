using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClipVariable currentAudioClip;
    [SerializeField] AudioClipVariable defaultAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSong();
    }

    // Update is called once per frame
    public void UpdateSong() {
        source.clip = currentAudioClip.value ?? defaultAudioClip.value;
        source.Play();
    }
}
