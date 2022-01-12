using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    Vector3 initialPos;

    private void Start() {
        initialPos = transform.position;
    }
    public void ResetBallPosition(){
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = initialPos;
    }
}