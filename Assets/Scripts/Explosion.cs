using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public ParticleSystem explosionParticle;
    
    public void Play(){
        explosionParticle.Play();
    } 

    public void Stop(){
        Destroy(explosionParticle, 1f);
    }
}
