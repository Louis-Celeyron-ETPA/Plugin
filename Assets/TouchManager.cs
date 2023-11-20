using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    public bool debug;
    private Camera _mainCamera;
    private Collider _collider;
    private ITouchable _iTouchable;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if(Input.touchCount<=0)
        {
            SetITouchable(null);
            _collider = null;
            return;
        }

        var touchePos = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, _mainCamera.farClipPlane);
        var touchePosInWorld = _mainCamera.ScreenToWorldPoint(touchePos);
        
        if(debug)
        {
            Debug.DrawLine(_mainCamera.transform.position, touchePosInWorld, Color.red);
        }

        if (Physics.Raycast(_mainCamera.transform.position, touchePosInWorld - _mainCamera.transform.position, out var info))
        {
            SetITouchable( info.collider.GetComponent<ITouchable>());
            if(info.collider != _collider)
            {
                _collider = info.collider;
                _iTouchable.OnTouchedDown();
            }

            _iTouchable?.OnTouchedStay();
        }
        else
        {
            if(_iTouchable != null)
            {
                SetITouchable(null);
                _collider = null;
            }
        }
        
    }

    private void SetITouchable(ITouchable newItouchable)
    {
        if(_iTouchable == newItouchable)
        {
            return;
        }
        _iTouchable?.OnTouchedUp();
        _iTouchable = newItouchable;
    }
}
