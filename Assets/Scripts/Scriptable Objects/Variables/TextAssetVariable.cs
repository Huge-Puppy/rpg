using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TextAsset Variable", menuName = "Game/TextAsset Variable")]
public class TextAssetVariable : ScriptableObject
{
    public TextAsset value;
}
