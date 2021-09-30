using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameOverManager gameOverManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            float enemyDistance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log(enemyDistance);
            gameOverManager.ShowWarning(enemyDistance);
            
        }
    }
}
