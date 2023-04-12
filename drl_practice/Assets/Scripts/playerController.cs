using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject bulletPrefab;
    

    [SerializeField]
    private float bulletThrust;

    private Vector2 movementSpeed;
    private Vector3 movement;


    public enum STATE { ACTIVE, COINED, BLOCKED }
    private STATE s_player;
    public STATE P_PS { get { return s_player; } set { s_player = value; } }
   
    void Start()
    {
      s_player =  STATE.ACTIVE;
      speed = 4f;
      movementSpeed = new Vector2(speed,speed);
      bulletThrust = 5f;
    }

    void Update()
    {
        
    }

    /*
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Coin") s_player = STATE.COINED;
        if (other.tag == "Block") s_player = STATE.BLOCKED;
    }*/

   public void Move(float inputX, float inputY)
    {
        movement = new Vector3(movementSpeed.x * inputX, movementSpeed.y * inputY, 0);
        // transform.Translate(movement * Time.deltaTime);
        transform.localPosition += new Vector3(inputX, inputY) * Time.deltaTime * speed;
    }

    public void Shoot(float angle){

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dis = new Vector2(
                mousePos.x - transform.position.x,
                mousePos.y - transform.position.y
            );
        
        angle = Mathf.Atan2(
            mousePos.y - transform.position.y,
            mousePos.x - transform.position.x
        ) * Mathf.Rad2Deg;

        // GameObject bullet = Instantiate(
        //     bulletPrefab, transform.position, 
        //     Quaternion.Euler(0f, 0f, angle - 90f));

        GameObject bullet = BulletPool.SharedInstance.GetBullet();
        
        bullet.transform.position = gameObject.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        bullet.SetActive(true);
        

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dis.normalized * bulletThrust, ForceMode2D.Impulse);
    }


}
