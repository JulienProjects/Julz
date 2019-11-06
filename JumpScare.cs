using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource sreamS;
    public GameObject playerCam;
    public GameObject trigger;
    public GameObject jumpCam;
    public GameObject flashIMG;
    public PhotonView photonView;
    public bool jump1 = false;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (jump1)
        {
            if (PhotonNetwork.isMasterClient)
            {

            }
            else
            {
                sreamS.Play();
                jumpCam.SetActive(true);

                //playerCam.SetActive(false);
                flashIMG.SetActive(true);
                StartCoroutine(EndJump());
            }
        }
        else
        {
            if (photonView.isMine)
            {
                sreamS.Play();
                jumpCam.SetActive(true);

                //playerCam.SetActive(false);
                flashIMG.SetActive(true);
                StartCoroutine(EndJump());
            }
        }


    }
    

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2f);
        Destroy(trigger);
        //playerCam.SetActive(true);
        jumpCam.SetActive(false);
        flashIMG.SetActive(false);
    }
}
