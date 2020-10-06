using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
public class HorizontalObstacle : MonoBehaviour
{
    public float speed;
  
    public Transform[] waypoints;

    
    void Update()
    {
        
        patrol();
       
    }


    void patrol()
    {
        

       
        if (transform.position.x >= waypoints[0].transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (transform.position.x <= waypoints[1].transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
       

    }

}
