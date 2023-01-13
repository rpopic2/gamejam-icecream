using UnityEngine;
using System.Collections.Generic;
using System;

public class DataBase : MonoSingleton<DataBase>
{
    public virtual void LowDataLoad() { }

    public virtual void ProcessedDataLoad() { }
}
