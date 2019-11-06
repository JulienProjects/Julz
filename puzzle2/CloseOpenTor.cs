using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenTor : MonoBehaviour {
    public GameObject torNameO;
    public GameObject torNameU;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(torNameO.name == "blauTorO" && torNameU.name == "blauTorU")
        {
            LeverFlash flash = GameObject.Find("leverB").GetComponent<LeverFlash>();
            if (!flash.CloseOpen)
            {
                torNameU.transform.position = new Vector3(torNameU.transform.position.x, -0.685f, torNameU.transform.position.z);
                torNameO.transform.position = new Vector3(torNameO.transform.position.x, 2, torNameO.transform.position.z);
            }
            else
            {
                torNameU.transform.position = new Vector3(torNameU.transform.position.x, 2, torNameU.transform.position.z);
                torNameO.transform.position = new Vector3(torNameO.transform.position.x, -0.685f, torNameO.transform.position.z);
            }
        }

        if (torNameO.name == "grunTorO" && torNameU.name == "grunTorU")
        {
            LeverFlash flash = GameObject.Find("leverG").GetComponent<LeverFlash>();
            if (!flash.CloseOpen)
            {
                torNameU.transform.position = new Vector3(torNameU.transform.position.x, -0.685f, torNameU.transform.position.z);
                torNameO.transform.position = new Vector3(torNameO.transform.position.x, 2, torNameO.transform.position.z);
            }
            else
            {
                torNameU.transform.position = new Vector3(torNameU.transform.position.x, 2, torNameU.transform.position.z);
                torNameO.transform.position = new Vector3(torNameO.transform.position.x, -0.685f, torNameO.transform.position.z);
            }
        }

        if (torNameO.name == "rotTorO" && torNameU.name == "rotTorU")
        {
            LeverFlash flash = GameObject.Find("leverR").GetComponent<LeverFlash>();
            if (!flash.CloseOpen)
            {
                torNameU.transform.position = new Vector3(torNameU.transform.position.x, -0.685f, torNameU.transform.position.z);
                torNameO.transform.position = new Vector3(torNameO.transform.position.x, 2, torNameO.transform.position.z);
            }
            else
            {
                torNameU.transform.position = new Vector3(torNameU.transform.position.x, 2, torNameU.transform.position.z);
                torNameO.transform.position = new Vector3(torNameO.transform.position.x, -0.685f, torNameO.transform.position.z);
            }
        }
    }
}
