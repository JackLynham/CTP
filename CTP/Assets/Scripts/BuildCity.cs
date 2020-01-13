using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{

    public GameObject[] buildings;
    public GameObject xstreets;
    public GameObject zstreets;
    public GameObject crossroad;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int[,] mapgrid;
    public int buildingFootprint = 3;

    public bool test;

    //Values for Generation 
    int result;
    Vector3 pos;

    void Start()
    {
        int seed = Random.Range(0, 100);
        Debug.Log(seed);
        //GENERATE MAP DATA
        mapgrid = new int[mapWidth, mapHeight]; // We want to create a grid the is aware of the Size of the grid


        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                mapgrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f, h / 10.0f) * 10);
            }
        }

        //BUILD STREETS
        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                mapgrid[x, h] = -1;
            }
            x += Random.Range(3, 3);   //Pick a random range for the X
            if (x >= mapWidth) break;
        }


        //CROSSROADS
        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapgrid[w, z] == -1)
                {
                    mapgrid[w, z] = -3;
                }
                else
                {
                    mapgrid[w, z] = -2;
                }

            }

            z += Random.Range(5, 20);
            if (z >= mapHeight) break;
        }
       

        GenRoads();
        GenBuildings();
      //  br.LookAt();

    }

    public void GenRoads()
    {
        //GEN CITY
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                result = mapgrid[w, h];

                pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);

                if (result < -2)
                {
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
                }
                else if (result < -1)
                {
                    Instantiate(xstreets, pos, xstreets.transform.rotation);
                }

                else if (result < 0)
                {
                    Instantiate(zstreets, pos, zstreets.transform.rotation);
                }
               
            }
        }

       
    }

    public void GenBuildings()
    {
        float seed = Random.Range(0, 100);
        Debug.Log(seed);
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {

                int result = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);  // Needs a Height and width in this Function
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);

                if (result < 0.5)

                    Instantiate(buildings[0], pos, Quaternion.identity);                                             //Instantiate Number of buildings Postion and Rotations

                else if (result < 1)

                    Instantiate(buildings[1], pos, Quaternion.identity);

                else if (result < 1.5)

                    Instantiate(buildings[2], pos, Quaternion.identity);

                else if (result < 2)

                    Instantiate(buildings[3], pos, Quaternion.identity);

                else if (result < 2.5)

                    Instantiate(buildings[4], pos, Quaternion.identity);

                else if (result < 3)

                    Instantiate(buildings[5], pos, Quaternion.identity);

                else if (result < 3.5)

                    Instantiate(buildings[6], pos, Quaternion.identity);

                else if (result < 4)

                    Instantiate(buildings[7], pos, Quaternion.identity);

                else if (result < 4.5)

                    Instantiate(buildings[8], pos, Quaternion.identity);

                else if (result < 5)

                    Instantiate(buildings[9], pos, Quaternion.identity);

                else if (result < 5.5)

                    Instantiate(buildings[10], pos, Quaternion.identity);

                else if (result < 6)

                    Instantiate(buildings[11], pos, Quaternion.identity);

                else if (result < 6.5)

                    Instantiate(buildings[12], pos, Quaternion.identity);

                else if (result < 7)

                    Instantiate(buildings[13], pos, Quaternion.identity);

                else if (result < 7.5)

                    Instantiate(buildings[14], pos, Quaternion.identity);

                else if (result < 8)

                    Instantiate(buildings[15], pos, Quaternion.identity);

                else if (result < 8.5)

                    Instantiate(buildings[16], pos, Quaternion.identity);

               test = true;


            }

        }
    }


//    public void LookAt()
//    {
       
//        // Store the other object's position in a temporary variable
//        var temp = xstreets.transform.position;
//        // Deflate it's x and z coordinate
//        temp.x = temp.z = uint.MinValue;
//        var lookRotation = Quaternion.LookRotation(temp);
//        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Damping * Time.deltaTime);
//    }
}

