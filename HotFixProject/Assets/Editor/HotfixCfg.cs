using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HotfixCfg
{
    [Hotfix] 
    public static List<Type> byfiled = new List<Type>()
    {
        typeof(Load),
        typeof(Cube)
    };
}
