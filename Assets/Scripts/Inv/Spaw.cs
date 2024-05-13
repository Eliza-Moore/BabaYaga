using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw : MonoBehaviour
{
    public GameObject key; // Ссылка на префаб предмета, который будет храниться в инвентаре

    private Selection selectionScript;
    private Inventory inventoryScript;

    private void Start()
    {
        // Получаем ссылки на скрипты Selection и Inventory
        inventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //selectionScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Selection>();
        //inventoryScript = selectionScript.inventory;

        if (selectionScript == null || inventoryScript == null)
        {
            Debug.LogError("Selection or Inventory component not found on the Player!");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Ты тыкнула в дверь!");

        // Проверяем, есть ли сохраненное имя в скрипте Selection
        if (inventoryScript.selectedSlot != null)
        {
            Debug.Log("Ага, чо-то есть, щас проверим, совпадает ли имя!");

            string selectedItemName = inventoryScript.selectedSlot.transform.GetChild(0).name;

            // Проверяем, совпадает ли сохраненное имя с ключом объекта
            if (selectedItemName == key.name + "(Clone)")
            {
                Debug.Log("ОГО, КЛАСС, ИМЯ СОВПАЛО!");

                // Удаляем предмет из инвентаря
                for (int i = 0; i < inventoryScript.slot.Length; i++)
                {
                    if (inventoryScript.slot[i].transform.childCount > 0 && inventoryScript.slot[i].transform.GetChild(0).name == selectedItemName)
                    {
                        inventoryScript.isFull[i] = false;
                        Destroy(inventoryScript.slot[i].transform.GetChild(0).gameObject);
                        break;
                    }
                }

                // Удаляем предмет из скрипта Selection
                inventoryScript.selectedSlot = null;

                // Удаляем предмет со сцены
                Destroy(gameObject);
            }

            else 
            {
                Debug.Log("Сорян, имя не совпало!");
            }
        }
        else
        {
            Debug.Log("Возьми че-нить в инвентаре!");
        }
    }
}
