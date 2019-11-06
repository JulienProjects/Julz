using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sens = 2.5f;
    public float smoothing = 1.5f;
    GameObject character;
    void Start()
    {
        character = this.transform.parent.gameObject;
        
    }

    void Update()
    {

        if (GameController.gameState != GameController.GameState.inGame) //allowed to move cam
        {
            return;
        }
        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
        sens = gameController.mouseSens; //get Sens from Pause Menu
        //Debug.Log("test");
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sens * smoothing, sens * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90); //lock y

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); //rotate Cam
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up); //rotate Cam


    }
}
