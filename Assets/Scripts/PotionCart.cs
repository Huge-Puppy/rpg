using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCart : MonoBehaviour
{
    [SerializeField] FloatValue currentHealth;
    [SerializeField] FloatValue currentMagic;
    [SerializeField] Stats playerStats;
    [SerializeField] MySignal shopSignal;
    [SerializeField] MySignal playerSignal;
    [SerializeField] bool inRange;

    public void Start()
    {
        inRange = false;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    public void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //shopSignal.Raise();
                if (playerStats.gold.value >= 5)
                {
                    currentHealth.value = (int)Mathf.Min((float)currentHealth.value + 5f, (float)playerStats.maxHealth.value);
                    currentMagic.value = (int)Mathf.Min((float)currentMagic.value + 5f, (float)playerStats.maxMagic.value);
                    playerStats.gold.value -= 5;
                    playerSignal.Raise();
                }
            }
        }
    }
}
