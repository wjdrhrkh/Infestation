using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Damage = 10;

    RaycastHit hit;
    float max_ray = 15f;

    void Update()
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            Debug.DrawRay(transform.position, transform.forward * max_ray, Color.blue, 0.1f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, max_ray))
            {
                if(hit.transform.CompareTag("monster"))
                {
                    StartCoroutine(hit.transform.GetComponent<moster_st>().monster_damage(Damage));
                }
                  
            }
        }
    }
}
