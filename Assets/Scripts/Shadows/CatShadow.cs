using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShadow : Shadow
{
    public override string Name { get; set; } = "Cat";
    public override float Speed { get; set; } = 4f;
    public override float ChasingSpeed { get; set; } = 10f;
    public override float ChaseRange { get; set; } = 5f;
    public override float VisionRange { get; set; } = 10f;
    public override float AttackRange { get; set; } = 1f;
    public override float SearchTimer { get; set; } = 10f;
    public override float ChaseTimer { get; set; } = 15f;
    public override float InitialChaseTimer { get; set; } = 15f;
    public override float InitialSearchTimer { get; set; } = 10f;
    public override float Damage { get; set; } = 20f;
    public override Vector3 LastPlayerPosition { get; set; }
}
