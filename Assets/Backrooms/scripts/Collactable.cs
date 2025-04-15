using UnityEngine;

public class Collactable : Targetable
{
    public virtual void Collect()
    {
        Destroy(this.gameObject);
    }
}
