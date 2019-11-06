using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{

    private Animator anim;
    public GameObject door;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnCollideDel del = GameObject.Find("delRoom1").GetComponent<OnCollideDel>();

        if (!del.closeDoor && door.name == "doorRoom1")
        {

            PuzzleC puzzle = GameObject.Find("PuzzleController").GetComponent<PuzzleC>();
            if (puzzle.doorOpen)
            {


                anim.SetBool("doorOpen", true);
            }

        }
        if (del.closeDoor && door.name == "doorRoom1")
        {

            //anim.SetBool("doorOpen", false);
            anim.SetBool("closeDoor", true);
        }

        OnCollideDel del2 = GameObject.Find("delRoom2").GetComponent<OnCollideDel>();
        if (del2.closeDoor && door.name == "doorRoom2")
        {
            anim.SetBool("closeOnly", true);
        }

        OnCollideDel del3 = GameObject.Find("delRoom3").GetComponent<OnCollideDel>();
        if (del3.closeDoor && door.name == "doorRoom3")
        {
            anim.SetBool("closeOnly", true);
        }
        if (del3.closeDoor && door.name == "doorBoth")
        {
            anim.SetBool("doorOpen", true);
        }
    }
}
