using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
    internal static int currentBuffCount;

    internal void HideBuffUI()
    {
        StartCoroutine(WaitForBuffEnds());
    }

    internal IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(15);

        int i = BuffUIView.buffImages[0].isActiveAndEnabled ? 0 :
                BuffUIView.buffImages[1].isActiveAndEnabled ? 1 :
                BuffUIView.buffImages[2].isActiveAndEnabled ? 2 : 3;

        BuffUIView.buffImages[i].gameObject.SetActive(false);
        currentBuffCount--;
    }


}
