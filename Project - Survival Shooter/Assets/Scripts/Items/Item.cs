using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float _boosterSpeed = 0f;
    public float _CboosterSpeed;
    public int _healHealth = 0;

    GameObject player;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        _CboosterSpeed = _boosterSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if(_boosterSpeed > 0f)
            {
                playerMovement.Boost(true);
                Destroy(gameObject);
            }

            if(_healHealth > 0)
            {
                if(playerHealth.currentHealth < 100)
                {
                    playerHealth.Heal(_healHealth);
                    Destroy(gameObject);
                } 
                else if(playerHealth.currentHealth > 99)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
