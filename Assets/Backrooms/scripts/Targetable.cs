using UnityEngine;

public class Targetable : MonoBehaviour
{
    public GameObject infoObject;

    public void ToggleHiglight(bool status)
    {
        infoObject.SetActive(status);
    }

    
}
