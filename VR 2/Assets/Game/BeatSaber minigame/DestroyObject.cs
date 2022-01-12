using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private void Update() {
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 3){
            Destroy(gameObject);
        }
    }
}
