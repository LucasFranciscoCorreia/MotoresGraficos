using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;
//using Random = Unity.Mathematics.Random;

public class BirdScript : MonoBehaviour
{

    public Vector3 velocidade;
    RevoadaScript revoada;
    float rand = 0.001f;

    void Start()
    {
        //Random rand = new Random();
        revoada = FindObjectOfType<RevoadaScript>();
        transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        velocidade = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        var vel = Separacao();
        vel += Coesao();
        Alinhamento(vel);
    }

    Vector3 Coesao()
    {
        var distance = revoada.GetCenterPoint(this.gameObject);
        var vel = Vector3.zero;

        if (distance != Vector3.zero)
        {
            float3 aux1 = transform.position;
            float3 aux2 = distance;
            bool3 res = aux1 < aux2;
            Vector3.fo
            if (res.x)
            {
                vel.x += distance.x;
            }
            else
            {
                vel.x -= distance.x;
            }

            if (res.y)
            {
                vel.y += distance.y;
            }
            else
            {
                vel.y -= distance.y;
            }

            if (res.z)
            {
                vel.z += distance.z;
            }
            else
            {
                vel.z -= distance.z;
            }
        }

        return vel.normalized;
    }

    Vector3 Separacao()
    {
        var listNext = revoada.GetCloseBirds(this.gameObject);
        var vel = Vector3.zero;
        if (listNext.Count != 0)
        {
            foreach (var bird in listNext)
            {
                float3 aux1 = transform.position;
                float3 aux2 = bird.gameObject.transform.position;
                bool3 res = aux1 < aux2;

                if( res.x )
                {
                    vel.x -= bird.gameObject.transform.position.x;
                }
                else
                {
                    vel.x += bird.gameObject.transform.position.x;
                }

                if (res.y)
                {
                    vel.y -= bird.gameObject.transform.position.y;
                }
                else
                {
                    vel.y += bird.gameObject.transform.position.y;
                }

                if (res.z)
                {
                    vel.z -= bird.gameObject.transform.position.z;
                }
                else
                {
                    vel.z += bird.gameObject.transform.position.z;
                }
            }
        }
        return vel.normalized;
    }

    void Alinhamento(Vector3 vel)
    {
        Debug.Log("Separacao = " + vel);
        vel += revoada.GetVelMedia(this);
        Debug.Log("Separacao + vel. media= " + vel);
        velocidade = vel *Time.deltaTime;
        transform.LookAt(transform.position + velocidade);
        transform.position += velocidade;
    }
}
