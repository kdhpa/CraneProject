using System;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField]
    private float maxValueX = 0.0035f;

    [SerializeField]
    private float minValueX = -0.0035f;

    [SerializeField]
    private float speed = 1f;

    public float tiltAngle = 15f;
    public float smoothSpeed = 10f;

    private Vector2 input_move_vec;

    private Transform hookPivot;

    private void Awake()
    {
        hookPivot = this.gameObject.transform.Find("HookPivot");
    }

    private void Start()
    {
        EventManager.Instance.AddEventListner<Vec2Args>("Move", SetMoveVec);
        EventManager.Instance.AddEventListner( "Crane", Interacte );
    }

    private void SetMoveVec(object sender, Vec2Args look)
    {
        Vec2Args vec2Args = look;
        Vector2 vec2 = vec2Args.vec;
        input_move_vec = vec2;
    }

    private void Update()
    {
        if ( input_move_vec.x != 0)
        {
            Vector3 pos = this.transform.localPosition;
            float input_x = input_move_vec.x;

            float next_y = pos.y + ( input_x * speed * Time.deltaTime);
            float y = Mathf.Clamp( next_y, minValueX, maxValueX );
            this.transform.localPosition = new Vector3(pos.x, y, pos.z);
        }

        float inputX = input_move_vec.x * -1;
        float inputY = input_move_vec.y * -1;
        Quaternion targetRotation = Quaternion.Euler(inputY * tiltAngle, 0, -inputX * tiltAngle);
        hookPivot.transform.localRotation = Quaternion.Slerp(hookPivot.transform.localRotation, targetRotation, Time.deltaTime * smoothSpeed);
    }

    private void Interacte(object sender , EventArgs args )
    {
        
    }
}
