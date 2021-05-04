﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public virtual string Name { get; set; }
    public virtual float Speed { get; set; }
    public virtual float ChasingSpeed { get; set; }
    public virtual float ChaseRange { get; set; }
    public virtual float VisionRange { get; set; }
    public virtual float AttackRange { get; set; }
    public virtual float SearchTimer { get; set; }
    public virtual float ChaseTimer { get; set; }
    public virtual float InitialChaseTimer { get; set; }
    public virtual float InitialSearchTimer { get; set; }
    public virtual float Damage { get; set; }
    public virtual Vector3 LastPlayerPosition { get; set; }

}