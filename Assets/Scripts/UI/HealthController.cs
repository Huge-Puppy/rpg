using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// TODO: break this up into a slider controller and several texts listening to values 
public class HealthController : MonoBehaviour
{
    [SerializeField] Stats playerStats;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider magicSlider;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI goldText;

    void Start()
    {
       UpdateHealthAndMagic();
    }

    public void UpdateHealthAndMagic() {
       healthSlider.value = playerStats.currentHealth.value / playerStats.maxHealth.value;
       magicSlider.value = playerStats.currentMagic.value / playerStats.maxMagic.value;
       goldText.text = "$" + Mathf.FloorToInt(playerStats.gold.value).ToString();
       levelText.text = playerStats.level.value.ToString();
    }
}
