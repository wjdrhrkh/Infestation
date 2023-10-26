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
    public int burnt_index;

    [SerializeField]
    private TextMeshProUGUI Timar;
    [SerializeField]
    private TextMeshProUGUI Score_text;
    [SerializeField]
    private TextMeshProUGUI burnt;
    [SerializeField]
    private TextMeshProUGUI Heart;
    [SerializeField]
    private GameObject Gameover_canvas;
    [SerializeField]
    private GameObject Gameclear_canvas;
    [SerializeField]
    private GameObject main_canvas;
    [SerializeField]
    private TextMeshProUGUI Clear_Score_text;

    public bool Game_End = false;

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
        min = time / 60;//분
        src = time % 60;//초
    }

    void Update()
    {
        if(HP<=0)//hp가 0이하면
        {
            GameOver();//게임오버
        }

        if(src<=0)//초가 0 이하이고,
        {
            if (min <= 0)//분이 0이하면
            {
                GameClear();//클리어
            }
            else//아니면
            {
                min -= 1;
                src = 60;
            }
        }

        src -= Time.deltaTime;//현실 시간으로 1초마다 초에서 1빼기

        Timar.text = ">>" + string.Format("{0:D1}:{1:D2}", min, (int)src)+"<<";//타이머 텍스트 설정
        Score_text.text = " Score: " + Score;//스코어 텍스트 설정

       StartCoroutine(Herat_check());//체력 ui 체크 코루틴 호출
       StartCoroutine(burnt_check());//총알 ui 체크 코루틴 호출
        
    }
    public void Damage()//좀비가 경계선을 통과했을 때 데미지를 주는 함수
    {
        HP -= 1;
    }

    public void Score_up(int in_score)//스코어를 더해주는 함수
    {
        in_score *= HP;
        Score += in_score;
    }

    void GameOver()//게임오버 함수
    {
        Game_End = true;
        main_canvas.SetActive(false);
        Gameover_canvas.SetActive(true);
    }

    void GameClear()//게임 클리어 함수
    {
        Game_End = true;
        main_canvas.SetActive(false);
        Gameclear_canvas.SetActive(true);
        Clear_Score_text.text = "Score " + Score;
    }

    IEnumerator Herat_check()//hp ui 체크 코루틴
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
            default:
                {
                    Heart.text = "<sprite=2> <sprite=2> <sprite=2>";
                }
                break;
        }
        yield return null;
    }
    public IEnumerator burnt_use()//총알 썼을 때 총알을 깎아주는 코루틴
    {
        burnt_index -=1;
        yield return null;
    }
    IEnumerator burnt_check()//총알 ui 체크하는 코루틴
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
