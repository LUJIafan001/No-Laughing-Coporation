using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target; // Ҫ�����Ŀ������
    public float smoothTime = 0.3f; // ƽ��ʱ��
    public Vector3 offset; // ����������Ŀ���ƫ����

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // ����Ŀ��λ��
            Vector3 targetPosition = target.position + offset;

            // ʹ�� SmoothDamp ƽ���ƶ������
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // ���������λ��
            transform.position = smoothPosition;
        }
    }
}
