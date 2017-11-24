using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text endText;
    public int maxScore;

    void Start()
    {
        scoreText.text = string.Format("Очки: {0}/{1}", 0, maxScore);
        endText.gameObject.SetActive(false);
    }

    public void ChangeScore(int score)
    {
        scoreText.text = string.Format("Очки: {0}/{1}", score, maxScore);
        if (score == maxScore)
        {
            endText.text = "Ты победил";
            endText.color = Color.green;
            endText.gameObject.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }

    public void Losse()
    {
        endText.text = "Ты проиграл";
        endText.color = Color.red;
        endText.gameObject.SetActive(true);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
