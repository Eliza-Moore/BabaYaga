using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Inventory inventory; // ������ �� ������ Inventory
    public GameObject selectedSlot; // ��������� ����

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        selectedSlot = new GameObject();
        if (inventory == null)
        {
            Debug.LogError("Inventory component not found on the Player!");
        }
    }

    private void Update()
    {
        // ��������� ���� ����
        /*if (Input.GetMouseButtonDown(0))
        {
            // ���������, ��� ������ ���� ���������
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Slot"))
            {
                SelectSlot(hit.collider.gameObject);
            }
            else
            {
                // ���� �������� �� �� �����, ���������� ���������
                DeselectSlot();
            }
        }*/
    }

    public void SelectSlot(GameObject slot)
    {
        // ���������� ���������� ���������, ���� ����
        DeselectSlot();

        // �������� ����� ����
        inventory.selectedSlot = slot;
        //selectedSlot = slot;

        // ������� �������� �������� � �������
        string itemName = slot.transform.GetChild(0).name; // ��������������, ��� � ��� � ����� ������ ���� �������� ������, �������������� �������
        Debug.Log("Selected Item: " + itemName);
    }

    private void DeselectSlot()
    {
        // ���������� ���������� ���������
        if (selectedSlot != null)
        {
            // ������� ���������� ���������
            selectedSlot = null;
            Debug.Log("Deselected Slot");
        }
    }
}