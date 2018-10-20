using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Dinosaur dinosaur;

    void Start() {
        dinosaur.IsRunning = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            dinosaur.Jump();
        }
    }
}
