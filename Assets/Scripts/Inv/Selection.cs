using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Inventory inventory; // Ссылка на скрипт Inventory
    public GameObject selectedSlot; // Выбранный слот

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
        // Проверяем клик мыши
        /*if (Input.GetMouseButtonDown(0))
        {
            // Проверяем, что выбран слот инвентаря
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Slot"))
            {
                SelectSlot(hit.collider.gameObject);
            }
            else
            {
                // Если кликнули не на слоте, сбрасываем выделение
                DeselectSlot();
            }
        }*/
    }

    public void SelectSlot(GameObject slot)
    {
        // Сбрасываем предыдущее выделение, если есть
        DeselectSlot();

        // Выбираем новый слот
        inventory.selectedSlot = slot;
        //selectedSlot = slot;

        // Выводим название предмета в консоль
        string itemName = slot.transform.GetChild(0).name; // Предполагается, что у вас в слоте только один дочерний объект, представляющий предмет
        Debug.Log("Selected Item: " + itemName);
    }

    private void DeselectSlot()
    {
        // Сбрасываем предыдущее выделение
        if (selectedSlot != null)
        {
            // Снимаем визуальное выделение
            selectedSlot = null;
            Debug.Log("Deselected Slot");
        }
    }
}