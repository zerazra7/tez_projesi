using UnityEngine;

public class RaycastActions : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    private Targetable currentTargetable;
    private Collactable currentCollactable;
    
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        if(Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.TryGetComponent(out Targetable targetable))
            {
                currentTargetable = targetable;
                currentTargetable.ToggleHiglight(true);
                if(currentTargetable.TryGetComponent(out Collactable collactable))
                {
                    currentTargetable= collactable;
                }
            }
            else if(currentTargetable)
            {
                currentTargetable.ToggleHiglight(false);
                currentTargetable = null;
                if(currentTargetable)
                {
                    currentTargetable = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(currentTargetable)
            {
                currentCollactable.Collect();
                currentCollactable = null;
            }
        }
        
    }
}
