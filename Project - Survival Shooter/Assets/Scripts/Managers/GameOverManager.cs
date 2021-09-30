using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text Warning;
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;

    GameObject ScreenFade;

    Animator anim;                          
    float restartTimer;                    

    void Awake()
    {
        anim = GetComponent<Animator>();
        ScreenFade = GameObject.FindGameObjectWithTag("Gameover");
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        Warning.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        Debug.Log("Cek");
        anim.SetTrigger("Warning");
    }
}