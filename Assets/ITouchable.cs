using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable 
{
    public virtual void OnTouchedDown() { }
    public virtual void OnTouchedStay() { }
    public virtual void OnTouchedUp() { }

}
