using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Gun : MonoBehaviour
{
    public int Damage = 10;
    public AudioClip gun_fire;
    public AudioClip empty_magazine;
    public AudioClip Reroad;

    RaycastHit hit;
    float max_ray = 15f;
    AudioSource audio;


    private void Start()
    {
        audio =gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (GameManager.Game_Mg.burnt_index > 0)
            {
                StartCoroutine(GameManager.Game_Mg.burnt_use());
                audio.clip = gun_fire;
                audio.Play();
                Debug.DrawRay(transform.position, transform.forward * max_ray, Color.blue, 0.1f);
                if (Physics.Raycast(transform.position, transform.forward, out hit, max_ray))
                {
                    audio.Play();
                    if (hit.transform.CompareTag("monster"))
                    {
                        StartCoroutine(hit.transform.GetComponent<moster_st>().monster_damage(Damage));
                    }
                }
            }
            else
            {
                audio.clip = empty_magazine;
                audio.Play();
            }

        }
        if(Input.GetKeyDown(KeyCode.R) && GameManager.Game_Mg.burnt_index != 5)
        {
            audio.clip = Reroad;
            audio.Play();
            GameManager.Game_Mg.burnt_index = 5;
        }
    }
}
