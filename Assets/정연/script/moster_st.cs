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
        StartCoroutine(Monster_Move());//몬스터 이동 코루틴 호출
        if (mon_HP <= 0)//몬스터 
        {
            GameManager.Game_Mg.Score_up(score);
            Destroy(gameObject);
        }
        if(GameManager.Game_Mg.Game_End)
            Destroy(gameObject);
    }

    IEnumerator Monster_Move()//몬스터를 이동시켜주는 코루틴
    {
        gameObject.transform.position += new Vector3(0.1f, 0, 0)*speed;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dead Lien"))//태그가 데드라인인 오브젝트에 닿으면
        {
            GameManager.Game_Mg.Damage();
            Destroy(gameObject);
        }
    }
    public IEnumerator monster_damage(int Damage_index)//몬스터가 데미지를 입었을떄 hp를 깎아주는 코루틴
    {
        mon_HP -= Damage_index;
        yield return null;
    }
}
