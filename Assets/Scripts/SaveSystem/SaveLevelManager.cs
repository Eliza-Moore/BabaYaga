using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevelManager : MonoBehaviour
{
    public static LevelChanger levelToLoad;

    private void Awake()
    {
        levelToLoad = GetComponent<LevelChanger>();

        //PlayerPrefs.DeleteAll();
    }

    public void SaveGameLevel()
    {
        PlayerPrefs.SetInt("levelToLoadID", levelToLoad.currentLevel);
        PlayerPrefs.Save();
    }

    public void LoadGameLevel()
    {
        if (PlayerPrefs.HasKey("levelToLoadID"))
        {
            int levelID = PlayerPrefs.GetInt("levelToLoadID");

            //SceneManager.LoadScene(levelID);
        }
        else
        {
            Debug.Log("Нет сохранений локации.");
        }
    }
}
