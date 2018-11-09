﻿using UnityEngine;

public class GameManager : MonoBehaviour {
    private Player player;
    private UIManager iManager;
    private float time;

	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        iManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player.TotalIncrementSecond = 0;
    }
    void Update ()
    {
        //秒で増える
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            player.TotalIncrementSecond = player.Item1IncrementSecond * player.Item1Multiple;
            player.Score += player.TotalIncrementSecond;
            iManager.PersecondText.text ="PerSecond " +player.TotalIncrementSecond.ToString();
            iManager.ScoreText.text = player.Score.ToString() + " User";
            time = 0;
        }
    }
}