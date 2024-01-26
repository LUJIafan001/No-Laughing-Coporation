using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Colleague : MonoBehaviour
{
    public Transform Player;
    public float chasingSpeed = 2f;
    public bool isLaughing = false;

    private void Update()
    {
        if (isLaughing)
        {
            // 计算方向向量
            Vector3 direction = Player.position - transform.position;

            // 使用normalized确保方向向量的长度为1，方便控制速度
            direction.Normalize();

            // 移动物体
            transform.Translate(direction * chasingSpeed * Time.deltaTime);
        }
    }
}
