using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 0.015f;

    private Vector3 endMarker;
    private PlayerMovement playerScript;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        endMarker = new Vector3(-135.699997f,-283.5f,0f);
        GameObject thePlayer = GameObject.Find("Player");
        playerScript = thePlayer.GetComponent<PlayerMovement>();

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -255) {
            transform.position = Vector3.MoveTowards(transform.position, endMarker, speed * Time.deltaTime);
        } else {
            rb.drag += 0.1f;
        }
    }
}
