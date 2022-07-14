using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCubeAtMouse : MonoBehaviour
{
    public Camera _mainCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = _mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Vector3.Distance(_mainCam.transform.position, this.transform.position) ));
            mouseWorldPosition = new Vector3(mouseWorldPosition.x, 0, mouseWorldPosition.z);

            this.transform.LookAt(mouseWorldPosition);
        }
       
    }
}
