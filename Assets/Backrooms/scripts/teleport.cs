using UnityEngine;
using UnityEngine.SceneManagement;

public class RingTeleporter : MonoBehaviour
{
    [Tooltip("Ge�mek istedi�in sahnenin tam ad�")]
    public string sceneName = "Level 0";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
