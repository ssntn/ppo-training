using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public static float speed = 5f;
    Vector2 movementSpeed = new Vector2(speed,speed);
    Vector3 movement;
    ScoreManager c_sm;
    public GameObject canvasGO;
    
    private Spawner spawnerScr;
    public GameObject spawner;
    private bool destroyable;
   

    // Start is called before the first frame update
    void Start()
    {        
        c_sm = canvasGO.GetComponent<ScoreManager>();
        spawnerScr = spawner.GetComponent<Spawner>();
        
    }

    void Update()
    {
        // MOVEMENT
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movementSpeed.x * inputX, movementSpeed.y * inputY, 0);
        movement *= Time.deltaTime;
        
        transform.Translate(movement);
        // Debug.Log(gameObject.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Coin"){
            c_sm.AddScore();
            Destroy(other.gameObject);

            spawnerScr.Spawn();
        }else if (other.tag=="Block"){
            // c_sm.SubScore();
            NewPos();
        }
    }

    private void NewPos(){
        
        gameObject.transform.position = new Vector3(
            Random.Range(spawnerScr.getHorizontalMin(),spawnerScr.getHorizontalMax()),
            Random.Range(spawnerScr.getVerticalMin(), spawnerScr.getVerticalMax()),
            0
        );
    }





    

}
