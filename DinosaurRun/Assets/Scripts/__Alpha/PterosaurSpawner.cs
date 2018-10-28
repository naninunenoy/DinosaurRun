using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Alpha {
    public class PterosaurSpawner : EnemySpawner {
        [SerializeField] Transform parent;

        public GameObject Enemy { set; get; }

        public bool SpawnEnemy(Transform spawnPoint) {
            // 1体以上生成しない
            if (Enemy != null) {
                return false;
            }
            // 敵の生成をランダムに行う
            if (Random.value >= spawnProb) {
                return false;
            }
            var pos = spawnPoint.position;
            var spawnAt = new Vector3(pos.x, Random.Range(0, 2), pos.z);
            // ランダムな位置に敵を生成
            Enemy = Instantiate(enemyPrefab, spawnAt, Quaternion.identity, parent);
            return true;
        }
    }
}