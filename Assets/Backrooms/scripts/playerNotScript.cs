using UnityEngine;

public class PlayerNoteScript : MonoBehaviour
{
    private NoteScript activeNote;

    [Tooltip("Sahnede 'InteractMessage' adl� UI GameObject'ini buraya s�r�kleyip b�rak�n")]
    public GameObject interactMessage;

    void Start()
    {
        // 1) Inspector'tan atanmam��sa sahneden bulmaya �al��
        if (interactMessage == null)
        {
            interactMessage = GameObject.Find("InteractMessage");
            if (interactMessage == null)
                Debug.LogError("PlayerNoteScript: 'InteractMessage' adl� bir GameObject bulunamad�. Inspector'dan atamay� unutmay�n veya isimleri kontrol edin!");
        }
        // 2) SetActive �a�r�s�n� null-kontrol�yle sar
        interactMessage?.SetActive(false);
    }

    void Update()
    {
        // ancak ger�ekten bir note objesindeysem E'ye bas�nca Toggle
        if (activeNote != null && Input.GetKeyDown(KeyCode.E))
            activeNote.ToggleNote();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            // NoteScript komponentini al
            activeNote = other.GetComponent<NoteScript>();
            if (activeNote == null)
            {
                Debug.LogError($"PlayerNoteScript: {other.name} objesinde NoteScript yok!");
                return;
            }
            interactMessage?.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note") && activeNote != null)
        {
            // E�er not a��ksa kapat
            if (activeNote.GetNoteStatus())
                activeNote.ToggleNote();

            activeNote = null;
            interactMessage?.SetActive(false);
        }
    }
}
