using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatadorDeParticulas : MonoBehaviour {
    ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    public Collider[] sensores;

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        // Get all particles of particle system
        ParticleSystem.Particle[] todas = new ParticleSystem.Particle[ps.particleCount];
        int numParticlesAlive = ps.GetParticles(todas);
        List<ParticleSystem.Particle> todasList = new List<ParticleSystem.Particle>();

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter, out var insideData);

        // iterate through the particles which entered the trigger and make them red
        for (int i = 0; i < numEnter; i++) {
            ParticleSystem.Particle p = enter[i];

            for (int j = 0; j < numParticlesAlive; j++) {
                if (todas[j].position == p.position) {
                    bool found = false;
                    for (int k = 0; k < sensores.Length; k++) {
                        if (sensores[k].bounds.Contains(todas[j].position)) {
                            found = true;
                        }
                    }

                    if (!found)
                        todas[j].remainingLifetime = 0;
                }
            }
        }

        ps.SetParticles(todas, todas.Length);
    }
}
