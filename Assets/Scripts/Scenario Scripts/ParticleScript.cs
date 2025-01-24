using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private ParticleSystem particle;
    public void PlayParticles()
    {
        particle=GetComponentInChildren<ParticleSystem>();
        particle.transform.SetParent(null);
        particle.Play();
        Invoke("DestroyParticles", particle.main.duration);
    }

    public void DestroyParticles()
    {
        Destroy(particle);
    }

}
