using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour {
    [SerializeField] float runSpeed = 1.0F;

    private Animator animator;
    private bool isRunning = false;
    public bool IsRunning {
        set {
            if (isRunning != value) {
                isRunning = value;
                if (animator != null) {
                    animator.SetBool("IsRunning", isRunning);
                }
            }
        }
        get {
            return isRunning;
        }
    }

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (isRunning) {
            // ひたすら右へ
            transform.Translate(runSpeed * Vector2.right * Time.deltaTime);
        }
    }

}
