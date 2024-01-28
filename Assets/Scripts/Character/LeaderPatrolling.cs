using UnityEngine;

public class LeaderPatrolling : MonoBehaviour
{
    public Transform[] patrolPoints; // 巡逻路径上的点数组
    public float moveSpeed = 5f; // 移动速度

    private int currentPointIndex = 0;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("巡逻路径为空，请设置巡逻路径！");
            return;
        }

        // 获取当前巡逻点
        Transform currentPatrolPoint = patrolPoints[currentPointIndex];

        // 计算朝向巡逻点的方向
        Vector3 patrolDirection = (currentPatrolPoint.position - transform.position).normalized;

        if (patrolDirection.x > 0)
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (patrolDirection.x < 0)
        {

            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        // 移动物体
        transform.Translate(patrolDirection * moveSpeed * Time.deltaTime);

        // 判断是否已经接近当前巡逻点
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.2f)
        {
            // 切换到下一个巡逻点
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
