using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRotation : MonoBehaviour
{
    //    public GameObject xstreets;
    //    private float damping;
    //    public void LookAt()
    //    {

    //        // Store the other object's position in a temporary variable
    //        var temp = xstreets.transform.position;
    //        // Deflate it's x and z coordinate
    //        temp.x = temp.z = uint.MinValue;
    //        var lookRotation = Quaternion.LookRotation(temp);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, damping * Time.deltaTime);
    //    }




    public float halfAngleOfView = 180f;
    private void Update()
    {
        FindClosestEnemy();

    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            if (Vector3.Angle(transform.forward, go.transform.position - position)
                >= halfAngleOfView)

                continue;



            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Debug.Log(closest);
        return closest;
    }

    // public List<Transform> targets;
    // private string objectTag = "Respawn";
    // private Transform roads;
    // private Transform selectedObject;
    // private GameObject g;
    // private BuildCity bc;
    //// Transform xStreets;

    // public  void Awake()
    // {
    //     g= GameObject.Find("City Manager");
    //     bc = g.GetComponent<BuildCity>();
    // }
    // void Start()
    // {
    //     targets = new List<Transform>();
    //     roads = transform;
    //     AddAllObjects();
    // }
    // private void Update()
    // {
    //     if (bc.test)
    //     {

    //         SortTargetsByDistance();
    //         bc.test = false;
    //     }
    // }

    // public void AddAllObjects()
    // {
    //    GameObject[] gos;
    //     gos = GameObject.FindGameObjectsWithTag("Respawn");

    //     foreach (GameObject go in gos)
    //       AddTarget(roads.transform);
    // }

    // public void AddTarget(Transform roads)
    // {
    //     targets.Add(roads);
    // }

    // private void SortTargetsByDistance()
    // {
    //     targets.Sort(delegate (Transform t1, Transform t2) {
    //         return Vector3.Distance(t1.position, roads.position).CompareTo(Vector3.Distance(t2.position, roads.position));
    //     });
    //     selectedObject = targets[0];
    // }


}
