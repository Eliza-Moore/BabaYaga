using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerManager : MonoBehaviour
{
    public static List<int> collectionItems = new List<int>();
    public static Transform playerPosition;
    public static Inventory playerInventory;

    private void Awake()
    {
        playerPosition = GetComponent<Transform>();
        playerInventory = GetComponent<Inventory>();

        //PlayerPrefs.DeleteAll();
    }

    public void SaveGamePlayer()
    {
        Vector3 pl_pos = playerPosition.position;
        PlayerPrefs.SetFloat("playerPositionX", pl_pos.x);
        PlayerPrefs.SetFloat("playerPositionY", pl_pos.y);
        PlayerPrefs.Save();

        for (int i = 0; i < playerInventory.slot.Length; i++)
        {
            string item_name = "empty";
            GameObject inv_item = null;
            if (playerInventory.isFull[i])
            { 
                inv_item = playerInventory.slot[i].transform.GetChild(0).gameObject; 
            }
            if (inv_item != null)
            {
                item_name = inv_item.name.Substring(0, inv_item.name.Length - 7);
            }
            PlayerPrefs.SetString("playerInventorySlot_" + i, item_name);
        }
    }

    public void LoadGamePlayer()
    {
        if (PlayerPrefs.HasKey("playerPositionX"))
        {
            float pl_pos_X = PlayerPrefs.GetFloat("playerPositionX");
            float pl_pos_Y = PlayerPrefs.GetFloat("playerPositionY");
            Vector3 pl_pos_new = new Vector3(pl_pos_X, pl_pos_Y);

            transform.position = pl_pos_new;
        }
        else 
        {
            Debug.Log("Нет сохранений позиции игрока.");
        }

        playerInventory.Clear();
        for (int i = 0; i < playerInventory.slot.Length; i++)
        {
            if (PlayerPrefs.HasKey("playerInventorySlot_" + i))
            {
                GameObject inv_item = null;
                string item_name = PlayerPrefs.GetString("playerInventorySlot_" + i);
                if (item_name != "empty")
                {
                    inv_item = Resources.Load("Prefab/Drafts/" + item_name, typeof(GameObject)) as GameObject;
                    playerInventory.isFull[i] = true;
                    Instantiate(inv_item, playerInventory.slot[i].transform);
                }
            }
            else
            {
                Debug.Log("Нет сохранений инвентаря.");
            }
        }
    }

}
