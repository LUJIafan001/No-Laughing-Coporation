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
            // 计算方向向量
            Vector3 direction = Player3D.Instance.transform.position - transform.position;
            if (direction.x > 0)
            {
                this.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (direction.x < 0)
            {

                this.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }

            // 使用normalized确保方向向量的长度为1，方便控制速度
            direction.Normalize();

            // 移动物体
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
        Player3D.Instance.gameObject.GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);//纯逆天的无奈写法，哪个傻逼会把camera绑在player的子物体上？？？？！！！！
        Debug.Log("You are killed!!!");
    }
}
