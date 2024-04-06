using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damage;
    public playerHealth playerHealth;
    public playerMovement playerMovement;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag== "Player") {
            playerMovement.KBFcounter = playerMovement.KBFTotalTime;
            if(collision.transform.position.x <= transform.position.x) {
                playerMovement.KnockFromRight = true;
            }
            if(collision.transform.position.x >= transform.position.x) {
                playerMovement.KnockFromRight = false;
            }           
            playerHealth.TakeDamage(damage);
        }
    }
}
