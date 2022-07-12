using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public abstract class Buff : MonoBehaviour
{
    internal static UnityAction onGetBuff;
    protected Character player;
    internal BuffSpawnPoint buffSpawnPoint;

    private void Awake()
    {
        player = FindObjectOfType<Character>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 0.6f);
    }

    internal abstract void DoBuff();

    internal virtual void ShowBuffUI(string buffName)
    {
        SpawnBuffParticleAtPlayer(buffName);
        var buffImage = Resources.Load<Sprite>($"Icons/Buffs/{buffName}");
        SetBuffImageToBuffCell(buffImage);
        BuffUI.currentBuffCount++;
        onGetBuff?.Invoke();
    }

    private void SetBuffImageToBuffCell(Sprite buffImage)
    {
        int currentBuffIndex = !BuffUIView.buffImages[0].GetComponentInChildren<Image>().isActiveAndEnabled ? 0 :
                        !BuffUIView.buffImages[1].GetComponentInChildren<Image>().isActiveAndEnabled ? 1 :
                        !BuffUIView.buffImages[2].GetComponentInChildren<Image>().isActiveAndEnabled ? 2 : 3;

        GameObject buffUIObject = BuffUIView.buffImages[currentBuffIndex];
        buffUIObject.gameObject.SetActive(true);
        buffUIObject.GetComponentInChildren<Image>().sprite = buffImage;
    }

    private void SpawnBuffParticleAtPlayer(string name)
    {
        ParticleSystem buffParticle = Resources.Load<ParticleSystem>($"Prefabs/Particles/BuffParticles/{name}Particle");
        var createdParticleSystem = Instantiate(buffParticle, player.transform.position, player.transform.rotation * Quaternion.Euler(-90, 0, 0));
        player.StartCoroutine(DestroyParticleSystem(createdParticleSystem));
    }

    private IEnumerator DestroyParticleSystem(ParticleSystem particle)
    {
        yield return new WaitForSeconds(15);
        Destroy(particle.gameObject);
    }

}
