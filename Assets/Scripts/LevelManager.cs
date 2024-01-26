using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Player.Instance.colliders.Length > 1)
        {
            foreach(Collider2D collider2D in Player.Instance.colliders)
            {
                if(collider2D.gameObject.name != "Player")
                {
                    collider2D.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    collider2D.gameObject.GetComponent<Colleague>().isLaughing = true;
                }
            }
        }
    }
}
