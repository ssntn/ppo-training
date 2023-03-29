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

    public GameObject coin;
    private BoxCollider2D box;

    static Camera m_camera;
    static float halfHeight;
    static float halfWidth;

    public static GameManager instance;


    void Start()
    {
        c_sm = canvasGO.GetComponent<ScoreManager>();
        p = player.GetComponent<PlayerController>();
        box = coin.GetComponent<BoxCollider2D>();       
    }

    void Update()
    {
        //if (p.P_PS == PlayerController.STATE.COINED) NewScore();
        //if (p.P_PS == PlayerController.STATE.BLOCKED) RestartScore();
    }

    private void NewPos(GameObject go){
        // Vector3 pos;
        // do { pos  = RandomPos(); }
        // while(Physics2D.OverlapBox(pos, box.size, 0f, coin.layer) != null);
        go.transform.localPosition = RandomPos();
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

    public Vector3 RandomPos()
    {
        return new Vector3(
            Random.Range(-0.31f, 4.487f), 
            Random.Range(0.012f, -2.22f), 
            0
        );
    }

}
