using UnityEngine;

public class CanavarSes : MonoBehaviour
{
    public Transform oyuncu;
    public float sesMesafesi = 10f;
    public AudioClip sesKlip;
    private AudioSource sesKaynak;

    public float sesSuresi = 3f; // Sesin ne kadar çalacaðýný ayarla

    private bool sesCaldi = false;

    void Start()
    {
        sesKaynak = GetComponent<AudioSource>();
        sesKaynak.clip = sesKlip;
    }

    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, oyuncu.position);

        if (mesafe <= sesMesafesi && !sesCaldi)
        {
            sesKaynak.Play();
            Invoke("SesiDurdur", sesSuresi);
            sesCaldi = true;
        }
        else if (mesafe > sesMesafesi)
        {
            sesCaldi = false;
        }
    }

    void SesiDurdur()
    {
        sesKaynak.Stop();
    }
}
