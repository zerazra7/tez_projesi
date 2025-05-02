using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadGameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LoadGameText;  //hangi level yüklenecek.

    [SerializeField] Button LoadButton;


    void Awake()
    {
        if (string.IsNullOrWhiteSpace(PlayerPrefs.GetString("loaded level", " ")))
        { 
            LoadButton.interactable = false;   // yüklenecek level yoksa buttonla etkileþime geçeme.

        }
        else
        {
            LoadButton.interactable = true;
            LoadGameText.text = PlayerPrefs.GetString("loaded level", " ");

        }
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("loaded level"));
    }
}
