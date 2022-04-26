using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    [SerializeField] GameObject enemySlotTemplate;
    [SerializeField] EnemyVariable currentEnemy;

    void Start()
    {
        InstantiateSlot();
    }

    void InstantiateSlot()
    {
        if (currentEnemy)
        {
            EnemySlot newSlot = Instantiate(enemySlotTemplate, transform.position, transform.rotation)
                .GetComponent<EnemySlot>();
            newSlot.transform.SetParent(transform);
            newSlot.Setup(currentEnemy.value);
        }
    }
    public void EnableBattleScene()
    {
        this.gameObject.SetActive(true);
    }
    public void DisableBattleScene()
    {
        this.gameObject.SetActive(false);
    }
}


