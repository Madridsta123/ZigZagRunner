using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody rb;
    public float speed;
    public GameObject CrystalEffect;
    
    public bool walkingRight = true;
    public Transform rayStart;
    private Animator anim;
    private gamemanager gamemanager;
    private Touch touch;
    

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gamemanager = FindObjectOfType<gamemanager>();
        

    }
    private void FixedUpdate()
    {
        if(!gamemanager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gameStarted");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movX = SimpleInput.GetAxis("Horizontal");
        float movY = SimpleInput.GetAxis("Vertical");


        //if (SimpleInput.GetKey(KeyCode.UpArrow) )
        //{
        //   transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
        if (gamemanager.gameStarted)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);      
        }
        

        if (SimpleInput.GetKey(KeyCode.DownArrow))
        {
            Switch();
        }
        if (Input.GetKey(KeyCode.D))
        {
             transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        
        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position,-transform.up,out hit,Mathf.Infinity))
        {
            anim.SetTrigger("isfalling");
            Debug.Log("Falling");
        }
        else
        {
            anim.SetTrigger("notfallinganymore");
        }
        if(transform.position.y < -2)
        {
            gamemanager.EndGame();
        }
    }

    
    public void up()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
    
   
    public void down()
    {
        Switch();
    }

    private void Switch()
    {
        walkingRight = !walkingRight;
        if(walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Crystal")
        {
            Destroy(other.gameObject);
            gamemanager.IncreaseScore();

            GameObject g = Instantiate(CrystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
