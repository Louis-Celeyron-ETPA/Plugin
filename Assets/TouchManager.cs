using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    public bool debug;
    private Camera _mainCamera;
    private Collider _collider;
    private ITouchable _itouchable;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {

        Camera maCamera = Camera.main;
        var touchePos = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, maCamera.farClipPlane);
        var touchePosInWorld = maCamera.ScreenToWorldPoint(touchePos);
        
        if(debug)
        {
            Debug.DrawLine(maCamera.transform.position, touchePosInWorld, Color.red);
        }

        if (Physics.Raycast(maCamera.transform.position, touchePosInWorld - maCamera.transform.position, out var info))
        {
            if(info.collider != _collider)
            {
                _iTouchable = info.collider.GetComponent<ITouchable>();

            }

        }
    }
}
