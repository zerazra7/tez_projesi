using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public Image jumpscareImage;
    public AudioClip jumpscareSound;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpscareArea"))
        {
            jumpscareImage.enabled = true;
            audioSource.PlayOneShot(jumpscareSound);
            StartCoroutine(CloseJumpscare());
        }
    }

    private IEnumerator CloseJumpscare()
    {
        yield return new WaitForSeconds(3);
        jumpscareImage.enabled=false;
    }
}
