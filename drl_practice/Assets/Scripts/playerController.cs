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
    
    private CoinSpawner spawnerScr;
    public GameObject spawner;
   

    // Start is called before the first frame update
    void Start()
    {        
        c_sm = canvasGO.GetComponent<ScoreManager>();
        spawnerScr = spawner.GetComponent<CoinSpawner>();
        
    }

    void Update()
    {
        // MOVEMENT
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movementSpeed.x * inputX, movementSpeed.y * inputY, 0);
        movement *= Time.deltaTime;
        
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Coin"){
            c_sm.AddScore();
            Destroy(other.gameObject);

            Invoke("reCoin", 2.0f);
        }
    }

    public void setCoins(GameObject coinGO){
        // this.coinGO = coinGO;
        // coin = this.coinGO.GetComponent<CoinController>();
    }

    private void reCoin(){
        spawnerScr.Spawn();
    }
    

}
