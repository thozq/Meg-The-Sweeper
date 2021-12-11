using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public Text FinalScore;
    public Text scorenext;
    public int score;

    public bool GameAktif = true;
    public GameObject Next;
    public GameObject Gameover;

    public float timeValue = 90;
    public Text timerText;

    [SerializeField] private AudioClip suarasampah;
    [SerializeField] private AudioClip suarabom;

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Update()
    {
        scoreText.text = score.ToString();
        FinalScore.text = "SCORE : " + score.ToString();
        scorenext.text = "SCORE : " + score.ToString();

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }

    void OnTriggerExit2D(Collider2D target)
    {
        
        if (target.tag == "sampah")
        {
           
            Destroy(target.gameObject);
            SoundManager.instance.PlaySound(suarasampah);
            score++;
        }
        if (target.tag == "bomb")
        {
            Destroy(target.gameObject);
            SoundManager.instance.PlaySound(suarabom);
        }
    }
    private void FixedUpdate()
    {
        if (GameAktif && timeValue <= 0)
        {
            if (score >= 30)
            {
                Next.SetActive(true);
                Gameover.SetActive(false);
                GameAktif = false;
                Time.timeScale = 0f;
            }
            else if (score < 30)
            {
                Gameover.SetActive(true);
                Next.SetActive(false);
                GameAktif = false;
                Time.timeScale = 0f;
            }
        }
    }

    public void Nextt()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
    }

}
