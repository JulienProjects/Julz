using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseOverDel : MonoBehaviour {
    public GameObject del;
    public AudioSource soundS;
    public PhotonView photonView;
    private bool playOnce = false;
     void OnMouseEnter()
    {
        if (!playOnce)
        {
            soundS.Play();
            StartCoroutine(delafterTime());
            playOnce = true;
        }
       
    }
    IEnumerator delafterTime()
    {
        yield return new WaitForSeconds(1.0f);
        photonView.RPC("delForAll", PhotonTargets.All);
    }

    [PunRPC]
    void delForAll()
    {
        Destroy(del);
    }
}
