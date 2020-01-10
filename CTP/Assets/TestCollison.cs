using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollison : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
           
            this.enabled = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Road")
        {
             Debug.Log("Killmex2");
             Destroy(gameObject);
        }
    }
}
