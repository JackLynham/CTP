using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Buildings"))
        {
            Destroy(other.gameObject);
        }
    }
}

