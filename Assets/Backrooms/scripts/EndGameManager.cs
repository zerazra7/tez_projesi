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
    public float displayDuration = 3f; // Ne kadar gösterilsin?
    public string menuSceneName = "MainMenu"; 

    void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Gizle baþta
        if (endPanel != null) endPanel.SetActive(false);
    }

    public void ShowEndGame()
    {
        if (endPanel == null) return;

        endPanel.SetActive(true);
        // animasyon tetiklemek için: Animator.SetTrigger("Show");
        StartCoroutine(EndSequence());
    }

    private IEnumerator EndSequence()
    {
        // 1) Mesajý göster
        yield return new WaitForSeconds(displayDuration);

        // 2) Oyunu bitir / Menüye dön
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        
    }
}
