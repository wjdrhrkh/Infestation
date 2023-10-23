using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public GameObject objectToSpawn; // 소환할 오브젝트의 프리팹을 설정하기 위한 변수

    public float spawnInterval = 2.0f; // 소환 간격
    public float spawnRadius = 5.0f; // 소환할 위치의 반경

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        // 시간이 spawnInterval 이상 경과했을 때
        if (timeSinceLastSpawn >= spawnInterval)
        {
            // 랜덤한 위치 계산
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            // Y 좌표를 조정하여 지면 위에 소환되도록 함
            randomPosition.y = 0;

            // 오브젝트 소환
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            // 시간 초기화
            timeSinceLastSpawn = 0.0f;
        }
        else
        {
            // 시간 업데이트
            timeSinceLastSpawn += Time.deltaTime;
        }
    }
}
