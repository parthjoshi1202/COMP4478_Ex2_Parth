//This script displays the Score on the screen 
//When the user collects a fish in the net, it increments the score
//If a bomb is collected in the net, the game is over and the game restarts in 3 seconds 
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text scoreText;
    int score = 0;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text> ();
        scoreText.text = "0";
    }

    void OnTriggerEnter2D (Collider2D target)
    {
        if(target.tag == "bomb")
        {
            transform.position = new Vector2(0, 100);
            target.gameObject.SetActive(false);
            scoreText.text = "Restarting";
            StartCoroutine(Restart());
        }


        if (target.tag == "fish")
        {
            target.gameObject.SetActive (false);
            score++;
            scoreText.text = score.ToString();
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
