using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public static float speed = 5f;
    Vector2 movementSpeed = new Vector2(speed,speed);
    Vector3 movement;
    ScoreManager c_sm;
    public GameObject canvasGO;
    
    void Awake() {
          
    }

    // Start is called before the first frame update
    void Start()
    {        
        c_sm = canvasGO.GetComponent<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movementSpeed.x * inputX, movementSpeed.y * inputY, 0);
        movement *= Time.deltaTime;
        
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Coin"){
            c_sm.AddScore();
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

            foreach(GameObject c in coins){
                Destroy(c);
            }
            
        }
    }
    

}
