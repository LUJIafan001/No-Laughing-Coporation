using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float chasingSpeed=4f;
    public bool isActived = false;
    private void Update()
    {
        if (isActived)
        {
            this.GetComponentInChildren<Animator>().SetBool("isRun", true);
            // ���㷽������
            Vector3 direction = Player3D.Instance.transform.position - transform.position;
            if (direction.x > 0)
            {
                this.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (direction.x < 0)
            {

                this.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }

            // ʹ��normalizedȷ�����������ĳ���Ϊ1����������ٶ�
            direction.Normalize();

            // �ƶ�����
            transform.Translate(direction * chasingSpeed * Time.deltaTime);
        }
        if (!isActived)
        {
            this.GetComponentInChildren<Animator>().SetBool("isRun", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnKillPlayer();
        }
    }

    public void OnKillPlayer()
    {
        Player3D.Instance.isKillded = true;
        Player3D.Instance.gameObject.GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);//�����������д�����ĸ�ɵ�ƻ��camera����player���������ϣ���������������
        Debug.Log("You are killed!!!");
    }
}
