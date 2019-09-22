using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    //literally just draws a rectangle on screen

    public Vector3 center;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
    }
   
    //draw it only when selected
    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }

    //draw it always to  make alligning easier
    //void OnDrawGizmos() {
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawCube(transform.position, size);
    //}
}
