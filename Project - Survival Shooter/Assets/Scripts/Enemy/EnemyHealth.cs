using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Item[] _itemPrefabs;

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    public Transform dropPoint;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;

    bool isDead;
    bool isSinking;


    void Awake ()
    {
        //Menapatkan reference komponen
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
 
        //Set current health
        currentHealth = startingHealth;
    }


    void Update ()
    {
        //Check jika sinking
        if(isSinking)
        {
            //memindahkan object kebawah
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        //Check jika dead
        if(isDead)
            return;
 
        //play audio
        enemyAudio.Play ();
 
        //kurangi health
        currentHealth -= amount;
           
        //Ganti posisi particle
        hitParticles.transform.position = hitPoint;
 
        //Play particle system
        hitParticles.Play();
 
        //Dead jika health <= 0
        if(currentHealth <= 0)
        {
            Death ();
        }
    }

    void Death ()
    {
        randomDrop();
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
    
    private void randomDrop()
    {
        int randomIndex = Random.Range(0, _itemPrefabs.Length);
        Instantiate(_itemPrefabs[randomIndex].gameObject, dropPoint.position, dropPoint.rotation);
    }

}
