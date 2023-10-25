using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Oculus;

public class Gun : MonoBehaviour
{
    public int Damage = 10;
    public AudioClip gun_fire;
    public AudioClip empty_magazine;
    public AudioClip Reroad;

    RaycastHit hit;
    float max_ray = 15f;
    AudioSource audio;

    private OVRInput.Controller controller;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();//오디오 소스 불러오기
        controller= OVRInput.Controller.RTouch;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))//오른손 검지 트리거 키를 누르면
        {
            if (GameManager.Game_Mg.burnt_index > 0)//총알 개수가 0개 이하가 아니면
            {
                StartCoroutine(GameManager.Game_Mg.burnt_use());//총알 하나 깎기
                audio.clip = gun_fire;//오디오 클립에 총 발사 소리 대입
                audio.Play();//오디오 재생
                Debug.DrawRay(transform.position, transform.forward * max_ray, Color.blue, 0.1f);//0.1초 동안 ray를 15 길이의 파란색 줄로 표시 
                if (Physics.Raycast(transform.position, transform.forward, out hit, max_ray))//ray 발사 
                {
                    if (hit.transform.CompareTag("monster"))//ray에 닿은 오브젝트의 태그가 monster면
                    {
                        StartCoroutine(hit.transform.GetComponent<moster_st>().monster_damage(Damage));//닿은 오브젝트의 monster_st에서 몬스터 데미지 함수 호출
                    }
                }
            }
            else//총알이 0개 이하면
            {
                audio.clip = empty_magazine;//클립에 빈소리 대입
                audio.Play();//소리 재생
            }

        }
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller) && GameManager.Game_Mg.burnt_index != 5)//총알이 5개가 아닌 상태에서 오른손 트리거 키를 누르면
        {
            audio.clip = Reroad;//클립에 재장전소리 대입
            audio.Play();//오디오 재생
            GameManager.Game_Mg.burnt_index = 5;//총알 개수 5개로 
        }
    }
}
