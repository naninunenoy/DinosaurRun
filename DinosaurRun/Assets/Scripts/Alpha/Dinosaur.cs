using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Alpha {
    public enum JumpState { OnGround = 0, Jump, Fall }

    public class Dinosaur : MonoBehaviour {
        [SerializeField] float jumpSpeed = 1.0F;
        [SerializeField] float fallSpeed = 1.0F;
        [SerializeField] float jumpHeight = 1.0F;
        [SerializeField] GameObject damagedEyes;

        private Animator animator;
        new private Collider2D collider;

        private bool isDamaged = false;
        public bool IsDamaged {
            set {
                // ダメージ状態でないときに、trueを渡されたときのみ設定
                if (!isDamaged && value) {
                    isDamaged = value;
                    damagedEyes.SetActive(true);
                    StartCoroutine(EyesOffCortutine(0.5F));
                }
            }
            get {
                return isDamaged;
            }
        }

        // run
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

        // jump
        private JumpState jumpState = JumpState.OnGround;
        public void Jump() {
            if (jumpState != JumpState.OnGround) {
                return;
            }
            jumpState = JumpState.Jump;
            animator.SetBool("IsRunning", false);
        }


        void Awake() {
            animator = GetComponent<Animator>();
            collider = GetComponent<Collider2D>();
        }

        void Update() {
            // jump
            switch (jumpState) {
            case JumpState.Jump:
                // 上へ
                collider.transform.Translate(jumpSpeed * Vector2.up * Time.deltaTime);
                if (transform.position.y > jumpHeight) {
                    jumpState = JumpState.Fall;
                }
                break;
            case JumpState.Fall:
                // 下へ
                collider.transform.Translate(fallSpeed * Vector2.down * Time.deltaTime);
                if (transform.position.y < 0.01F) {
                    // 地面へ
                    collider.transform.transform.position = new Vector3(transform.position.x, 0.0F, transform.position.z);
                    jumpState = JumpState.OnGround;
                    animator.SetBool("IsRunning", true);
                }
                break;
            default:
                // Do Nothing
                break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            Debug.Log(collision.gameObject.tag);
            IsDamaged = true;
        }

        private IEnumerator EyesOffCortutine(float seconds) {
            yield return new WaitForSeconds(seconds);
            damagedEyes.SetActive(false);
            isDamaged = false;
        }
    }
}