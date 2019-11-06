using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public PhotonView photonView;
    public AudioSource openS;
    public bool P1 = true;
	// Use this for initialization
	void Start () {
        openS = GameObject.Find("doorOpen").GetComponent<AudioSource>();
        photonView = GameObject.Find("doorOpen").GetComponent<PhotonView>();
    }
	
	// Update is called once per frame
	void Update () {
        if (P1)
        {
            PuzzleC puzzle1 = GameObject.Find("PuzzleController").GetComponent<PuzzleC>();
            if (puzzle1.doorOpen)
            {
                photonView.RPC("PlaySound", PhotonTargets.All, 1);
                
                P1 = false;
            }
        }
       
        
    }
    [PunRPC]
    public void PlaySound(int num)
    {
        if(num == 1)
        {
            openS.Play();
            Debug.Log("sound");
            P1 = false;
        }
    }
}
