using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCollider : MonoBehaviour
{
    [SerializeField]
    private float _gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CustomGravity>() != null)
        {

        other.gameObject.GetComponent<CustomGravity>().GravityVector = this.gameObject.transform.up * _gravity;
        }
    }
}
