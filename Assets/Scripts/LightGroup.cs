using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LightGroup")]
public class LightGroup : ScriptableObject
{
    public List<MovingHead> lights;
}
