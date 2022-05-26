using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public Vector3 GravityVector = new Vector3(0, 9.81f, 0);
    [SerializeField]
    private Rigidbody _ownRigidBody;

    // Update is called once per frame
    void Update()
    {
        _ownRigidBody.velocity -= GravityVector * Time.deltaTime * _ownRigidBody.mass;
    }
}
