using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject cacutusPrefab;
    [SerializeField] [Range(0, 1)] float spawnProb = 1.0F;
    [SerializeField] float enemyPosY = 0.6F;

    public void SpawnEnemy(Transform parent, float areaWidth) {
        // 敵の生成をランダムに行う
        if (Random.value >= spawnProb) {
            return;
        }
        var center = parent.position;
        var minX = center.x - areaWidth / 2.0F;
        var maxX = center.x + areaWidth / 2.0F;
        // ランダムな位置に敵を生成
        var spawnAt = new Vector3(Random.Range(minX, maxX), center.y + enemyPosY, center.z);
        var enemy = Instantiate(cacutusPrefab, spawnAt, Quaternion.identity, parent);
        Debug.Log("Spawn Enemy");
    }
}
