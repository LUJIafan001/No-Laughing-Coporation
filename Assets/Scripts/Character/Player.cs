using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // 物体移动速度
    public float distanceOfLaughingSound = 2f;
    public Collider2D[] colliders;
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        // 获取玩家的输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // 移动物体
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnLaugh(distanceOfLaughingSound);
        }
    }

    public void OnLaugh(float distance)
    {
        Debug.Log("Laughing!");
        colliders = Physics2D.OverlapCircleAll(transform.position, distance);

        if (colliders.Length > 0)
        {
            Debug.Log("Finding Objects：" + colliders.Length);

            foreach (var collider in colliders)
            {
                Debug.Log("Found：" + collider.gameObject.name);

                // 在这里可以执行检测到物体后的逻辑
            }
        }
        else
        {
            Debug.Log("No Object Found");
        }
    }

}
    

