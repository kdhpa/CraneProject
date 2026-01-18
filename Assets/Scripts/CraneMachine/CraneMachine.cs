using UnityEngine;

public class CraneMachine : MonoBehaviour, InteractionObject
{
    private Transform claw;
    private Transform joyStick;
    private Transform crainTrain;
    private Transform crainButton;

    private void Awake()
    {
        claw = this.gameObject.transform.Find("Hook");
        crainTrain = this.gameObject.transform.Find("Trail");
        
        joyStick = this.gameObject.transform.Find("JoyStick");
        crainButton = this.gameObject.transform.Find("Button");
    }

    public void Interact( bool isInteract )
    {
        
    }

}

public interface InteractionObject
{
    public void Interact( bool isInteract );
}
