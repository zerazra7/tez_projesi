using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public AudioClip escapeSound; // Inspector'dan vereceðiz
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("HasKeycard", 0) == 1)
        {
            if (escapeSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(escapeSound);
            }

            EndGameManager.Instance.ShowEndGame();
        }
    }
}
