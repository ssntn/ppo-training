using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public static float speed = 20;
    Vector2 movementSpeed = new Vector2(speed,speed);
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movementSpeed.x * inputX, movementSpeed.y * inputY, 0);
        movement *= Time.deltaTime;
    }

    private void FixedUpdate() {
    
        transform.Translate(movement);
    }
}
