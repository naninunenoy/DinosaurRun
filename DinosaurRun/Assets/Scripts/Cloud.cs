using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    const float maxCloudPosY = 2.0F;
    [SerializeField] Transform spawnPos;
    [SerializeField] Transform destroyPos;
    [SerializeField] GameObject[] cloudPrefabs;
    [SerializeField] GameObject[] defaultClouds;
    [SerializeField] float moveSpeed = 1.0F;

    HashSet<GameObject> cloudQue = new HashSet<GameObject>();

    void Awake() {
        foreach(var cloud in defaultClouds) {
            cloudQue.Add(cloud);
        }
    }

    void Update() {
        Move();
        CycleCloud();
    }

    private void Move() {
        foreach (var cloud in cloudQue) {
            // 左へ
            cloud.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    private void CycleCloud() {
        foreach (var cloud in cloudQue) {
            // 左へはみ出たものは消す
            if (cloud.transform.position.x < destroyPos.position.x) {
                cloudQue.Remove(cloud);
                Destroy(cloud);
                // 新たな雲を右に生成
                var cloudPosY = spawnPos.position.y + Random.Range(0.0F, maxCloudPosY);
                var cloudPos = new Vector3(spawnPos.position.x, cloudPosY, spawnPos.position.z);
                var spawnedCloud = Instantiate(cloudPrefabs[Random.Range(0, 3)], cloudPos, Quaternion.identity, transform);
                cloudQue.Add(spawnedCloud);
                break;// 消すのは1つずつ
            }
        }
    }
}
