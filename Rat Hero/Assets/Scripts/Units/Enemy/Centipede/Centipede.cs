using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : Enemy
{
    protected override float TimeToDeathSoundPlay { get => 1.5f;}
    protected override float TimeToGedDamagedSoundPlay { get => 1.5f; }
}
