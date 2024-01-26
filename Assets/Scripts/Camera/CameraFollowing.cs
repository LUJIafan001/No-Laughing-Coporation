using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target; // 要跟随的目标物体
    public float smoothTime = 0.3f; // 平滑时间
    public Vector3 offset; // 摄像机相对于目标的偏移量

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // 计算目标位置
            Vector3 targetPosition = target.position + offset;

            // 使用 SmoothDamp 平滑移动摄像机
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // 更新摄像机位置
            transform.position = smoothPosition;
        }
    }
}
