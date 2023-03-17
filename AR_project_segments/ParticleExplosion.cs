using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
    public ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        explosionEffect.Play();
        Destroy(gameObject, 2.0f);
    }

}
