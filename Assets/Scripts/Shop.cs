using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] Inventory shopInventory;
    [SerializeField] Inventory currentInventory;
    [SerializeField] MySignal shopSignal;

    void Start()
    {
        active = true;
    }

    void Update()
    {
        if (playerInRange && active && Input.GetKeyDown(KeyCode.Space))
        {
            currentInventory.myInventory = shopInventory.myInventory;
            shopSignal.Raise();
        }
    }
}
