using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AudioClip Variable", menuName = "Game/AudioClip Variable")]
public class AudioClipVariable : ScriptableObject
{
    public AudioClip value;
}
