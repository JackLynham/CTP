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

    void Start()
    {
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

        float seed = Random.Range(0,100);
        Debug.Log(seed);
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {

                int result = mapgrid[w, h]; 
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);

                if(result < -2)
                {
                    Instantiate(crossroad,pos,crossroad.transform.rotation);
                }
                else if(result < -1)
                {
                    Instantiate(xstreets, pos, xstreets.transform.rotation);
                }

                else if (result < 0)
                {
                    Instantiate(zstreets, pos, zstreets.transform.rotation);
                }
                else if (result < 2)

                    Instantiate(buildings[0], pos, Quaternion.identity);  //Instantiate Number of buildings Postion and Rotations

                else if (result < 3)

                    Instantiate(buildings[1], pos, Quaternion.identity);

                else if (result < 5)

                    Instantiate(buildings[2], pos, Quaternion.identity);

                else if (result < 6)

                    Instantiate(buildings[3], pos, Quaternion.identity);

                else if (result < 7)

                    Instantiate(buildings[4], pos, Quaternion.identity);

                else if (result < 10)

                    Instantiate(buildings[5], pos, Quaternion.identity);
            }
        }


    }



}

