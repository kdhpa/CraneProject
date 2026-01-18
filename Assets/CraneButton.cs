using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CraneButton : MonoBehaviour
{

    public float minButtonValue = 0.09f;
    public float maxButtonValue = 0.1f;

    public float speed = 1f;
    void Start()
    {
        EventManager.Instance.AddEventListner( "Crane", InteractButton );
    }

    private void Update()
    {
        Vector3 localPosition = this.transform.localPosition;
        if ( localPosition.y < maxButtonValue)
        {
            Vector3 lerpPosition = Vector3.Slerp(localPosition, new Vector3(localPosition.x, maxButtonValue, 0), Time.deltaTime * speed);
            this.transform.localPosition = new Vector3(localPosition.x , Mathf.Clamp(lerpPosition.y, minButtonValue, maxButtonValue), Math.Clamp( lerpPosition.z, -0.006f , 0 ) );
        }
    }

    private void InteractButton(object sender, EventArgs args)
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x , minButtonValue, -0.006f );
    }
}


