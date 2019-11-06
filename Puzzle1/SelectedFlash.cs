using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour {

    public GameObject selectedObject;
    public GameObject activeObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;
    public bool clicked = false;
    public bool active = false;
    private GameObject klick;

     void Start()
    {
        //klick =GameObject.FindWithTag("Klick");
        //klick.SetActive(false);
    }

    void Update () {
        PuzzleC puzzle = GameObject.Find("PuzzleController").GetComponent<PuzzleC>();
        if (puzzle.doorOpen)
            return;
        if (lookingAtObject == true)
        {
            //klick.SetActive(true);
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);        
        }
        if (active)
        {
            //klick.SetActive(true);
            selectedObject.GetComponent<Renderer>().material.color = new Color32(102, 205, 170, 255);
        }
	}
    void OnMouseOver()
    {
        PuzzleC puzzle = GameObject.Find("PuzzleController").GetComponent<PuzzleC>();
        if (puzzle.doorOpen)
            return;
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        //Debug.Log(selectedObject);
        lookingAtObject = true;
        if(startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
        if (clicked)
        {
            active = true;
            activeObject = selectedObject;
        }
        else
        {
            active = false;
        }
    }

    void OnMouseExit()
    {
        
        PuzzleC puzzle = GameObject.Find("PuzzleController").GetComponent<PuzzleC>();
        if (puzzle.doorOpen)
            return;
        //klick.SetActive(false);
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        
    }
     void OnMouseDown()
    {
        
        clicked = !clicked;
    }


    IEnumerator FlashObject()
    {
        while (lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.05f);
            if(flashingIn == true)
            {
                if(blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    blueCol -= 25;
                    greenCol -= 1;
                }
            }
            if(flashingIn == false) {
                if(blueCol >= 250)
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


