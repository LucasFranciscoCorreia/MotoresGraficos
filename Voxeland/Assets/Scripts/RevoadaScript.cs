using System;
using System.Collections.Generic;
using UnityEngine;

public class RevoadaScript : MonoBehaviour
{

    public GameObject passaro;
    public int n;
    public int minDistance;
    public int maxDistance;
    Transform pos;

    public GameObject[] instances;
    void Start()
    {
        pos = GetComponent<Transform>();
        instances = new GameObject[n];
        for(int i = 0; i < n; i++)
        {
            instances[i] = Instantiate(passaro, pos.position, pos.rotation);
        }
    }

    public Vector3 GetVelMedia(BirdScript bird)
    {
        Vector3 soma = Vector3.zero;
        foreach (var instance in instances)
        {
            if(instance != bird)
                soma += instance.GetComponent<BirdScript>().velocidade;

        }
        return soma/(n-1);
    }

    public List<BirdScript> GetCloseBirds(GameObject bird)
    {
        List<BirdScript> list = new List<BirdScript>();
        foreach(var instance in instances)
            if(instance != bird && Vector3.Distance(bird.transform.position, instance.transform.position) < minDistance)
                list.Add(instance.GetComponent<BirdScript>());

        return list;
    }

    public Vector3 GetCenterPoint(GameObject bird)
    {
        Vector3 center = Vector3.zero ;
        foreach (var instance in instances)
        {
            if (instance != bird)
            {
                center += instance.transform.position;
            }
        }
        if(Vector3.Distance(center, bird.transform.position) < maxDistance)
        {
            return Vector3.zero ;
        }
        else
        {
            return center/(n-1);
        }
    }
}