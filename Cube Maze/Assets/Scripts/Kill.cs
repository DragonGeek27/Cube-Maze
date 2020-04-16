using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public Charactercontroller characterController;
    public GameManager gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            characterController = other.gameObject.GetComponent<Charactercontroller>();
            characterController.enabled = false;
            other.gameObject.transform.position = gameManager.respawnPoint.transform.position;
            //characterController.enabled = true;
        }
        if (other.gameObject.tag != "Player")
        {
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        characterController.enabled = true;
    }
}
