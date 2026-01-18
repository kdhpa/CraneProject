using UnityEngine;
using System;
using System.Collections;

public class Chain : MonoBehaviour
{
    private bool isCraining = false;
    void Start()
    {
        EventManager.Instance.AddEventListner("Crane", InteractButton);
    }

    private IEnumerator ScrollChain()
    {
        yield return new WaitForSeconds(1f);
    }

    private void InteractButton(object sender, EventArgs args)
    {
        isCraining = true;
    }
}
