using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingStones : MonoBehaviour {

    public GameObject trigger;
    public GameObject stone1;
    public GameObject stone2;
    public GameObject pos1;
    public GameObject pos2;


     void OnCollisionEnter(Collision collision)
    {
        Instantiate(stone1, pos1.transform.position, Quaternion.identity);
        Instantiate(stone2, pos2.transform.position, Quaternion.identity);
        trigger.SetActive(false);
    }
}
