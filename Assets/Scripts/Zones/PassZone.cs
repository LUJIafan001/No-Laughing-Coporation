using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PassZone : MonoBehaviour
{
    public static PassZone instance;

    private void Awake()
    {
        instance = this;
    }
    public string passSceneName;
    public int passCount;
    public int neededPassCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(passCount>= neededPassCount)
        {
            OnPass();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Colleague")
        {
            other.gameObject.SetActive(false);
            passCount++;
        }
    }

    private void OnPass()
    {
        SceneManager.LoadScene(passSceneName);
    }



}
