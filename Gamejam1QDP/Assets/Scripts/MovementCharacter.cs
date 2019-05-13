using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementCharacter : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody rb;
    public float speed;


    // private GameObject road;

    bool RotatedForward = false;
    bool RotatedRight = true;

    bool touchingRoad = true;

    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();

        score = 0;


    }


    //IEnumerator Delay ()
    //{

    //   yield return new WaitForSeconds(0.5f);

    //  KeyPressing();
    //}


    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * speed);
        //Player.transform.position += Vector3.forward * Time.deltaTime;

        rb.velocity = transform.forward * speed;

        //Player.transform.position += Vector3.forward * speed;
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //}

        // void KeyPressing ()
        //{ 


        if (Input.GetKeyDown("space") && RotatedForward)
        {
            
            Rotate(90);
            RotatedForward = false;
            RotatedRight = true;
            Debug.Log("rotated from right to forward");
            score = score + 1;
            Debug.Log("score = " + score);

            // rb.velocity = transform.forward * speed;

            //Delay();

        }

        else
        if (Input.GetKeyDown("space") && RotatedRight)
        
        { 
                Rotate (-90);
                RotatedRight = false;
                RotatedForward = true;
                Debug.Log("rotated from forward to right");
            score = score + 1;
            Debug.Log("score = " + score);


            //  rb.velocity = transform.right * speed;

            //Delay();

        }

        



        //  road = gameObject.CompareTag("road");
        //  float dist = Vector3.Distance(road.position, transform.position);
        // print("Distance to road: " + dist);


    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider other)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.CompareTag ("road"))
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("player is on road");
        }

        if (other.gameObject.CompareTag("barrier"))
        {
            Debug.Log("player has left road");
            SceneManager.LoadScene("LosingScreen");
        }
        if (other.gameObject.CompareTag("Win"))
        {
            Debug.Log("player has won");
            SceneManager.LoadScene("WinningScreen");
        }

        if (other.gameObject.CompareTag("SpeedUp"))
        {
            speed = speed + 1f;
            Debug.Log("speed is up");
        }

    }

    void Rotate (int r)
    {
        transform.Rotate(new Vector3(0,r,0));

        
    }

  //  void OnTriggerEnter(Collider other)
  //  {
   //     if (other.tag == "road")
   //     {
   //         touchingRoad = true;
   //         Debug.Log("player is on road");
   //     }
   // }

 //   void OnTriggerExit(Collider other)
 //   {
 //       if (other.tag == "road")
 //       {
 //           touchingRoad = false;
 //           Debug.Log("player has left road");
 //           SceneManager.LoadScene("LosingScreen", LoadSceneMode.Additive);
 //       }
 //   }

    

    


}
