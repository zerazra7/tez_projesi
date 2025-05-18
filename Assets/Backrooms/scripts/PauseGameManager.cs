using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
public class PauseGameManager : MonoBehaviour
{
    public TextMeshProUGUI LevelText;// bulunduðun level texti

    public GameObject PauseCanvas;

    public KeyCode PauseKey = KeyCode.Tab; // pause için basýlan tuþ

    bool isPaused;

    private void Update()
    {
        LevelText.text = SceneManager.GetActiveScene().name;

        if (Input.GetKeyUp(PauseKey)) 
        { 
            isPaused = !isPaused;

            if (!isPaused ) ResumeGame();
        }

        if (isPaused)
        {
            PauseCanvas.SetActive(true);

            Time.timeScale = 0;
            AudioListener.pause = true;

            Cursor.lockState = CursorLockMode.None; //cursor tekrar hareket edebilsin diye serbest býrakýlýr.
            Cursor.visible = true;

            Object.FindFirstObjectByType<FirstPersonController>().enabled = false; // disable the karakter.

        }else
        {
            PauseCanvas.SetActive(false);
        }

    }

    public void ResumeGame()
    {
        isPaused = false; //unpause the game

        Time.timeScale = 1;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked; //cursor tekrar hareket edebilsin diye serbest býrakýlýr.
        Cursor.visible = false;

        Object.FindFirstObjectByType<FirstPersonController>().enabled = true; // disable the karakter.
    }

    public void QuitGame()
    {
        isPaused = false; //unpause the game

        Time.timeScale = 1;
        AudioListener.pause = false;

        SceneManager.LoadScene("mainMenu");
    }

    public void RestartLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        
}
