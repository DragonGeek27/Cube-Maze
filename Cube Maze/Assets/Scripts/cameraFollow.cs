using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public int tran = 6;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        pos.x = Mathf.Lerp(transform.position.x, player.position.x, Time.deltaTime * tran);
        pos.y = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * tran);
        transform.position = pos;
    }
}
