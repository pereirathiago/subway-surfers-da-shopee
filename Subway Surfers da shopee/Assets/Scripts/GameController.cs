using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public float score;
    public int scoreCoin;

    public Text scoreText;
    public Text scoreCoinText;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            score += Time.deltaTime * 5f;
            scoreText.text = Mathf.Round(score).ToString() + 'm';
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    
    public void addCoin()
    {
        scoreCoin++;
        scoreCoinText.text = "Moedas: "+scoreCoin.ToString();
    }

    public void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
