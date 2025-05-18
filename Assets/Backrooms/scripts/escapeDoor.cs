using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    bool showMessage = false;
    float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("HasKeycard", 0) == 1)
        {
            EndGameManager.Instance.ShowEndGame();
        }
    }

    private void Update()
    {
        if (showMessage)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
                showMessage = false;
        }
    }

    private void OnGUI()
    {
        if (showMessage)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 35;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.black;

            Rect full = new Rect(0, 0, Screen.width, Screen.height);
            GUI.Label(full, "Tebrikler, kurtuldunuz!", style);
        }
    }
}
