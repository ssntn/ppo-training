using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject canvasGO;
    ScoreManager c_sm;
    
    [SerializeField]
    private GameObject player;
    PlayerController p;

    [SerializeField]
    private GameObject coin;
    private BoxCollider2D box;

    static Camera m_camera;
    static float halfHeight;
    static float halfWidth;

    private float horizontalMin;
    private float horizontalMax;
    private float verticalMin;
    private float verticalMax;
    private float borderSize;


    void Start()
    {
        c_sm = canvasGO.GetComponent<ScoreManager>();
        p = player.GetComponent<PlayerController>();
        box = coin.GetComponent<BoxCollider2D>();

        CameraSetup();
        NewPos(coin);
        
    }

    void Update()
    {
        if (p.P_PS == PlayerController.STATE.COINED) NewScore();
        if (p.P_PS == PlayerController.STATE.BLOCKED) RestartScore();
    }

    private void NewPos(GameObject go){
        Vector3 pos;

        do { pos  = RandomPos(); }
        while(Physics2D.OverlapBox(pos, box.size, 0f, coin.layer) != null);
        go.transform.position = pos;
    }

    private void NewScore(){
        c_sm.AddScore();
        NewPos(coin);
        p.P_PS = PlayerController.STATE.ACTIVE;
    }

    private void RestartScore()
    {
        c_sm.ResetScore();
        NewPos(player);
        p.P_PS = PlayerController.STATE.ACTIVE;
    }

    private void CameraSetup()
    {
        borderSize = 0.50f;
        m_camera = Camera.main;
        halfHeight = m_camera.orthographicSize;
        halfWidth = m_camera.aspect * halfHeight;
        horizontalMin = -halfWidth + borderSize;
        horizontalMax = halfWidth - borderSize;
        verticalMin = -halfHeight + borderSize;
        verticalMax = halfHeight - borderSize;
    }

    private Vector3 RandomPos()
    {
        return new Vector3(
            Random.Range(horizontalMin, horizontalMax),
            Random.Range(verticalMin, verticalMax),
            0
        );
    }

}
