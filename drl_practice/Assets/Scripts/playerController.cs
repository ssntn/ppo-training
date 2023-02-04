using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 movementSpeed;
    private Vector3 movement;

    private float inputX;
    private float inputY;

    public enum STATE { ACTIVE, COINED, BLOCKED }
    private STATE s_player;
    public STATE P_PS { get { return s_player; } set { s_player = value; } }
   
    void Start()
    {
      s_player =  STATE.ACTIVE;
      speed = 4f;
      movementSpeed = new Vector2(speed,speed);
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movementSpeed.x * inputX, movementSpeed.y * inputY, 0);
        transform.Translate(movement*Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Coin") s_player = STATE.COINED;
        if (other.tag == "Block") s_player = STATE.BLOCKED;
    }







    

}
