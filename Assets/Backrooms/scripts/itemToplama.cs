using UnityEngine;

public class itemToplama : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        // Sadece Player tag’li karaktere tepki ver
        if (other.CompareTag("Player"))
        {
            // Anahtarý/nesneyi yok et
            Destroy(gameObject);
        }
    }
}
