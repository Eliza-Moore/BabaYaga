using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw : MonoBehaviour
{
    public GameObject key; // ������ �� ������ ��������, ������� ����� ��������� � ���������

    private Selection selectionScript;
    private Inventory inventoryScript;

    private void Start()
    {
        // �������� ������ �� ������� Selection � Inventory
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
        Debug.Log("�� ������� � �����!");

        // ���������, ���� �� ����������� ��� � ������� Selection
        if (inventoryScript.selectedSlot != null)
        {
            Debug.Log("���, ��-�� ����, ��� ��������, ��������� �� ���!");

            string selectedItemName = inventoryScript.selectedSlot.transform.GetChild(0).name;

            // ���������, ��������� �� ����������� ��� � ������ �������
            if (selectedItemName == key.name + "(Clone)")
            {
                Debug.Log("���, �����, ��� �������!");

                // ������� ������� �� ���������
                for (int i = 0; i < inventoryScript.slot.Length; i++)
                {
                    if (inventoryScript.slot[i].transform.childCount > 0 && inventoryScript.slot[i].transform.GetChild(0).name == selectedItemName)
                    {
                        inventoryScript.isFull[i] = false;
                        Destroy(inventoryScript.slot[i].transform.GetChild(0).gameObject);
                        break;
                    }
                }

                // ������� ������� �� ������� Selection
                inventoryScript.selectedSlot = null;

                // ������� ������� �� �����
                Destroy(gameObject);
            }

            else 
            {
                Debug.Log("�����, ��� �� �������!");
            }
        }
        else
        {
            Debug.Log("������ ��-���� � ���������!");
        }
    }
}
