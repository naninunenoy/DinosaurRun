using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject grandPrefab;
    [SerializeField] int grandElmCount = 4;// 偶数
    [SerializeField] float moveSpeed = 1.0F;

    float elmWidth;
    public float GrandWidth { get { return elmWidth; } }
    public float TotalGrandWidth { get { return elmWidth * grandElmCount; } }
    float leftEdgePos;
    Queue<GameObject> grandQueue = new Queue<GameObject>();
    Vector3 center = Vector3.zero;
    public Vector3 Center { get { return center; } }

    void Awake() {
        elmWidth = grandPrefab.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < transform.childCount; i++) {
            var gra = transform.GetChild(i).gameObject;
            grandQueue.Enqueue(gra);
        }
        // 整列
        AdjustGrands();
    }

    public void Move() {
        var slide = Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += slide;
        center += slide;
    }

    private void AdjustGrands() {
        var xPos = grandQueue.Peek().transform.position.x;
        int i = 0;
        foreach (var gra in grandQueue) {
            var current = gra.transform.position;
            gra.transform.position = new Vector3(xPos, current.y, current.z);
            // 中心位置の更新
            if (grandElmCount / 2 == i) {
                var graPos = gra.transform.position;
                center = new Vector3(graPos.x - elmWidth / 2.0F, graPos.y, graPos.z);
            }
            i++;
            xPos += elmWidth;
        }
    }

    public Transform AppendAndRemove() {
        var left = grandQueue.Dequeue();
        var leftPos = left.transform.position;
        var rightPos = new Vector3(leftPos.x + elmWidth * grandElmCount, leftPos.y, leftPos.z);
        // 右端に追加
        var right = Instantiate(grandPrefab, rightPos, Quaternion.identity, transform);
        grandQueue.Enqueue(right);
        // 左端を削除
        Destroy(left);
        AdjustGrands();
        return right.transform;
    }
}
