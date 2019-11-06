using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDel : MonoBehaviour {
    public GameObject del;
    public GameObject destroyCollider;
    public bool closeDoor = false;



     void OnCollisionEnter(Collision collision)
    {
        closeDoor = true;
        Destroy(del);
        destroyCollider.transform.position = new Vector3(99, 99, 99);
    }
}
