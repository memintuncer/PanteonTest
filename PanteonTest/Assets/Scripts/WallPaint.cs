using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;
public class WallPaint : MonoBehaviour
{
    public Material red;
    public float paintCount;
    public float childcount;
    
    public TextMeshProUGUI percentage;
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        
        
        childcount = gameObject.GetComponentsInChildren<Transform>().Length-1;
    }

    // Update is called once per frame
    void Update()
    {
        percentage.text = "%" + ((paintCount / childcount) * 100).ToString("F0");
        if(paintCount / childcount == 1)
        {
            message.SetActive(true);
            StartCoroutine("Again");

        }
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                
                if (raycastHit.collider.tag == "wall")
                {
                    paintCount += 1;
                    raycastHit.collider.gameObject.GetComponent<MeshRenderer>().material = red;
                    raycastHit.collider.tag = "painted";
                }
               
            }
        }
        
    }


    IEnumerator Again()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
