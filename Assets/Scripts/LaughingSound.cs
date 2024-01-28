using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughingSound : MonoBehaviour
{
    public static LaughingSound instance;
    private void Awake()
    {
        instance = this;
    }
    public float duration = 0.3f;
    public Vector3 startScale = new Vector3(0.01f, 0.01f, 0.01f);
    public Vector3 endScale = new Vector3(1f, 1f, 1f);
    public Material LaughingSoundMaterial;
    public void DrawLaughingSound()
    {
        StartCoroutine(DrawLaughingSoundCoroutine());
    }
    IEnumerator DrawLaughingSoundCoroutine()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<Sphere>();
        sphere.gameObject.GetComponent<MeshRenderer>().material = LaughingSoundMaterial;
        sphere.gameObject.GetComponent<Collider>().isTrigger = true;
        sphere.transform.position = this.gameObject.transform.position;
        sphere.transform.localScale = startScale;

        float currentTime = 0f;

        while(currentTime< duration)
        {
            sphere.transform.position = Player3D.Instance.transform.position;
            sphere.transform.localScale = Vector3.Lerp(startScale, endScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }

        sphere.transform.localScale = endScale;
        if(sphere.transform.localScale == endScale)
        {
            sphere.gameObject.SetActive(false);
        }
    }
}
