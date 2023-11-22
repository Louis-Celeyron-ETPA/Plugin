using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, ITouchable
{
    public void OnTouchedDown()
    {
        Debug.Log("Down");
    }

    public void OnTouchedStay()
    {
        Debug.Log("Stay");

    }

    public void OnTouchedUp()
    {
        Debug.Log("Up");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
