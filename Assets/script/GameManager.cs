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
    private int burnt_index;

    [SerializeField]
    private TextMeshProUGUI Timar;
    [SerializeField]
    private TextMeshProUGUI Score_text;
    [SerializeField]
    private TextMeshProUGUI burnt;
    [SerializeField]
    private TextMeshProUGUI Heart;

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

       StartCoroutine(Herat_check());
        StartCoroutine(burnt_check());
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

    IEnumerator Herat_check()
    {
        switch(HP)
        {
            case 3: 
                {
                    Heart.text = "<sprite=1> <sprite=1> <sprite=1>";
                }
                break;
            case 2:
                {
                    Heart.text = "<sprite=1> <sprite=1> <sprite=2>";
                }
                break;
            case 1:
                {
                    Heart.text = "<sprite=1> <sprite=2> <sprite=2>";
                }
                break;
        }
        yield return null;
    }
    IEnumerator burnt_use()
    {
        burnt_index -= 1;
        yield return null;
    }
    IEnumerator burnt_check()
    {
        switch (burnt_index)
        {
            case 5:
                {
                    burnt.text = "<sprite=0><sprite=0><sprite=0><sprite=0><sprite=0>";
                }
                break;
            case 4:
                {
                    burnt.text = "<sprite=0><sprite=0><sprite=0><sprite=0>";
                }
                break;
            case 3:
                {
                    burnt.text = "<sprite=0><sprite=0><sprite=0>";
                }
                break;
            case 2:
                {
                    burnt.text = "<sprite=0><sprite=0>";
                }
                break;
            case 1:
                {
                    burnt.text = "<sprite=0>";
                }
                break;
            default:
                {
                    burnt.text = "";
                }
                break;
        }
        yield return null;
    }
}
