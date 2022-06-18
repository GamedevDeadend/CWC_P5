// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetrb;

    private float minForce = 12;
    private float maxForce = 16;
    private float minTorque = -10;
    private float maxTorque = 10;
    private float randomSpawnXrange = 4;
    private float spawnYpos = 4;

    // Start is called before the first frame update
    void Start()
    {
        targetrb = GetComponent<Rigidbody>();

        targetrb.AddForce(ForceToApply(), ForceMode.Impulse);
        targetrb.AddTorque(TorqueToApply(), TorqueToApply(), TorqueToApply(),ForceMode.Impulse); 

        targetrb.transform.position = SpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 ForceToApply()
    {
        return Vector3.up* Random.Range(minForce, maxForce);
    }

    float TorqueToApply()
    {
        return Random.Range(minTorque, maxTorque);
    }

    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(-randomSpawnXrange, randomSpawnXrange), spawnYpos);

    }
}
