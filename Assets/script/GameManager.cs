using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int HP;
    [SerializeField]
    private int time;
    [SerializeField]
    private int Score;

    [SerializeField]
    private TextMeshProUGUI Timar;
    [SerializeField]
    private TextMeshProUGUI Score_text;
    [SerializeField]
    private TextMeshProUGUI burnt;

    int min;
    float src;

    private static GameManager game_mg = null;

    private void Awake()
    {
        if (game_mg == null)
        {
            game_mg = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static GameManager Game_Mg
    {
        get
        {
            if (game_mg == null)
            {
                return null;
            }
            return game_mg;
        }
    }

    private void Start()
    {
        min = time / 60;
        src = time % 60;
    }

    void Update()
    {
        if(src<=0)
        {
            if (min <= 0)
            {
                GameClear();
            }
            else
            {
                min -= 1;
                src = 60;
            }
        }


        src -= Time.deltaTime;

        Timar.text = ">>" + string.Format("{0:D1}:{1:D2}", min, (int)src)+"<<";
        Score_text.text = " Score: " + Score;
    }
    public void Damage()
    {
        HP -= 1;
    }

    public void Score_up(int in_score)
    {
        Score += in_score;
    }

    void GameOver()
    {
        
    }

    void GameClear()
    {
        //SceneManager.LoadScene("Clear");
        Debug.Log("게임 클리어");
    }

}
