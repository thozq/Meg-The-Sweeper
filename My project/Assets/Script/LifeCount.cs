using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    [SerializeField] GameObject Gameover;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bomb")
            LoseLife();
    }
    public void LoseLife()
    {
        livesRemaining--;

        lives[livesRemaining].enabled = false;

        if(livesRemaining==0)
        {
            Debug.Log("GAME OVER");
            Gameover.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
}
