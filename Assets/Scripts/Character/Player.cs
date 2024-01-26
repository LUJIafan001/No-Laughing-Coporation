using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // �����ƶ��ٶ�
    public float distanceOfLaughingSound = 2f;
    public Collider2D[] colliders;
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        // ��ȡ��ҵ�����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // �ƶ�����
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
            Debug.Log("Finding Objects��" + colliders.Length);

            foreach (var collider in colliders)
            {
                Debug.Log("Found��" + collider.gameObject.name);

                // ���������ִ�м�⵽�������߼�
            }
        }
        else
        {
            Debug.Log("No Object Found");
        }
    }

}
    

