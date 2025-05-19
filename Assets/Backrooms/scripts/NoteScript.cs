using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private bool noteStatus;
    public GameObject note;

    public void ToggleNote()
    {
        noteStatus = !noteStatus;
        note.SetActive(noteStatus);

        // Oyunu durdur / devam ettir
        if (noteStatus)
        {
            Time.timeScale = 0f; // Oyun durur
        }
        else
        {
            Time.timeScale = 1f; // Oyun devam eder
        }
    }

    public bool GetNoteStatus()
    {
        return noteStatus;
    }
}
