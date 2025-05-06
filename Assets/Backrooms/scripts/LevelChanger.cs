using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{

    // new game button için kullanýldý.?
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f; // zamaný normale döndürür.
        SceneManager.LoadScene(sceneName);
    }
}
