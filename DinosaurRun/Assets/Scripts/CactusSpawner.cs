using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : EnemySpawner {
    [SerializeField] float enemyPosY = 0.6F;

    public override void SpawnEnemy(Transform parent, float areaWidth) {
        // 敵の生成をランダムに行う
        if (Random.value >= spawnProb) {
            return;
        }
        var center = parent.position;
        var minX = center.x - areaWidth / 2.0F;
        var maxX = center.x + areaWidth / 2.0F;
        // ランダムな位置に敵を生成
        var spawnAt = new Vector3(Random.Range(minX, maxX), center.y + enemyPosY, center.z);
        var enemy = Instantiate(enemyPrefab, spawnAt, Quaternion.identity, parent);
    }
}
