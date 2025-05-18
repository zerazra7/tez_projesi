using UnityEngine;
using System.Collections;

public class SoundsJS : MonoBehaviour
{
    public AudioSource source; //Sesin kaynaðý.
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
            print("Ses oynatýldý");
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
