using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= minX)
        {
            transform.position = new Vector3(minX, 0, -10);
        }
        else if (player.transform.position.x >= maxX)
        {
            transform.position = new Vector3(maxX, 0, -10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, 0, -10);
        }

    }
}
