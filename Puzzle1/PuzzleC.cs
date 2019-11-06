using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleC : MonoBehaviour
{
    public int randomNumber = 0;
    public int puzzle = 0;
    public bool allowTo = true;
    public bool doorOpen = false;
    public GameObject color;
    void Start()
    {
        randomNumber = Random.Range(1, 100);
        puzzle = randomNumber;
        //Debug.Log(puzzle);
        if (puzzle < 32)
        {
            color.GetComponent<Renderer>().material.color = new Color32(69, 139, 116, 255); //g
            puzzle = 1;
        }

        else if (puzzle > 67)
        {
            color.GetComponent<Renderer>().material.color = new Color32(210, 105, 30, 255); //r
            puzzle = 2;
        }
        else
        {
            color.GetComponent<Renderer>().material.color = new Color32(54, 100, 139, 255); //b
            puzzle = 3;
        }


    }
    void Update()
    {

        SelectedFlash stone2 = GameObject.Find("stone2").GetComponent<SelectedFlash>();
        SelectedFlash stone6 = GameObject.Find("stone6").GetComponent<SelectedFlash>();
        SelectedFlash stone11 = GameObject.Find("stone11").GetComponent<SelectedFlash>();
        SelectedFlash stone3 = GameObject.Find("stone3").GetComponent<SelectedFlash>();
        SelectedFlash stone7 = GameObject.Find("stone7").GetComponent<SelectedFlash>();
        SelectedFlash stone12 = GameObject.Find("stone12").GetComponent<SelectedFlash>();
        SelectedFlash stone5 = GameObject.Find("stone5").GetComponent<SelectedFlash>();
        SelectedFlash stone8 = GameObject.Find("stone8").GetComponent<SelectedFlash>();
        SelectedFlash stone9 = GameObject.Find("stone9").GetComponent<SelectedFlash>();
        if (puzzle == 1)
        {
            //Debug.Log(stone6.active);
            // Debug.Log(stone2.active);
            if (stone2.active && stone6.active && stone11.active && allowTo)
            {
                if (stone3.active || stone7.active || stone12.active || stone5.active || stone8.active || stone9.active)
                {

                }
                else
                {

                    Debug.Log("door");
                    doorOpen = true;
                    puzzle = 999;
                }
            }
        }

        if (puzzle == 2)
        {
            //Debug.Log(stone3.active);
            // Debug.Log(stone7.active);
            // Debug.Log(stone.active);
            if (stone3.active && stone7.active && stone12.active && allowTo)
            {
                if (stone2.active || stone6.active || stone11.active || stone5.active || stone8.active || stone9.active)
                {

                }
                else
                {

                    Debug.Log("door");
                    doorOpen = true;
                    puzzle = 999;
                }
            }
        }


        if (puzzle == 3)
        {
            //Debug.Log(stone5.active);
            if (stone5.active && stone8.active && stone9.active && allowTo)
            {
                if (stone2.active || stone6.active || stone11.active || stone3.active || stone7.active || stone12.active)
                {

                }
                else
                {

                    Debug.Log("door");
                    doorOpen = true;
                    puzzle = 999;
                }
            }
        }
        SelectedFlash stone4 = GameObject.Find("stone4").GetComponent<SelectedFlash>();
        SelectedFlash stone10 = GameObject.Find("stone10").GetComponent<SelectedFlash>();
        if (stone4.active || stone10.active)
        {
            allowTo = false;
        }
        else
        {
            allowTo = true;
        }

    }

}
