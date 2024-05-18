using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slot;
    public GameObject[] itemPrefabs; // Массив префабов предметов
    public GameObject selectedSlot;
    public GameObject inventory;
    private bool inventoryOn;

    private void Start()
    {
        inventoryOn = true;
    }

    public void Clear()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            isFull[i] = false;
            Destroy(slot[i].transform.GetChild(0).gameObject);
        }
    }


    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);

        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
