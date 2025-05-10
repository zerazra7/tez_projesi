using UnityEngine;

public class itemToplama : MonoBehaviour
{
    public static bool hasKeycard = false;

    bool showMessage = false;
    float timer = 0f;
    bool picked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!picked && other.CompareTag("Player"))
        {
            picked = true;
            PlayerPrefs.SetInt("HasKeycard", 1);
            PlayerPrefs.Save();

            //sayacý baþlat
            showMessage = true;
            timer = 2f;

            // Mesh'i ve collider'ý kapat (görünmez + tekrar tetikleme yok)
            var rend = GetComponent<MeshRenderer>();
            if (rend) rend.enabled = false;
            var col = GetComponent<Collider>();
            if (col) col.enabled = false;

            // 2 saniye sonra nesneyi yokla
            Destroy(gameObject, 2f);
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

    // OnGUI ile ekranda label gösteriyoruz
    private void OnGUI()
    {
        if (showMessage)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 35;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.black;

            // Bütün ekraný kapsayan bir kutu:
            Rect fullScreenRect = new Rect(0, 0, Screen.width, Screen.height);
            GUI.Label(fullScreenRect, "KeyCard alýndý!", style);
        }
    }
}
