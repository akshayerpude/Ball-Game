using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;
    Rigidbody rb;

    //Transform pos;

    bool gameStarted;
    bool gameOver;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //pos = GetComponent<Transform>();
        gameStarted = false;
        gameOver = false;
    }
    void Start()
    {
       // rb.velocity = new Vector3(ballSpeed,0,0);
       transform.position = new Vector3(Random.Range(-4,4),1.19f,Random.Range(-4,4));
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(ballSpeed,0,0);
                gameStarted = true;
            }
        }

        Debug.DrawRay(transform.position,Vector3.down,Color.red);

        if(!Physics.Raycast(transform.position,Vector3.down,1f))
        {
            print("I am touching the platform");
            rb.velocity = new Vector3(0,-25f,0);
            gameOver = true;
            Invoke("ReloadScene",1f);
                       


        }

        if(Input.GetMouseButtonDown(0) && gameOver == false)
        {
            ChangeBallDirection();
        }
        
    }

    void ReloadScene()
    {
         SceneManager.LoadScene("SampleScene");
    }
    void ChangeBallDirection()
    {
        if(rb.velocity.z>0)
        {
            rb.velocity = new Vector3(ballSpeed,0,0);
        }
        else if(rb.velocity.x>0)
        {
            rb.velocity = new Vector3(0,0,ballSpeed);
        }
    }
}
