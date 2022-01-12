using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] float areaRadius = 2f;
    [SerializeField] GameObject cube;
    float timer = 2f;
    bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isStarted = UIManager.instance.isGameStarted;

        if(isStarted){
            if(timer < 0){
                timer = Random.Range(0.3f,1f);
                float y = Random.Range( - areaRadius, areaRadius);
                float z = Random.Range(- areaRadius, areaRadius);

                Instantiate(cube, new Vector3(transform.position.x, transform.position.y + y, transform.position.z + z), Quaternion.identity);
            }
            timer -= Time.deltaTime;
        }
    }
}
