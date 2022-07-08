using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    MeshRenderer webMesh;
    Character player;

    private void Awake()
    {
        webMesh = transform.GetChild(0).GetComponent<MeshRenderer>();
        StartCoroutine(DestroySpiderWeb());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character player))
        {
            webMesh.material = webMaterial();
            gameObject.layer = 7;
            StartCoroutine(ChangeSpeed(player));
        }
    }

    private IEnumerator ChangeSpeed(Character player)
    {
        SetReducedPlayerSpeed(player);
        yield return new WaitForSeconds(5);
        GetBackPlayerSpeed(player);
    }

    private IEnumerator DestroySpiderWeb()
    {
        player = FindObjectOfType<Character>();
        yield return new WaitForSeconds(8);
        StopCoroutine(ChangeSpeed(player));
        GetBackPlayerSpeed(player);
        Destroy(gameObject);
    }

    private void SetReducedPlayerSpeed(Character player)
    {
        player.currentSpeed /= 2;
    }

    private void GetBackPlayerSpeed(Character player)
    {
        player.currentSpeed = player.speed;
    }

    private Material webMaterial()
    {
        return Resources.Load<Material>("Materials/Units/Enemy/Spider/SpiderWebAfterCollision");
    }





}
