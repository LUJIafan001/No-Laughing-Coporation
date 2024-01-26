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
            // ���㷽������
            Vector3 direction = Player.position - transform.position;

            // ʹ��normalizedȷ�����������ĳ���Ϊ1����������ٶ�
            direction.Normalize();

            // �ƶ�����
            transform.Translate(direction * chasingSpeed * Time.deltaTime);
        }
    }
}
