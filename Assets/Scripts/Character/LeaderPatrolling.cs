using UnityEngine;

public class LeaderPatrolling : MonoBehaviour
{
    public Transform[] patrolPoints; // Ѳ��·���ϵĵ�����
    public float moveSpeed = 5f; // �ƶ��ٶ�

    private int currentPointIndex = 0;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("Ѳ��·��Ϊ�գ�������Ѳ��·����");
            return;
        }

        // ��ȡ��ǰѲ�ߵ�
        Transform currentPatrolPoint = patrolPoints[currentPointIndex];

        // ���㳯��Ѳ�ߵ�ķ���
        Vector3 patrolDirection = (currentPatrolPoint.position - transform.position).normalized;

        if (patrolDirection.x > 0)
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (patrolDirection.x < 0)
        {

            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        // �ƶ�����
        transform.Translate(patrolDirection * moveSpeed * Time.deltaTime);

        // �ж��Ƿ��Ѿ��ӽ���ǰѲ�ߵ�
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.2f)
        {
            // �л�����һ��Ѳ�ߵ�
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
