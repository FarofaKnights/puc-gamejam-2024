using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightRaycast : MonoBehaviour {

    LineRenderer lr;

    public LayerMask lightInteractLayers, lightReceptorLayers;
    public float maxRayDistance = 10f;
    public int maxIterations = 10;

    List<LightActivated> receptoresAtivos;

    void OnEnable() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        LightActivated[] lightActivateds = FindObjectsOfType<LightActivated>();
        receptoresAtivos = new List<LightActivated>(lightActivateds);

        List<Vector3> hitPositions = new List<Vector3>();
        hitPositions.Add(transform.position);
        CalculaRay(transform.position, transform.right, hitPositions);

        foreach (LightActivated l in receptoresAtivos) {
            l.Desativar();
        }


        lr.positionCount = hitPositions.Count;
        lr.SetPositions(hitPositions.ToArray());
    }

    void CalculaRay(Vector3 pos, Vector3 dir, List<Vector3> hitPositions, int iteration = 0) {
        RaycastHit hit;
        float dist = -1f;
        // Check for collisions
        if (Physics.Raycast(pos, dir, out hit, maxRayDistance, lightInteractLayers)) {
            Debug.DrawRay(pos, dir * hit.distance, Color.yellow);
            GameObject lightReceptor = hit.collider.gameObject;
            dist = hit.distance;

            hitPositions.Add(hit.point);

            switch (lightReceptor.tag) {
                case "Ground":
                    return;
                case "Reflect":
                    CalculaRay(hit.point, Vector3.Reflect(dir, hit.normal), hitPositions, iteration + 1);
                    break;
            }
        } else {
            Debug.DrawRay(pos, dir * maxRayDistance, Color.green);
            hitPositions.Add(pos + dir * maxRayDistance);
        }

        // Check for triggers
        if (dist == -1f) dist = maxRayDistance;
        RaycastHit[] hits = Physics.RaycastAll(pos, dir, dist, lightReceptorLayers);
        foreach (RaycastHit hitt in hits) {
            Debug.DrawRay(pos, dir * hitt.distance, Color.red);
            GameObject lightReceptor = hitt.collider.gameObject;

            if (lightReceptor.tag == "Receptor") {
                LightActivated l = lightReceptor.GetComponent<LightActivated>();
                if (receptoresAtivos.Contains(l))
                    receptoresAtivos.Remove(l);

                l.Ativar();
            }
        }
    }
}
