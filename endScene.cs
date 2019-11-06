using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScene : MonoBehaviour
{

    public PhotonView photonView;
    public GameObject myCamera;
    public GameObject anCamera;
    public Animator anim;
    public GameObject torEnd;
    public GameObject torEndClose;
    public Animator playerA;
    public Animator playerAT;
    public Animator playerBT;
    public GameObject alone;
    public GameObject together;
    public GameObject cross;
    public AudioSource sadS;
    private float walkV = 0;
    private bool walk = false;
    public Image blackScreen;
    public float time = 2f;
    public Animator fadeOut;
    public GameObject walkChar;
    public GameObject walkCharT;
    public GameObject walkCharT2;
    public GameObject Credits;
    public bool allLever = false;
    GameObject[] players;
    void Start()
    {
        photonView = GetComponent<PhotonView>();

    }

    public void OnCollisionEnter(Collision collision)
    {
        photonView.RPC("endAnimation", PhotonTargets.All);
    }
    void Update()
    {
        if (walk)
        {
            if (allLever)
            {
                walkCharT.transform.position = new Vector3(walkCharT.transform.position.x + walkV, walkCharT.transform.position.y, walkCharT.transform.position.z);
                walkCharT2.transform.position = new Vector3(walkCharT2.transform.position.x + walkV, walkCharT2.transform.position.y, walkCharT2.transform.position.z);
                walkV += 0.0001f;
            }
            else
            {
                walkChar.transform.position = new Vector3(walkChar.transform.position.x + walkV, walkChar.transform.position.y, walkChar.transform.position.z);

                walkV += 0.0001f;
            }
            photonView.RPC("FadeToBlack", PhotonTargets.All);

        }

    }
    [PunRPC]
    void endAnimation()
    {
        OpenEndTor open = GameObject.Find("torEnd").GetComponent<OpenEndTor>();
        allLever = open.allAktiv;
        if (allLever)
        {
            Debug.Log("finished together");
            //start end an together
            //PhotonNetwork.LoadLevel(2)

            myCamera.SetActive(false);
            anCamera.SetActive(true);
            together.SetActive(true);
            walk = true;
            cross.SetActive(false);
            playerAT.SetBool("walk", true);
            playerBT.SetBool("walk", true);
            anim.SetInteger("anB", 1);
            players = GameObject.FindGameObjectsWithTag("Player");
            Credits.SetActive(true);
            foreach (GameObject player in players)
            {
                Destroy(player);
            }
        }
        else
        {


            Debug.Log("finished alone");
            //start end an alone

            myCamera.SetActive(false);

            anCamera.SetActive(true);
            alone.SetActive(true);

            walk = true;
            cross.SetActive(false);
            playerA.SetBool("walk", true);
            anim.SetInteger("anB", 2);

            torEnd.SetActive(false);
            torEndClose.SetActive(true);
            sadS.Play();
            players = GameObject.FindGameObjectsWithTag("Player");
            Credits.SetActive(true);
            foreach (GameObject player in players)
            {
                Destroy(player);
            }
        }
    }
    [PunRPC]
    void FadeToBlack()
    {
        if (fadeOut.GetBool("fade"))
        {
            return;
        }
        fadeOut.SetBool("fade", true);
    }
}
