using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScore : MonoBehaviour
{
    public ParticleSystem scoreEffect;

    // Start is called before the first frame update
    void Start()
    {
        scoreEffect.Play();
        Destroy(gameObject, 2.0f);
    }

}
