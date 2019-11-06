using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollideOpenN : MonoBehaviour {
    public PhotonView gameView;
    public bool openTurPlayer1 = false;
    public bool open = false;
    public bool close = false;
    public bool ratsel3 = false;
    void Start()
    {
        gameView = this.GetComponent<PhotonView>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        gameView.RPC("doorOpen", PhotonTargets.Others);

        
    }

    public void OnCollisionExit(Collision collision)
    {
        gameView.RPC("doorClose", PhotonTargets.Others);
       
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {

            stream.SendNext(open);
        }
        else
        {

            open = (bool)stream.ReceiveNext();
        }
    }
    [PunRPC]
    public void doorOpen()
    {
        //Debug.Log("col");
        ratsel3 = true;
        openTurPlayer1 = true;
        open = true;
        close = false;
    }

    [PunRPC]
    public void doorClose()
    {
        
        close = true;
        open = false;
    }
}
