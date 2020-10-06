using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed,speedx;
    private Rigidbody rb;
    
    public bool isFinish;
 
    public bool isStart;
    private Animator anim;
    private Vector3 startpos;
    
    public GameObject percent;
    public GameObject opponents,obstacles;
    

    private float value;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();

        startpos = transform.position;
        
        transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (isFinish != true && isStart == true)
        {
            Move();
        }



    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            
            transform.position = startpos;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            
            isFinish = true;
            transform.position = new Vector3(0f, transform.position.y, transform.position.z); 
           
            Destroy(other.gameObject);
            Destroy(opponents);
            Destroy(obstacles);
            anim.SetBool("Run", false);
            percent.SetActive(true);

        }

    }


    public void startGame()
    {
        isStart = true;
        anim.SetBool("Run", true);
    }

   

    void Move()
    {
      
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
 
        Vector2 touchDeltaPosition = Vector2.zero;
        if (Input.touchCount > 0)
        {
            
            touchDeltaPosition = Input.GetTouch(0).deltaPosition * speedx;
            value = (touchDeltaPosition.x);
            
                if ((touchDeltaPosition.x) > 0 && transform.position.x < 1.9f)
                {
                    
                    transform.Translate(Vector3.right * value * Time.deltaTime);
                    
                }

                if ((touchDeltaPosition.x) < 0 && transform.position.x > -1.9f)
                {
                    transform.Translate(-(Vector3.left * value * Time.deltaTime));
                    
                }
            
            

        }

       
    }


    
}
