using UnityEngine;

public class PlayerNoteScript : MonoBehaviour
{
    private NoteScript activeNote;

    [Tooltip("Sahnede 'InteractMessage' adlý UI GameObject'ini buraya sürükleyip býrakýn")]
    public GameObject interactMessage;

    void Start()
    {
        // 1) Inspector'tan atanmamýþsa sahneden bulmaya çalýþ
        if (interactMessage == null)
        {
            interactMessage = GameObject.Find("InteractMessage");
            if (interactMessage == null)
                Debug.LogError("PlayerNoteScript: 'InteractMessage' adlý bir GameObject bulunamadý. Inspector'dan atamayý unutmayýn veya isimleri kontrol edin!");
        }
        // 2) SetActive çaðrýsýný null-kontrolüyle sar
        interactMessage?.SetActive(false);
    }

    void Update()
    {
        // ancak gerçekten bir note objesindeysem E'ye basýnca Toggle
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
            // Eðer not açýksa kapat
            if (activeNote.GetNoteStatus())
                activeNote.ToggleNote();

            activeNote = null;
            interactMessage?.SetActive(false);
        }
    }
}
