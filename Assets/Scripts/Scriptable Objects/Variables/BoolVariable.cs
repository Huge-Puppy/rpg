using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public bool value;

}
