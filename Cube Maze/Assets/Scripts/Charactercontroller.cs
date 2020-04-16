using UnityEngine;
using System.Collections;

public class Charactercontroller : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public GameObject flashLight;
    public float minimumAngle = -80F;
    public float maximumAngle = 80F;
    public GameManager gameManager;
    public GameObject light;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f);
        moveDirection.x = Input.GetAxis("Horizontal")*speed;// just get x dir
        if (characterController.isGrounded)
        {
            moveDirection.y = -10;
            // We are grounded, so recalculate
            // move direction directly from axes
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

        }
        //Debug.Log(moveDirection.y);
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;
        //Debug.Log(moveDirection);
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        //flashlight rotation
        Vector3 mouse = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(light.transform.position);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        

        //if (gameManager.PlayerDirection == true)
        //{
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //    angle = Mathf.Clamp(angle, minimumAngle, maximumAngle);
            flashLight.transform.rotation = Quaternion.Euler(-angle, 90, 0);
        //}
        //if (gameManager.PlayerDirection == false)
        //{
        //    var angle = Mathf.Atan2(-offset.y, -offset.x) * Mathf.Rad2Deg;
        //    angle = Mathf.Clamp(angle, minimumAngle, maximumAngle);
        //    flashLight.transform.rotation = Quaternion.Euler(angle, -90, 0);
        //}

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RespawnPoint")
        {
            gameManager.respawnPoint = other.gameObject;
        }
    }
}