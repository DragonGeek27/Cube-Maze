using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int timesHitY = 0;
    public int timesHitX = 0;
    public int timesHitZ = 0;
    public int rotationAngleY;
    public int rotationAngleX;
    public int rotationAngleZ;
    public GameObject maze;
    public float speed = 5;
    public GameObject player;

    public bool playerDirection = true;
    public GameObject respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //Cursor.visible = false;
        rotationAngleY = timesHitY * 90;
        rotationAngleX = timesHitY * 90;
        rotationAngleZ = timesHitY * 90;
    }

    // Update is called once per frame
    void Update()
    {
        maze.transform.rotation = Quaternion.Lerp(maze.transform.rotation,
            Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ), Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerDirection = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerDirection = false;
        }
        if (playerDirection == true)
        {
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation,
                Quaternion.Euler(0, 0, 0), Time.deltaTime * 100);
            

        }
        if (playerDirection == false)
        {
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation,
                Quaternion.Euler(0, 180, 0), Time.deltaTime * 100);
            

        }

        if (maze.transform.rotation == Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ))
        {
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
