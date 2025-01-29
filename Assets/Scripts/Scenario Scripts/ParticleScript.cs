using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private ParticleSystem particle;
    [SerializeField] private AudioSource coinSound;
    
    public void PlayParticles()
    {

        particle=GetComponentInChildren<ParticleSystem>();
        particle.transform.SetParent(null);
        coinSound.transform.SetParent(null);
        particle.Play();
        coinSound.Play();
        Invoke("DestroyParticles", particle.main.duration);
    }

    public void DestroyParticles()
    {
        Destroy(particle);
    }

}
