using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyView : MonoBehaviour
{
    TextMeshProUGUI cheeseCount;
    TextMeshProUGUI diamondsCount;

    internal void UIInitialize()
    {
        cheeseCount = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        diamondsCount = gameObject.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    internal void ShowCurrentMoney()
    {
        cheeseCount.text = Money.cheese + "";
        diamondsCount.text = Money.diamonds + "";
    }
    
    internal void GameUIInitialize()
    {
        cheeseCount = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    internal void ShowCurrentMoneyInGame()
    {
        cheeseCount.text = "" + Money.cheese;
        StartCoroutine(WaitForHideMoneyUI());
    }

    private IEnumerator WaitForHideMoneyUI()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        yield return new WaitForSeconds(2);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -2000);
    }


















    public void SetStatsToZero()
    {
        PlayerPrefs.SetFloat(   "1k!@Ccy3g#$C#%@cwferRC!@#" ,   0);
        PlayerPrefs.SetFloat(   "c11!@KXtkerktexrT(3412#!C" ,   0);
        PlayerPrefs.SetFloat(   "!@c5^V75N*($v)SVGGFD)Sg @C",   0);
        PlayerPrefs.SetFloat(   "X1zzk123Z!$C%!%66&&4bbBBl"  ,  0);
        PlayerPrefs.SetFloat(   "S!Z!E!44$$$!$%%!%!:::s!WX"  ,  0);
        PlayerPrefs.SetFloat(   "z!Z@Xc152502v623vEWTWE@#%"  ,  0);
        PlayerPrefs.SetFloat(   "1UV$V234t3@$VO)UV &$3$C %)@",  0);
        PlayerPrefs.SetInt(     "AlbinoRat",                    0);
        PlayerPrefs.SetInt(     "RedHatRat",                    0);
        PlayerPrefs.SetInt(     "PC@V^#U$K(gc3rx)@XF)@#c36",    10000);
        PlayerPrefs.SetInt(     "Lx7B$CxQERwtwyq2$B^Q#&#%Y",    0);
        RatLevelUp.CurrentLvl = 1;
        
        RatLevelUpView.ShowLevel();
    }


}