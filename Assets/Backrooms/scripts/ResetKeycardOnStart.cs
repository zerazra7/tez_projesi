using UnityEngine;

public class ResetKeycardOnStart : MonoBehaviour
{
    // Static flag: uygulama aya�a kalkt���nda false, bir kez Reset edince true olur
    private static bool hasReset = false;

    void Awake()
    {
        // Sadece daha �nce hi� resetlenmediyse temizle
        if (!hasReset)
        {
            PlayerPrefs.DeleteKey("HasKeycard");
            // veya PlayerPrefs.SetInt("HasKeycard", 0);
            PlayerPrefs.Save();
            hasReset = true;
        }
    }
}
