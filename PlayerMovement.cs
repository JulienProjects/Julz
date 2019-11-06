using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Photon.MonoBehaviour
{

    private PhotonView PhotonView;

    private Vector3 TargetPosition;
    private Quaternion TargetRotation;
    public GameObject myCamera;
    public float jumpForce = 2f;
    //public bool isGrounded;
    public CapsuleCollider col;
    public AudioSource walkSound;
    public bool UseTransformView = true;
    public LayerMask groundLayers;
    private Rigidbody rb;
    private Animator anim;
    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        if (PhotonView.isMine)
        {
            myCamera.SetActive(true);
            //Cursor.lockState = CursorLockMode.Locked;
            rb = GetComponent<Rigidbody>();
            col = GetComponent<CapsuleCollider>();
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (PhotonView.isMine)
            CheckInput();
        else
            SmoothMove();
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) //My Game -> Partner Game
    {
        if (UseTransformView)
            return;
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            TargetPosition = (Vector3)stream.ReceiveNext();
            TargetRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    private void SmoothMove()
    {
        if (UseTransformView)
            return;
        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.25f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, 500 * Time.deltaTime);
    }

    private void CheckInput()
    {
        onEnterParticle colPartice = GameObject.Find("colParticle").GetComponent<onEnterParticle>();
        if ((GameController.gameState != GameController.GameState.inGame) || (!colPartice.moveAllowed) ) //check allowed to walk (Pause, startFall)
        {
            return;
        }
        float moveSpeed = 2f;
        //float rotationSpeed = 400f;

        float vertical = Input.GetAxis("Vertical"); //Get Input
        float horizontal = Input.GetAxis("Horizontal");
        //vertical *= Time.deltaTime;
        //horizontal *= Time.deltaTime;

        if (IsGrounded() && (vertical < 0.8 || horizontal < 0.8) && walkSound.isPlaying == false)
        {
            walkSound.Play(); //OnWalk Sound
        }
        if (vertical == 0 && horizontal == 0)
        {
            walkSound.Stop(); //Sound Walk Stop
        }

        rb.position += vertical * transform.forward * Time.deltaTime * moveSpeed;  //move Forward/Backwards
        rb.position += horizontal * transform.right * Time.deltaTime * moveSpeed;  //move Right/Left
        //transform.Translate((horizontal * moveSpeed * Time.deltaTime), 0, (vertical * moveSpeed * Time.deltaTime));


        anim.SetFloat("Input", vertical);  //anim idle<->walk

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) //jump Space
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

       /* if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }*/

    }

    private bool IsGrounded() //check grounded -> Jump/WalkS
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .10f, groundLayers);
    }
}
