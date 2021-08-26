using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Simple gun


public class Guns : MonoBehaviour
{
    public float dmg = 10f;
    public float range = 100f;
    public float coolDown = 0.1f;
    private float timeFor;
    public Transform cannon;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > timeFor)
        {
            timeFor = Time.time + coolDown;
            ShootSimple();
        }
        
    }

    void ShootSimple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cannon.position, cannon.right, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
