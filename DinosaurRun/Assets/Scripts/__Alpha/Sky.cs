using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Alpha {
    public class Sky : MonoBehaviour {
        [SerializeField] Transform spawnPos;
        [SerializeField] Transform destroyPos;
        [SerializeField] Cloud cloud;
        [SerializeField] PterosaurSpawner pterosaurSpawner;
        [SerializeField] float cloudSpeed = 1.0F;
        [SerializeField] float enemySpeed = 1.0F;

        void Update() {
            // 敵
            pterosaurSpawner.SpawnEnemy(spawnPos);
            EnemyMove(pterosaurSpawner.Enemy, enemySpeed);
            EnemyCycle();
            // 雲
            cloud.Move(cloudSpeed);
            cloud.CycleCloud(spawnPos, destroyPos);
        }

        private void EnemyMove(GameObject enemy, float moveSpeed) {
            if (enemy == null) {
                return;
            }
            enemy.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        private void EnemyCycle() {
            if (pterosaurSpawner.Enemy == null) {
                return;
            }
            // 左に行った敵を消す
            if (pterosaurSpawner.Enemy.transform.position.x < destroyPos.position.x) {
                var removeEnemy = pterosaurSpawner.Enemy;
                Destroy(removeEnemy);
                pterosaurSpawner.Enemy = null;
            }
        }
    }
}
