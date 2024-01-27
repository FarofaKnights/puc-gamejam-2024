using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatadorDeParticulas : MonoBehaviour {

    private void OnParticleCollision(GameObject other)
    {
        // Destroy the particle
            ParticleSystem ps = other.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                return;
            }
            Debug.Log("aaaaaaa");
            ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[ps.GetSafeCollisionEventSize()];
            int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);

            for (int i = 0; i < numCollisionEvents; i++)
            {
                // Destroy the particle on collision with the plane
                DestroyParticle(other, collisionEvents[i].intersection);
            }
    }

    private void DestroyParticle(GameObject other, Vector3 position)
{
    // Find the particle system component
    ParticleSystem ps = other.GetComponent<ParticleSystem>();

    // Get the particles from the particle system
    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
    int numParticles = ps.GetParticles(particles);

    // Loop through each particle
    for (int i = 0; i < numParticles; i++)
    {
        // Check if the particle's position is close to the collision point
        if (Vector3.Distance(particles[i].position, position) < 0.1f)
        {
            // Destroy the particle
            particles[i].remainingLifetime = 0f; // Set remaining lifetime to zero to destroy the particle
        }
    }

    // Apply the modified particles back to the particle system
    ps.SetParticles(particles, numParticles);
}


}
