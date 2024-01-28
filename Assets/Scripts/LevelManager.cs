using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool isOver;
    public static LevelManager instance;
    public Material laughingMaterial;

    public GameObject ColleaguePrototype;
    public GameObject LeaderPrototype;
    public GameObject GuardPrototype;

    public Transform Colleagues;
    public Transform Leaders;
    public Transform Guards;
    public int TimePerColleague;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

    }
    private void Start()
    {
        InvokeRepeating("GenerateColleague", 0f, 1f);
        InvokeRepeating("GenerateLeader", 0f, 20f);
        InvokeRepeating("GenerateGuard", 0f, 60f);
    }
    public void GenerateColleague()
    {
        Instantiate(ColleaguePrototype, new Vector3(-33.93f, 0.7f, 2.89f) + new Vector3(Random.Range(-8, 8), 0f, Random.Range(-8, 8)), new Quaternion(0f,0f,0f,0f), Colleagues);
    }

    public void GenerateLeader()
    {
        GameObject leader = Instantiate(LeaderPrototype, new Vector3(-33.93f, 1f, 2.89f) + new Vector3(Random.Range(-8, 8), 0f, Random.Range(-8, 8)), new Quaternion(0f, 0f, 0f, 0f), Leaders);
        foreach(Transform t in leader.GetComponentInChildren<LeaderPatrolling>().patrolPoints)
        {
            t.position = new Vector3(-33.93f, 1f, 2.89f) + new Vector3(Random.Range(-8, 8), 0f, Random.Range(-8, 8));
        }
    }
    public void GenerateGuard()
    {
        Instantiate(GuardPrototype, new Vector3(-33.93f, 1f, 2.89f) + new Vector3(Random.Range(-8, 8), 0f, Random.Range(-8, 8)), new Quaternion(0f, 0f, 0f, 0f), Guards);
    }
}
