using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moster_st : MonoBehaviour
{
    public int mon_HP = 100;
    public float speed = 10;
    public int score = 100;

    private void Update()
    {
        if (GameManager.Game_Mg.Game_End)
            Destroy(gameObject);
        StartCoroutine(Monster_Move());//���� �̵� �ڷ�ƾ ȣ��
        if (mon_HP <= 0)//���� 
        {
            GameManager.Game_Mg.Score_up(score);
            Destroy(gameObject);
        }
    }

    IEnumerator Monster_Move()//���͸� �̵������ִ� �ڷ�ƾ
    {
        gameObject.transform.position += new Vector3(0.1f, 0, 0)*speed;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dead Lien"))//�±װ� ��������� ������Ʈ�� ������
        {
            GameManager.Game_Mg.Damage();
            Destroy(gameObject);
        }
    }
    public IEnumerator monster_damage(int Damage_index)//���Ͱ� �������� �Ծ����� hp�� ����ִ� �ڷ�ƾ
    {
        mon_HP -= Damage_index;
        yield return null;
    }
}
