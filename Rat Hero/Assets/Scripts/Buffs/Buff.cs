using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public abstract class Buff : MonoBehaviour
{
    internal static UnityAction onGetBuff;
    protected Character player;

    private void Awake()
    {
        player = FindObjectOfType<Character>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 1);
    }

    internal abstract void DoBuff();

    internal virtual void ShowBuffUI(string buffName)
    {
        Debug.Log(buffName);
        var buffImage = Resources.Load<Sprite>($"Icons/Buffs/{buffName}");
        if (BuffUI.currentBuffCount < 4)
        {
            SetBuffImageToBuffCell(buffImage);
            BuffUI.currentBuffCount++;
            onGetBuff?.Invoke();
        }
    }

    private void SetBuffImageToBuffCell(Sprite buffImage)
    {
        int currentBuffIndex = !BuffUIView.buffImages[0].isActiveAndEnabled ? 0 :
                        !BuffUIView.buffImages[1].isActiveAndEnabled ? 1 :
                        !BuffUIView.buffImages[2].isActiveAndEnabled ? 2 : 3;

        Image buffUIObject = BuffUIView.buffImages[currentBuffIndex];
        buffUIObject.gameObject.SetActive(true);
        buffUIObject.sprite = buffImage;
    }

}
