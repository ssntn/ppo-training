using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    MoveBrain playerAI;
    void Start()
    {
        player = GameManager.instance.Player;
        playerAI = player.GetComponent<MoveBrain>();

        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!gameObject.activeSelf) return;

        if(other.gameObject.CompareTag("Coin")) {
            playerAI.CoinHit();
            gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Safe") || other.gameObject.CompareTag("Block")) 
             gameObject.SetActive(false);
        
    }
    
}
