using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioArea : MonoBehaviour
{
    [SerializeField] MySignal audioSignal;
    [SerializeField] AudioClipVariable currentAudioClip; 
    [SerializeField] AudioClip areaAudioClip;
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            currentAudioClip.value = areaAudioClip;
            audioSignal.Raise();
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            currentAudioClip.value = null; 
            audioSignal.Raise();
        }
    }
}
