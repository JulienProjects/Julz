using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnterParticle : MonoBehaviour
{

    public ParticleSystem crack;
    public GameObject col;
    public AudioSource crackS;
    public bool moveAllowed = false;
    private bool playOnce = true;
    void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (playOnce)
            {
                crackS.Play();
            }
            crack.Play();
            col.transform.position = new Vector3(87, 87, 87);
            moveAllowed = true;
        }
        else
        {
            if (playOnce)
            {
                crackS.Play();
            }
            crackS.Play();
            crack.Play();
            col.transform.position = new Vector3(77, 77, 77);
            moveAllowed = true;
        }

    }

}
