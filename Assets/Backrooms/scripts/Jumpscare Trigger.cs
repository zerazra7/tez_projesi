using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public Animation JumpscareAnimation;

    public AudioSource JumpscareAudio;

    public AudioClip AudioClip;

    public void OnMouseOver()
    {
        JumpscareAnimation.Play();

        if (JumpscareAudio != null )
        {
            JumpscareAudio.PlayOneShot(AudioClip);
        }

        this.gameObject.SetActive( false );
    }
}
