using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCalc : MonoBehaviour
{
    //public Transform _mirrorTransform;
    public Transform _playerTransform;

    public LayerMask _layerMask;

    public GameObject _cone;

    // Start is called before the first frame update
    void Start()
    {
        //PrintAngleBetweenMirrorAndPlayer();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //PrintAngleBetweenMirrorAndPlayer();
            RaycastPlayerTest();
        }
    }

    //private void PrintAngleBetweenMirrorAndPlayer()
    //{
    //    Vector3 inputVector1 = _playerTransform.position - _mirrorTransform.position;

    //    Vector3 normalizedVector1 = Vector3.Normalize(inputVector1);

    //    float angleBetweenVectors = Vector3.Angle(normalizedVector1, _mirrorTransform.forward);

    //    Debug.Log(angleBetweenVectors);
    //}


    private void RaycastPlayerTest()
    {
        RaycastHit hit;

        if (Physics.Raycast(_playerTransform.position,_playerTransform.forward, out hit, Mathf.Infinity, _layerMask))
        {
           
           
            CalculateAngleBetweenHitPoint(hit);
          
        }
    }

    private void CalculateAngleBetweenHitPoint(RaycastHit inputHit)
    {
        Vector3 inputVector1 = _playerTransform.position - inputHit.point;

        Vector3 normalizedVector1 = Vector3.Normalize(inputVector1);

        float angleBetweenVectors = Vector3.Angle(normalizedVector1,inputHit.normal);

        Debug.Log(angleBetweenVectors);

        ChangeAngleOfCone(angleBetweenVectors, inputHit);
    }

    private void ChangeAngleOfCone(float coneAngleChange, RaycastHit inputHit)
    {
        GameObject cone = inputHit.collider.gameObject.GetComponent<Mirror>().Cone;
        cone.transform.localRotation = Quaternion.Euler(cone.transform.localRotation.eulerAngles.x, coneAngleChange, cone.transform.localRotation.eulerAngles.z);
        cone.transform.position = inputHit.point;
    }
}
