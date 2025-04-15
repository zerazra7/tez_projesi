using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class SceneTransition : MonoBehaviour
{
    public string PoolroomsDemo; // Hangi sahneye geçileceðini belirle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eðer çarpýþan obje "Player" tag'ine sahipse
        {
            SceneManager.LoadScene(PoolroomsDemo); // Belirtilen sahneye geçiþ yap
        }
    }
}