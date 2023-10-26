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
        min = time / 60;//��
        src = time % 60;//��
    }

    void Update()
    {
        if(HP<=0)//hp�� 0���ϸ�
        {
            GameOver();//���ӿ���
        }

        if(src<=0)//�ʰ� 0 �����̰�,
        {
            if (min <= 0)//���� 0���ϸ�
            {
                GameClear();//Ŭ����
            }
            else//�ƴϸ�
            {
                min -= 1;
                src = 60;
            }
        }

        src -= Time.deltaTime;//���� �ð����� 1�ʸ��� �ʿ��� 1����

        Timar.text = ">>" + string.Format("{0:D1}:{1:D2}", min, (int)src)+"<<";//Ÿ�̸� �ؽ�Ʈ ����
        Score_text.text = " Score: " + Score;//���ھ� �ؽ�Ʈ ����

       StartCoroutine(Herat_check());//ü�� ui üũ �ڷ�ƾ ȣ��
       StartCoroutine(burnt_check());//�Ѿ� ui üũ �ڷ�ƾ ȣ��
        
    }
    public void Damage()//���� ��輱�� ������� �� �������� �ִ� �Լ�
    {
        HP -= 1;
    }

    public void Score_up(int in_score)//���ھ �����ִ� �Լ�
    {
        in_score *= HP;
        Score += in_score;
    }

    void GameOver()//���ӿ��� �Լ�
    {
        Game_End = true;
        main_canvas.SetActive(false);
        Gameover_canvas.SetActive(true);
    }

    void GameClear()//���� Ŭ���� �Լ�
    {
        Game_End = true;
        main_canvas.SetActive(false);
        Gameclear_canvas.SetActive(true);
        Clear_Score_text.text = "Score " + Score;
    }

    IEnumerator Herat_check()//hp ui üũ �ڷ�ƾ
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
    public IEnumerator burnt_use()//�Ѿ� ���� �� �Ѿ��� ����ִ� �ڷ�ƾ
    {
        burnt_index -=1;
        yield return null;
    }
    IEnumerator burnt_check()//�Ѿ� ui üũ�ϴ� �ڷ�ƾ
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
