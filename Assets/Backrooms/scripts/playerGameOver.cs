using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerGameOver : MonoBehaviour
{
    [Header("Game Over UI Panel")]
    [SerializeField] private GameObject gameOverPanel;  // Inspector’dan sürükle

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
        // 1) Zamaný durdur
        Time.timeScale = 0f;
        // 2) Paneli aç
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // --- Aþaðýdakileri UI Butonlarýna baðla ---

    // New Game butonuna
    public void RestartGame()
    {
        // Zaman ölçeðini normale döndür
        Time.timeScale = 1f;
        // Ayný sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Exit Game butonuna
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        // Editor’da Play modunu kapatýr
        EditorApplication.isPlaying = false;
#endif
    }
}
