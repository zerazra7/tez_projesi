using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public Image jumpscareImage1, jumpscareImage2;
    public AudioClip jumpscareSound1, jumpscareSound2,jumpscareSound3, jumpscareSound4;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpscareArea"))
        {
            jumpscareImage1.enabled = true;
            audioSource.PlayOneShot(jumpscareSound1);
            StartCoroutine(CloseJumpscare());
        }

        if(other.gameObject.CompareTag("JumpscareArea2"))
        {
            jumpscareImage2.enabled = true;
            audioSource.PlayOneShot(jumpscareSound2);
            StartCoroutine(CloseJumpscare());
        }

        if (other.gameObject.CompareTag("JumpscareArea3"))
        {
            
            audioSource.PlayOneShot(jumpscareSound3);
        }

        if (other.gameObject.CompareTag("JumpscareArea4"))
        {

            audioSource.PlayOneShot(jumpscareSound4);
        }



    }

    private IEnumerator CloseJumpscare()
    {
        yield return new WaitForSeconds(1);
        jumpscareImage1.enabled=false;
        jumpscareImage2.enabled = false;
    }
}
