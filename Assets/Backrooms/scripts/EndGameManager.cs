using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;
    [Header("UI")]
    public GameObject endPanel;        // Panel objesi
    public TextMeshProUGUI endText;    

    [Header("Settings")]
    public float displayDuration = 3f; // Ne kadar g�sterilsin?
    public string menuSceneName = "MainMenu"; 

    void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Gizle ba�ta
        if (endPanel != null) endPanel.SetActive(false);
    }

    public void ShowEndGame()
    {
        if (endPanel == null) return;

        endPanel.SetActive(true);
        // animasyon tetiklemek i�in: Animator.SetTrigger("Show");
        StartCoroutine(EndSequence());
    }

    private IEnumerator EndSequence()
    {
        // 1) Mesaj� g�ster
        yield return new WaitForSeconds(displayDuration);

        // 2) Oyunu bitir / Men�ye d�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        
    }
}
