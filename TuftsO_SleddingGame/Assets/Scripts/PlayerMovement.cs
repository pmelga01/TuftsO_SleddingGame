using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0.015f;
    public  bool hasReachedGoal = false;
    private bool right = false;
    private bool middle = true;
    private bool left = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasReachedGoal) {
            transform.position += (transform.forward * speed * Time.deltaTime);
        }
        
        if (Input.GetButtonDown("Horizontal")) {
            float x = Input.GetAxis("Horizontal");
            
            if (!left && x < 0) {
                transform.position += new Vector3(-15, 0, 0);
                
                if (middle) {
                    middle = false;
                    left = true;
                }
                
                if (right) {
                    middle = true;
                    right = false;
                }
            }
            
            if (!right && x > 0) {
                transform.position += new Vector3(15, 0, 0);
                
                if (middle) {
                    middle = false;
                    right = true;
                }
                
                if (left) {
                    middle = true;
                    left = false;
                }
                
            }
            
        }
        
        
        //rb.velocity = rb.velocity * 0.5f * Time.deltaTime; 
    }
    
    void FixedUpdate() 
    {
        if (hasReachedGoal) {
            rb.velocity -= rb.velocity/20;
        }
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        hasReachedGoal = true;
    }
    
    void OnTriggerExit2D(Collider2D col) {
        rb.velocity = new Vector2(0.0f, 0f);
    }
    

    
}
