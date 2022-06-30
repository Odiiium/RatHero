using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveBuff : Buff
{
   internal abstract IEnumerator WaitForBuffEnds();
}
