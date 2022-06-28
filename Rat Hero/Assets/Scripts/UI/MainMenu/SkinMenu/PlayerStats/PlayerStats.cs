using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public static float Damage {        get { if (damage > 50) return damage; else { return 50; } }
                                        set { damage = value; } }
    static float damage;

    public static float AttackSpeed { get
        {
            if (attackSpeed > 500) 
                return 500;
            else if (attackSpeed > 100)
                return attackSpeed;
            else  
                return 100;
        }                                                                                                           
        set { attackSpeed = value; } }
    static float attackSpeed;

    public static float HealthPoints {  get { if (healthPoints > 500) return healthPoints; else { return 500; } }
                                        set { healthPoints = value; } }
    static float healthPoints;

    public static float Defence { 
        get 
        {
            if (defence > 250) 
                return 250;
            else if (defence > 10) 
                return defence;
            else 
                return 10;
        }                                                                                                           
        set { defence = value; } }
    static float defence;

    public static float Speed { 
        get 
        {
            if (speed > 300)
                return 300;
            else if (speed > 100)
                return speed;
            else
                return 100;
        }                                                                                                           
        set { speed = value; } }
    static float speed;

    public static float CriticalChance { 
        get
        {
            if (criticalChance > 75) return 75;
            else if (criticalChance > 3)    return criticalChance;
            else return 3;
        }                                                                                                           
        set { criticalChance = value; } 
    }
    static float criticalChance;

    public static float Mana {
        get {
            if (mana > 800) return 800;
            if (mana > 100) return mana;
            else return 100;
        }                            
        set { mana = value; } }
    static float mana;

    public static List<string>prefsList = new List<string> { "1k!@Ccy3g#$C#%@cwferRC!@#", "c11!@KXtkerktexrT(3412#!C", "!@c5^V75N*($v)SVGGFD)Sg@C", "X1zzk123Z!$C%!%66&&4bbBBl", "S!Z!E!44$$$!$%%!%!:::s!WX", "z!Z@Xc152502v623vEWTWE@#%", "1UV$V234t3@$VO)UV&$3$C%)@", "1cV$93;WE3@$VO)QX$&$N%)@" };
    public void LoadStats()
    {
        Damage =                PlayerPrefs.GetFloat(prefsList[0]);
        AttackSpeed =           PlayerPrefs.GetFloat(prefsList[1]);
        HealthPoints =          PlayerPrefs.GetFloat(prefsList[2]);
        Defence =               PlayerPrefs.GetFloat(prefsList[3]);
        Speed =                 PlayerPrefs.GetFloat(prefsList[4]);
        CriticalChance =        PlayerPrefs.GetFloat(prefsList[5]);
        Mana =                  PlayerPrefs.GetFloat(prefsList[6]);
        RatLevelUp.CurrentLvl = PlayerPrefs.GetInt(prefsList[7]);

    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat(prefsList[0], Damage);
        PlayerPrefs.SetFloat(prefsList[1], AttackSpeed);
        PlayerPrefs.SetFloat(prefsList[2], HealthPoints);
        PlayerPrefs.SetFloat(prefsList[3], Defence);
        PlayerPrefs.SetFloat(prefsList[4], Speed);
        PlayerPrefs.SetFloat(prefsList[5], CriticalChance);
        PlayerPrefs.SetFloat(prefsList[6], Mana);
        PlayerPrefs.SetInt(prefsList[7], RatLevelUp.CurrentLvl);
    }
    
    public  void AddStats()
    {
        int moneyToLvlUp = (int)Mathf.Pow(RatLevelUp.CurrentLvl, 2);

        if (Money.cheese >= moneyToLvlUp)
        {
            Damage = Mathf.Round(Damage * 1.04f);
            AttackSpeed = Mathf.Round(AttackSpeed * 1.04f);
            HealthPoints = Mathf.Round(HealthPoints * 1.04f);
            Defence = Mathf.Round(Defence + 1);
            Speed = Mathf.Round(Speed * 1.04f);
            CriticalChance = Mathf.Round(CriticalChance + 1);
            Mana = Mathf.Round(Mana * 1.04f);
            RatLevelUp.CurrentLvl += 1;
            FindObjectOfType<PlayerStatsView>().ShowStats();
            Money.ReduceCheese(moneyToLvlUp);
        }
    }


}
