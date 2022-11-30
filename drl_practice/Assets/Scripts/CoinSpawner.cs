using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;

    private GameObject coin;
    CoinController coinScript;


    static Camera camera;
    static float halfHeight;
    static float halfWidth;

    float horizontalMin;
    float horizontalMax;

    private bool destroyable = false;
    
    void Start()
    {
        if(GameObject.Find("Coin"))
            Destroy(GameObject.Find("CoinPrefab"));

        camera = Camera.main;
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
        

        if(coin==null) {

            coin=GameObject.Find("Coin");
            if(coin==null) {
                Spawn();
                coin=GameObject.Find("Coin");
            }
        }
        coinScript = coin.GetComponent<CoinController>();

        
    }

    public void Spawn(){
        
        if(gameObject == null) {
            Debug.Log("unbreakable");
            return;
        }        
        
        GameObject newCoin;
        newCoin = Instantiate(coinPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity
        );
        
        newCoin.name = "Coin";
        destroyable = false;

    }
}
