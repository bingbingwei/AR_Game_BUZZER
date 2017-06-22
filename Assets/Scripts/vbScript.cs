using UnityEngine;
using Vuforia;
using System.Collections;
using System;

public class vbScript : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vb;
    public GameObject Button;
    private Vector3 buttonScale;
    private Boolean isStarted = false;


    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        if(!isStarted)
        {
            GameObject.Find("GameManager").SendMessage("BeginLevel");
            Debug.Log("Start!");
            isStarted = true;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
    }

    void Start()
    {
        vb.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        buttonScale = Button.transform.localScale;
    }

}
