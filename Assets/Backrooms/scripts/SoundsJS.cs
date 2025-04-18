using UnityEngine;
using System.Collections;

public class SoundsJS : MonoBehaviour
{
    public AudioSource source; //Sesin kayna��.
    public AudioClip screamSound; //Sesimiz.    

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = screamSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Ses oynat�ld�");
            StartCoroutine(playSound());
        }
    }

    IEnumerator playSound()
    {
        source.Play();
        yield return new WaitForSeconds(5.25f);
        Destroy(gameObject);
    }

}
