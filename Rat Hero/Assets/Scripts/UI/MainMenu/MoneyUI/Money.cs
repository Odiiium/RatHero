using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int cheese { get { return PlayerPrefs.GetInt("PC@V^#U$K(gc3rx)@XF)@#c36");} set { PlayerPrefs.SetInt("PC@V^#U$K(gc3rx)@XF)@#c36", value); } }
    public static int diamonds { get { return PlayerPrefs.GetInt("Lx7B$CxQERwtwyq2$B^Q#&#%Y"); } set { PlayerPrefs.SetInt("Lx7B$CxQERwtwyq2$B^Q#&#%Y", value); } }


    public static void AddCheese(int value)
    {
        cheese += value;
    }
    public static void ReduceCheese(int value)
    {
        cheese -= value;
    }

    public static void AddDiamonds(int value)
    {
        diamonds += value;
    }
    public static void ReduceDiamonds(int value)
    {
        diamonds -= value;
    }




}
