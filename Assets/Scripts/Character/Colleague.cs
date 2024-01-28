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
            // ���㷽������
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

            // ʹ��normalizedȷ�����������ĳ���Ϊ1����������ٶ�
            direction.Normalize();

            // �ƶ�����
            transform.Translate(direction * chasingSpeed * Time.deltaTime);
        }
    }
}
