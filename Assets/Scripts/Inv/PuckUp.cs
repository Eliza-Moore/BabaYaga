using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Добавляем директиву using для использования типа Button

public class PuckUp : MonoBehaviour
{
    private Inventory Inventory;
    public GameObject slotButtonPrefab;
    public float pickupRadius = 2f;
    private bool isPlayerInRange = false;

    private void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if (Inventory == null)
        {
            Debug.LogError("Inventory component not found on the Player!");
        }
        if (slotButtonPrefab == null)
        {
            Debug.LogError("Slot button prefab is not assigned!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerInRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                PickUpItem();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlayerInRange)
        {
            PickUpItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void PickUpItem()
    {
        if (Inventory == null || slotButtonPrefab == null)
        {
            Debug.LogError("Required component or object is missing!");
            return;
        }

        Debug.Log("Предмет подобран");

        for (int i = 0; i < Inventory.slot.Length; i++)
        {
            if (!Inventory.isFull[i])
            {
                Inventory.isFull[i] = true;
                Destroy(gameObject); // Уничтожаем объект на сцене до создания кнопки слота в инвентаре
                GameObject slotButton = Instantiate(slotButtonPrefab, Inventory.slot[i].transform);
                slotButton.GetComponent<Button>().onClick.AddListener(() => UseItem(slotButton));
                break;
            }
        }
    }

    private void UseItem(GameObject slotButton)
    {
        // Реализуйте здесь логику использования предмета на предмете на сцене
        Debug.Log("Предмет использован");
        Destroy(slotButton); // Удаляем кнопку предмета из инвентаря
        // Здесь можно добавить логику для удаления предмета на сцене или изменения его состояния
    }
}
