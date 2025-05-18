using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadGameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LoadGameText;  //hangi level y�klenecek.

    [SerializeField] Button LoadButton;


    void Awake()
    {
        if (string.IsNullOrWhiteSpace(PlayerPrefs.GetString("loaded level", " ")))
        { 
            LoadButton.interactable = false;   // y�klenecek level yoksa buttonla etkile�ime ge�eme.

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
