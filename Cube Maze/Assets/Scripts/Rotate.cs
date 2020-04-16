using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameManager gameManager;
    public bool left;
    public bool right;
    public bool upX;
    public bool downX;
    public bool upZ;
    public bool downZ;
    public bool y;
    public bool x;
    public bool z;
    public bool rotate = true;
    public GameObject player;
    public GameObject rightRotator;
    public GameObject leftRotator;
    //public int timesHit = 0;
    //public int rotationAngle;
    void Start()
    {

    }

    void Update()
    {
        //Rotate the player back to the previs side of the cube without having to leave the trigger
        if (rotate == false)
        {
            //Debug.Log("BLOOP");
            if (right == true)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                
                    leftRotator.SetActive(true);
                    rightRotator.SetActive(false);
                    right = false;
                    player.GetComponent<CharacterController>().enabled = false;
                    gameManager.timesHitY++;
                    gameManager.rotationAngleY = gameManager.timesHitY * 90;

                }
            }
            if (left == true)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                    leftRotator.SetActive(false);
                    rightRotator.SetActive(true);
                    left = false;
                    player.GetComponent<CharacterController>().enabled = false;
                    gameManager.timesHitY--;
                    gameManager.rotationAngleY = gameManager.timesHitY * 90;

                }

            }
        }
        //___________________________________________________

    }

    public void OnTriggerEnter(Collider other)
    {
        //Rotate the cube when you hit the trigger
        if (y == true) {
            if (other.gameObject.tag == "Left")
            {
                left = true;
                right = false;
            }
            if (other.gameObject.tag == "Right")
            {

                left = false;
                right = true;

            }
            if (rotate == true)
            {
                if (other.gameObject.tag == "Player")
                {
                    if (left == true)
                    {
                        leftRotator.SetActive(false);
                        left = false;
                        //Debug.Log("Left");
                        player.GetComponent<CharacterController>().enabled = false;
                        rotate = false;
                        gameManager.timesHitY--;
                        gameManager.rotationAngleY = gameManager.timesHitY * 90;

                    }
                    if (right == true)
                    {
                        rightRotator.SetActive(false);
                        right = false;
                        //Debug.Log(2);
                        player.GetComponent<CharacterController>().enabled = false;
                        rotate = false;
                        gameManager.timesHitY++;
                        gameManager.rotationAngleY = gameManager.timesHitY * 90;
                    }
                }
            }
            //________________________________________
        }
        if (x == true)
        {
            if (other.gameObject.tag == "Up")
            {
                upX = true;
                downX = false;
            }
            if (other.gameObject.tag == "Down")
            {

                upX = false;
                downX = true;

            }
            if (rotate == true)
            {
                if (other.gameObject.tag == "Player")
                {
                    if (upX == true)
                    {
                        upX = false;
                        //Debug.Log("Left");
                        player.GetComponent<CharacterController>().enabled = false;
                        rotate = false;
                        gameManager.timesHitX--;
                        gameManager.rotationAngleX = gameManager.timesHitX * 90;

                    }
                    if (downX == true)
                    {
                        downX = false;
                        //Debug.Log(2);
                        player.GetComponent<CharacterController>().enabled = false;
                        rotate = false;
                        gameManager.timesHitX++;
                        gameManager.rotationAngleX = gameManager.timesHitX * 90;
                    }
                }
            }
            //________________________________________
        }
        if (z == true)
        {
            Debug.Log("test3");
            if (other.gameObject.tag == "Up")
            {
                upZ = true;
                downZ = false;
            }
            if (other.gameObject.tag == "Down")
            {

                upZ = false;
                downZ = true;

            }
            if (rotate == true)
            {
                
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log("test4");
                    if (upZ == true)
                    {
                        upZ = false;
                        Debug.Log("test");
                        player.GetComponent<CharacterController>().enabled = false;
                        rotate = false;
                        gameManager.timesHitZ++;
                        gameManager.rotationAngleZ = gameManager.timesHitZ * 90;

                    }
                    if (downZ == true)
                    {
                        downZ = false;
                        Debug.Log("test2");
                        player.GetComponent<CharacterController>().enabled = false;
                        rotate = false;
                        gameManager.timesHitZ--;
                        gameManager.rotationAngleZ = gameManager.timesHitZ * 90;
                    }
                }
            }
            //________________________________________
        }
    }


    void OnTriggerExit(Collider other)
    {
        //reset rotate so can rotate on trigger
        if (other.gameObject.tag == "Player" && gameManager.maze.transform.rotation == Quaternion.Euler(0, gameManager.timesHitY * 90, 0))
        {
            Debug.Log(3);
            rotate = true;
            leftRotator.SetActive(true);
            rightRotator.SetActive(true);
        }
    }
}


