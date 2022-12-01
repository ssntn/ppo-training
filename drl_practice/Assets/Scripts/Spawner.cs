using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;
    private GameObject coin;
    CoinController coinScript;

    [SerializeField]
    private GameObject playerPrefab;
    public GameObject player;
    PlayerController playerScript;

    static Camera m_camera;
    static float halfHeight;
    static float halfWidth;

    float horizontalMin;
    float horizontalMax;
    float verticalMin;
    float verticalMax;
    float borderSize;

    int respawn_time;
    
    Vector3 player_pos;
    Vector3 coin_pos;

    
    void Start()
    {
        playerScript = playerPrefab.GetComponent<PlayerController>();
        
        respawn_time = 1;
        borderSize = 0.5f;

        if(GameObject.Find("Coin"))
            Destroy(GameObject.Find("Coin"));
            
        // if(GameObject.Find("Player"))
        //     Destroy(GameObject.Find("Player"));

        m_camera = Camera.main;
        halfHeight = m_camera.orthographicSize;
        halfWidth = m_camera.aspect * halfHeight;

        horizontalMin = -halfWidth + borderSize;
        horizontalMax = halfWidth - borderSize;

        verticalMin = -halfHeight + borderSize;
        verticalMax = halfHeight - borderSize;

        if(coin!=null) return; 
        coin = GameObject.Find("Coin");
        if(coin== null) Invoke("Spawn", respawn_time);

        if(player!=null) return;
        player = GameObject.Find("Player");
        if(player == null) Invoke("SpawnPlayer", respawn_time);
            
        
    }

    public void Spawn(){
        
        coin_pos = new Vector3(
            Random.Range(horizontalMin,horizontalMax),
            Random.Range(verticalMin, verticalMax),
            0
        );

        // Debug.Log(Vector3.Distance(player_pos, coin_pos)); RETURNS FLOAT
        
        if(gameObject == null) {
            Debug.Log("unbreakable");
            return;
        }        
        
        GameObject newCoin;
        newCoin = Instantiate(
            coinPrefab,
            coin_pos,
            Quaternion.identity
        );
        
        newCoin.name = "Coin";
    }
    public float getHorizontalMin(){return horizontalMin;}
    public float getHorizontalMax(){return horizontalMax;}
    public float getVerticalMin(){return verticalMin;}
    public float getVerticalMax(){return verticalMax;}
    public float getBorderSize(){return borderSize;}

    // public void SpawnPlayer(GameObject player){
    //     Debug.Log("Spawn");
    //     player_pos = new Vector3(
    //         Random.Range(horizontalMin,horizontalMax),
    //         Random.Range(verticalMin, verticalMax),
    //         0
    //     );
        
    //     GameObject newPlayer = player;
    //     newPlayer = Instantiate(
    //         player,
    //         player_pos,
    //         Quaternion.identity
    //     );

    //     newPlayer.name = "Player";
    // }


}
