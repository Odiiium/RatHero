using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    MeshRenderer webMesh;


    private void Awake()
    {
        webMesh = transform.GetChild(0).GetComponent<MeshRenderer>();
        StartCoroutine(DestroySpiderWeb());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            webMesh.material = Resources.Load<Material>("Materials/Units/Enemy/Spider/SpiderWebAfterCollision");
            gameObject.layer = 7;
            StartCoroutine(ChangeSpeed());
        }
    }

    private IEnumerator ChangeSpeed()
    {
        SetReducedPlayerSpeed();
        yield return new WaitForSeconds(5);
        GetBackPlayerSpeed();
    }

    private IEnumerator DestroySpiderWeb()
    {
        yield return new WaitForSeconds(8);
        StopCoroutine(ChangeSpeed());
        GetBackPlayerSpeed();
        Destroy(gameObject);
    }

    private void SetReducedPlayerSpeed()
    {
        FindObjectOfType<Character>().currentSpeed /= 2;
    }

    private void GetBackPlayerSpeed()
    {
        Character player = FindObjectOfType<Character>();
        player.currentSpeed = player.speed;
    }





}
