using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed;
    public AudioClip[] FootstepClips; // Ayak sesleri i�in ses dosyalar�
    public float StepInterval = 1f; // Her ad�m aras�nda ge�en s�re (saniye)

    private CharacterController _characterController;
    private AudioSource _audioSource;
    private float _stepTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
        _stepTimer = StepInterval;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
        // Karakter hareket ediyorsa ayak seslerini tetikle
        if (_characterController.isGrounded && _characterController.velocity.magnitude > 0.1f)
        {
            _stepTimer -= Time.deltaTime;

            if (_stepTimer <= 0f)
            {
                PlayFootstep();
                _stepTimer = StepInterval; // Zamanlay�c�y� s�f�rla
            }
        }
        else
        {
            // Karakter duruyorsa zamanlay�c�y� s�f�rla
            _stepTimer = StepInterval;
        }
    }

    private void PlayFootstep()
    {
        if (FootstepClips.Length > 0)
        {
            int index = Random.Range(0, FootstepClips.Length); // Rastgele bir ses se�
            _audioSource.PlayOneShot(FootstepClips[index]);    // Se�ilen sesi �al
        }
    }
}
