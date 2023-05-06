using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    Rigidbody rb;
    public float JumpForce;
    bool canJump;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && canJump)
        {
            //jump 
            
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground"){
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            canJump = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }

}
