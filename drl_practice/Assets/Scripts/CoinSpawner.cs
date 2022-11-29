using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;

    static Camera camera;
    static float halfHeight;
    static float halfWidth;

    float horizontalMin;
    float horizontalMax;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        Debug.Log("spawn coin");    
        Instantiate(coinPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
