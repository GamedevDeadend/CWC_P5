// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private GameManager gm;

    private Rigidbody targetrb;

    private float minForce = 12;
    private float maxForce = 16;
    private float minTorque = -10;
    private float maxTorque = 10;
    private float randomSpawnXrange = 4;
    private float spawnYpos = 4;

    public int scoreReward;

    public ParticleSystem destructionParticles;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if ( !gameObject.CompareTag("Bad Element") )
        {
            gm.GameOver();
        }
    }

    
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(destructionParticles, transform.position, transform.rotation);
        gm.UpdateScore(scoreReward);
    }

    
}
