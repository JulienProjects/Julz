using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFlash : MonoBehaviour
{

    public GameObject selectedObject;
    public GameObject activeObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;
    public bool click = false;

    public bool CloseOpen = false;


    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (lookingAtObject == true)
        {
            if (selectedObject.name == ("leverG") || (selectedObject.name == ("leverR")) || (selectedObject.name == ("leverB")))
            {
                selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
            }
                //klick.SetActive(true);
               
        }
    }
    void OnMouseOver()
    {
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        //Debug.Log(selectedObject);
       
            lookingAtObject = true;
        
        
        if (startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    void OnMouseDown()
    {
        if (anim.GetBool("leverOn"))
        {
            Debug.Log("off");
            CloseOpen = false;
            anim.SetBool("leverOn", false);
            
        }
        else
        {
            Debug.Log("on");
            anim.SetBool("leverOn", true);
            CloseOpen = true;
        }
        
    }

    void OnMouseExit()
    {
        lookingAtObject = false;
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        startedFlashing = false;
        
        StopCoroutine(FlashObject());

    }


    IEnumerator FlashObject()
    {
        while (lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn == true)
            {
                if (blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    blueCol -= 25;
                    greenCol -= 1;
                }
            }
            if (flashingIn == false)
            {
                if (blueCol >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    blueCol += 25;
                    greenCol += 1;
                }
            }
        }
    }
}
