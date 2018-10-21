using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Dinosaur dinosaur;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Ground ground;
    [SerializeField] Button tapArea;

    void Start() {
        dinosaur.IsRunning = true;
        tapArea.onClick.AddListener(() => { dinosaur.Jump(); });// tapでジャンプ
    }

    void Update() {
        // 地形の移動
        ground.Move();
        if (ground.Center.x < 0) {
            // 地形の追加
            var newGround = ground.AppendAndRemove();
            // 敵の追加
            enemySpawner.SpawnEnemy(newGround, ground.GrandWidth);
        }
        // キー入力
        if (Input.GetKeyDown(KeyCode.Space)) {
            dinosaur.Jump();
        }
    }
}
