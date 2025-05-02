using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerGameOver : MonoBehaviour
{
    [Header("Game Over UI Panel")]
    [SerializeField] private GameObject gameOverPanel;  // Inspector�dan s�r�kle

    private bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOver) return;
        if (other.CompareTag("Enemy"))
        {
            isGameOver = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        // 1) Zaman� durdur
        Time.timeScale = 0f;
        // 2) Paneli a�
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // --- A�a��dakileri UI Butonlar�na ba�la ---

    // New Game butonuna
    public void RestartGame()
    {
        // Zaman �l�e�ini normale d�nd�r
        Time.timeScale = 1f;
        // Ayn� sahneyi yeniden y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Exit Game butonuna
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        // Editor�da Play modunu kapat�r
        EditorApplication.isPlaying = false;
#endif
    }
}
