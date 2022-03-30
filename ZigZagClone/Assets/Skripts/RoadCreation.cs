using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreation : MonoBehaviour
{
    public GameObject RoadPrefab;
    public GameObject CrystalCr;
    public float offset = 0.707f;
    public Vector3 lastPos;
    private int roadCount = 0;
    // Start is called before the first frame update
    public void  StartBuilding()
    {
        InvokeRepeating("CreateNewPart", 1f, .1f);
    }
    public void CreateNewPart()
    {
        Vector3 spawnPos = Vector3.zero;
        Vector3 crspawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z - offset);
        }
        else
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z - offset);
        GameObject g = Instantiate(RoadPrefab, spawnPos, Quaternion.Euler(0, 225, 0));
        lastPos = g.transform.position;
        roadCount++;
        if (roadCount % 5 == 0)
        {
            crspawnPos = new Vector3(spawnPos.x, spawnPos.y + 0.64f, spawnPos.z);
            Instantiate(CrystalCr, crspawnPos, Quaternion.Euler(0, 225, 0));
            //g.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        CreateNewPart();
    //    }
        
    //}
}
