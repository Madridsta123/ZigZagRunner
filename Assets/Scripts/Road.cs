using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    
    public GameObject roadPrefab;
    public float offset = 0.7f;
    public Vector3 lastpos;
    private int roadCount = 0;
    
    public void Awake()
    {
        InvokeRepeating("CreateNewRoadpart", 1f, .5f);
    }

    // Start is called before the first frame update
    public void CreateNewRoadpart()
    {
        Debug.Log("CreateNewRoadpart");
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);

        if (chance < 50)
        {
            spawnPos = new Vector3(lastpos.x + offset, lastpos.y, lastpos.z + offset);

        }
        else
        {
            spawnPos = new Vector3(lastpos.x - offset, lastpos.y, lastpos.z + offset);

        }
        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastpos = g.transform.position;
        roadCount++;
        if(roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            CreateNewRoadpart();
        }
        
    }
   

}
