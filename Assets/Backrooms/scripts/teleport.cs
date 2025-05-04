using UnityEngine;
using UnityEngine.SceneManagement;

public class RingTeleporter : MonoBehaviour
{
    [Tooltip("Geçmek istediðin sahnenin tam adý")]
    public string sceneName = "Level 0";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
