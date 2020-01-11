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
    public int buildingFootprint = 5;
    public int RandWidth = 3;
    public int RandHeight = 3;

    private int result;
    private Vector3 pos;
    private float seed;
    private void Awake()
    {
          GenerateRoad();
        CityGen();
       
    }
    private void Start()
    {
       seed = Random.Range(0, 100);
        Debug.Log(seed);
        

    }
    public void CityGen()
    {
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
               
                int result = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);  // Needs a Height and width in this Function
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                if (result < 2)

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

public void GenerateRoad()
    {
        #region generate map data
        mapgrid = new int[mapWidth, mapHeight];
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                mapgrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f, h / 10.0f) * 10);
            }
        }
        #endregion
        #region build streets
        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                mapgrid[x, h] = -1;
            }
            x += Random.Range(RandWidth, RandHeight);
            if (x >= mapWidth) break;
        }
        //place crossroad
        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapgrid[w, z] == -1)
                    mapgrid[w, z] = -3;
                else
                    mapgrid[w, z] = -2;
            }
            z += Random.Range(RandWidth, RandHeight);
            if (z >= mapHeight) break;
        }
        #endregion
        #region generate city
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapHeight; w++)
            {
                result = mapgrid[w, h];
                pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                if (result < -2)
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
                else if (result < -1)
                    Instantiate(xstreets, pos, xstreets.transform.rotation);
                else if (result < 0)
                    Instantiate(zstreets, pos, zstreets.transform.rotation);
            }
        }
        

        #endregion
    }

}

