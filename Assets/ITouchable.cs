using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable 
{
    public void OnTouchedDown();
    public void OnTouchedStay();
    public void OnTouchedUp();

}
