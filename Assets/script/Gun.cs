using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Damage = 10;

    RaycastHit hit;
    float max_ray = 15f;
    AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&GameManager.Game_Mg.burnt_index!=0) 
        {
            Debug.DrawRay(transform.position, transform.forward * max_ray, Color.blue, 0.1f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, max_ray))
            {
                StartCoroutine(GameManager.Game_Mg.burnt_use());
                audio.Play();
                if (hit.transform.CompareTag("monster"))
                {
                    StartCoroutine(hit.transform.GetComponent<moster_st>().monster_damage(Damage));
                }

            }
        }
    }
}
