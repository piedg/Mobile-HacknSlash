using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Skill
{
    [field: SerializeField] public string AnimationName { get; private set; }
    [field: SerializeField] public float TransitionDuration { get; private set; } = 0.1f;
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public float SpellCastTime { get; private set; }

}
