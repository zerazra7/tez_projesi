using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli

public class SceneTransition : MonoBehaviour
{
    public string PoolroomsDemo; // Hangi sahneye ge�ilece�ini belirle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // E�er �arp��an obje "Player" tag'ine sahipse
        {
            SceneManager.LoadScene(PoolroomsDemo); // Belirtilen sahneye ge�i� yap
        }
    }
}