using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SaveLevel : MonoBehaviour
{
    public GameObject SaveGameUI;
    [Range(1, 30)] public float timeBetweenSaves;

    void Awake()
    {
        InvokeRepeating(nameof(SaveGame), timeBetweenSaves, timeBetweenSaves);
    }

  
    public void SaveGame() 
    { 
        SaveGameUI.SetActive(true);
        // save mekanikleri
        PlayerPrefs.SetString("loaded level",SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();


        Invoke(nameof(hideUI),3);
    }

    public void hideUI()
    {
        SaveGameUI?.SetActive(false);
    }
}
