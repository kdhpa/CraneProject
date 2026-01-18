using UnityEngine;

public class PlayerInteractionTrigger : MonoBehaviour
{
    private GameObject head;

    private bool isInteraction = false;
    private void Awake()
    {
        Transform trans = this.gameObject.transform.Find("Head");
        head = trans.gameObject;
    }
    private void FixedUpdate()
    {
        if (CheckInteraction())
        {
            isInteraction = true;
        }
        else
        {
            isInteraction = false;
        }
    }

    private bool CheckInteraction()
    {
        Vector3 foward_vec = head.transform.forward;
        Vector3 foward_direction = foward_vec.normalized;
        RaycastHit layer_hit = new RaycastHit();

        if ( Physics.Raycast(this.transform.position, foward_direction, out layer_hit, 1 , LayerMask.GetMask("Interaction") ) )
        {
            return true;
        }
        return false;
    }

}
