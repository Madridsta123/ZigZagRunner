using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROY : MonoBehaviour
{
    [SerializeField]
    private BoxCollider br;
    // Start is called before the first frame update
    void Start()
    {
        br = this.GetComponent < BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(br, 5); 
    }
}
