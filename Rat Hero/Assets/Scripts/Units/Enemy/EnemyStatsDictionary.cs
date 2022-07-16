using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsDictionary : ScriptableObject
{
    public static Dictionary <string, float[]> enemiesStats = new Dictionary<string, float[]>()
    {
        {"Fly",             new float[3]      {600, 45, 1.2f}       },
        {"Mosquito",        new float[3]      {350, 65, 1.4f}       },
        {"Spider",          new float[3]      {600, 40, 0   }       },
        {"Centipede",       new float[3]      {450, 60, 1.5f}       },
        {"FireLizard",      new float[3]      {500, 40, 0   }       },
        {"FrostLizard",     new float[3]      {500, 50, 0   }       },
        {"Hedgehog",        new float[3]      {700, 40, 1.25f}      },
        {"Mole",            new float[3]      {400, 65, 0   }       },
        {"Snake",           new float[3]      {400, 70, 1.7f}       },
        {"Scorpion",        new float[3]      {350, 50, 0   }       },

    };


}
