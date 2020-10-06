using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float x, y, z;
    
    void Start()
    {
        transform.position = player.transform.position + new Vector3(x, y, -z);
    }

    void Update()
    {
        transform.position = player.transform.position+ new Vector3(x,  y,  - z);
        
        if (player.gameObject.GetComponent<PlayerController>().isFinish == true)
        {

            transform.position = new Vector3(0, 1, player.transform.position.z- 2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

  
}
