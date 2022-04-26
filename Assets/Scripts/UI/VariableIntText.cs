using UnityEngine;
using TMPro;

public class VariableIntText : MonoBehaviour
{
    [SerializeField] MySignal updateSignal;
    [SerializeField] IntVariable currentValue;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        UpdateValue();
    }

    public void UpdateValue()
    {
        text.text = currentValue.value.ToString();
    }
}
