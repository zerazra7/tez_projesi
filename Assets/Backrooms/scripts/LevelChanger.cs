using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{

    // new game button i�in kullan�ld�.?
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f; // zaman� normale d�nd�r�r.
        SceneManager.LoadScene(sceneName);
    }
}
