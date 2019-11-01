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
        //vel += Coesao();
        Alinhamento(vel.normalized);
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

                if( Vector3.Distance(new Vector3(aux1.x+1, aux1.y, aux1.z), aux2 ) > Vector3.Distance(aux1, aux2))
                {
                    vel.x += bird.gameObject.transform.position.x;
                }
                else
                {
                    vel.x -= bird.gameObject.transform.position.x;
                }

                if (Vector3.Distance(new Vector3(aux1.x, aux1.y + 1, aux1.z), aux2) > Vector3.Distance(aux1, aux2))
                {
                    vel.y += bird.gameObject.transform.position.y;
                }
                else
                {
                    vel.y -= bird.gameObject.transform.position.y;
                }

                if (Vector3.Distance(new Vector3(aux1.x, aux1.y, aux1.z + 1), aux2) > Vector3.Distance(aux1, aux2))
                {
                    vel.z += bird.gameObject.transform.position.z;
                }
                else
                {
                    vel.z -= bird.gameObject.transform.position.z;
                }
            }
        }
        return vel;
    }

    void Alinhamento(Vector3 vel)
    {
        vel += revoada.GetVelMedia(this).normalized;
        velocidade = vel;
        transform.LookAt(transform.position + velocidade * Time.deltaTime);
        transform.position += velocidade * Time.deltaTime;
    }
}
