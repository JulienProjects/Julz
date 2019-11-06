using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNetwork : MonoBehaviour
{

    private Animator anim;
    public int random;
    public GameObject tur;

    void Start()
    {
        anim = GetComponent<Animator>();
        random = Random.Range(1, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        onCollideOpenN Door = GameObject.Find("delRoom2").GetComponent<onCollideOpenN>();

        if (PhotonNetwork.isMasterClient && !Door.ratsel3)
        {
            return;
        }

        if (PhotonNetwork.isMasterClient && Door.openTurPlayer1 && tur.name == "doorR3")
        {
            anim.SetBool("doorMaster", true);
        }

        //onCollideOpenN plate1 = GameObject.Find("plate1").GetComponent<onCollideOpenN>();
        onCollideOpenN plate2 = GameObject.Find("plate2").GetComponent<onCollideOpenN>();
        //onCollideOpenN plate3 = GameObject.Find("plate3").GetComponent<onCollideOpenN>();
        onCollideOpenN plate4 = GameObject.Find("plate4").GetComponent<onCollideOpenN>();
        onCollideOpenN plate5 = GameObject.Find("plate5").GetComponent<onCollideOpenN>();
        //onCollideOpenN plate6 = GameObject.Find("plate6").GetComponent<onCollideOpenN>();
       // onCollideOpenN plate7 = GameObject.Find("plate7").GetComponent<onCollideOpenN>();
        onCollideOpenN plate8 = GameObject.Find("plate8").GetComponent<onCollideOpenN>();

        if (!PhotonNetwork.isMasterClient)
        {
            if (plate5.open && tur.name == "tor1R3")
            {
                anim.SetBool("openP", true);
            }
            if (plate5.close && tur.name == "tor1R3")
            {
                anim.SetBool("openP", false);
            }
        }

        
        if (!PhotonNetwork.isMasterClient)
        {
            if (plate2.open && tur.name == "tor2R3")
            {
                anim.SetBool("openP", true);
            }
            if (plate2.close && tur.name == "tor2R3")
            {
                anim.SetBool("openP", false);
            }
        }

        
        if (!PhotonNetwork.isMasterClient)
        {
            if (plate8.open && tur.name == "tor3R3")
            {
                anim.SetBool("openP", true);
            }
            if (plate8.close && tur.name == "tor3R3")
            {
                anim.SetBool("openP", false);
            }
        }

        
        if (!PhotonNetwork.isMasterClient)
        {
            if (plate4.open && tur.name == "tor4R3")
            {
                anim.SetBool("openP", true);
            }
            if (plate4.close && tur.name == "tor4R3")
            {
                anim.SetBool("openP", false);
            }
        }

    }
}


