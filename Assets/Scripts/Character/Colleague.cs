using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Colleague : MonoBehaviour
{
    public float chasingSpeed = 5f;
    public bool isLaughing = false;
    public bool isUnhappy = false;

    private void Update()
    {
        if (isLaughing)
        {
            // 计算方向向量
            Vector3 direction = Player3D.Instance.gameObject.transform.position - transform.position;

            if(direction.x > 0)
            {
                this.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (direction.x < 0)
            {

                this.GetComponentInChildren<SpriteRenderer>().flipX=true;
            }
            direction.y = 0;

            // 使用normalized确保方向向量的长度为1，方便控制速度
            direction.Normalize();

            // 移动物体
            transform.Translate(direction * chasingSpeed * Time.deltaTime);
        }
    }
}
