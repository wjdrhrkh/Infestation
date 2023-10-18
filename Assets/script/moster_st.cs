using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moster_st : MonoBehaviour
{
    public int mon_HP = 100;
    public float speed = 10;

    private void Update()
    {
        StartCoroutine(Monster_Move());
    }

    IEnumerator Monster_Move()
    {
        gameObject.transform.position += new Vector3(0.1f, 0, 0)*speed;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dead Lien"))
        {
            GameManager.Game_Mg.Damage();
            Destroy(gameObject);
        }
    }
    public IEnumerator monster_damage(int Damage_index)
    {
        mon_HP -= Damage_index;
        yield return null;
    }
}
