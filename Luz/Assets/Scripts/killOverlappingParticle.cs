 
using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(ParticleSystem))]
public class killOverlappingParticle : MonoBehaviour {
   public float extraDistance = 0;
   public int retry = 10;
   public Vector3 retryRange;
   ParticleSystem m_System;
   ParticleSystem.Particle[] m_Particles;
 
   private void LateUpdate() {
       InitializeIfNeeded();
 
       // GetParticles is allocation free because we reuse the m_Particles buffer between updates
       int numParticlesAlive = m_System.GetParticles(m_Particles);
 
       // Change only the particles that are alive
       for (int i = 0; i < numParticlesAlive; i++) {
           if (m_Particles[i].startLifetime - m_Particles[i].remainingLifetime < 0.05f && retry > 0) {// Before Unity 5.5.
           //if (m_Particles[i].startLifetime - m_Particles[i].remainingLifetime < 0.05f && retry > 0) {// Unity 5.5+.
               for (int j = 0; j < numParticlesAlive; j++) {
                   if (i != j) {// Prevents the same particle compares to itself.
                       float dist = Vector3.Distance(m_Particles[i].position, m_Particles[j].position) - m_Particles[i].GetCurrentSize(m_System) - m_Particles[j].GetCurrentSize(m_System) - extraDistance;
                       if (dist < 0) {
                           /* // Using the killing method can remove retry and r variables and the following while loop.
                           m_Particles[i].color = new Color(0,0,0,0);// Reduce alpha to zero before killing it to avoid flickering.
                           m_Particles[i].lifetime = 0;// Kill the particle.
                           */
                           int r = 0;
                           while (dist < 0 && r < retry) {
                               m_Particles[i].position += new Vector3(Random.Range(-retryRange.x,retryRange.x),Random.Range(-retryRange.y,retryRange.y),Random.Range(-retryRange.z,retryRange.z));
                               dist = Vector3.Distance(m_Particles[i].position, m_Particles[j].position) - m_Particles[i].GetCurrentSize(m_System) - m_Particles[j].GetCurrentSize(m_System) - extraDistance;
                               r++;
                           }
                       }
                   }
               }
           }
       }
 
       // Apply the particle changes to the particle system
       m_System.SetParticles(m_Particles, numParticlesAlive);
   }
 
   void InitializeIfNeeded() {
       if (m_System == null)
           m_System = GetComponent<ParticleSystem>();
 
       if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
           m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
   }
}