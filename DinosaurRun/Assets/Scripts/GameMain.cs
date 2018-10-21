﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Dinosaur dinosaur;
    [SerializeField] Ground ground;

    void Start() {
        dinosaur.IsRunning = true;
    }

    void Update() {
        // カメラをdinosaurに合わせる
        var cameraX = MoveCamera(mainCamera, dinosaur.transform);
        // カメラ位置がgrandをこえたらステージをスライド
        if (cameraX > ground.Center.x) {
            ground.AppendAndRemove();
        }
        // キー入力
        if (Input.GetKeyDown(KeyCode.Space)) {
            dinosaur.Jump();
        }
    }

    private float MoveCamera(Camera camera, Transform target) {
        var current = camera.transform.position;
        var to = new Vector3(target.position.x, current.y, current.z);
        if (to.x > current.x) {
            camera.transform.position = Vector3.MoveTowards(current, to, 1.0F);
        }
        return to.x;
    }
}
