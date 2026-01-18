using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public float tiltAngle = 15f; // 최대 기울기 각도 (도)
    public float smoothSpeed = 10f; // 움직임 부드러움 정도
    private Vector2 input_move_vec;
    void Start()
    {
        EventManager.Instance.AddEventListner<Vec2Args>("Move", SetMoveVec);
    }

    private void SetMoveVec(object sender, Vec2Args look)
    {
        Vec2Args vec2Args = look;
        Vector2 vec2 = vec2Args.vec;
        input_move_vec = vec2;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = input_move_vec.x * -1;
        float inputY = input_move_vec.y * -1;
        Quaternion targetRotation = Quaternion.Euler(inputY * tiltAngle, 0, -inputX * tiltAngle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothSpeed);
    }
}
