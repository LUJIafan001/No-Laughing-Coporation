using UnityEngine;

public class Player3D : MonoBehaviour
{
    public bool isKillded = false;
    public float speed = 5f; // �����ƶ��ٶ�
    public float distanceOfLaughingSound = 2f;
    public Collider[] colliders;
    public static Player3D Instance;

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
        Vector3 movement = new Vector3(horizontalInput,0f, verticalInput);

        if(movement == new Vector3(0f, 0f, 0f))
        {
            this.GetComponentInChildren<Animator>().SetBool("isRun", false);
        }
        else
        {
            this.GetComponentInChildren<Animator>().SetBool("isRun", true);
        }

        // �ƶ�����
        if (movement.x > 0)
        {
            transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (movement.x < 0)
        {
            transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnLaugh(distanceOfLaughingSound);
        }
    }

    public void OnLaugh(float distance)
    {
        Debug.Log("Laughing!");
        LaughingSound.instance.DrawLaughingSound();
    }

    
}


