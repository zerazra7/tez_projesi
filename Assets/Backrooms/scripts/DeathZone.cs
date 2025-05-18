using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    [Header("Game Over UI")]
    
    public GameObject gameOverPanel;

    [Header("Opsiyonel: Player Controller")]
    public MonoBehaviour playerController;

    private bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;
        if (other.CompareTag("Player"))
        {
            isDead = true;
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        Time.timeScale = 0f;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

      
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
        if (playerController != null)
            playerController.enabled = false;
    }
}
