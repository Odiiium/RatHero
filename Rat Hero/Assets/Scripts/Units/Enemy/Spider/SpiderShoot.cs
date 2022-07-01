using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShoot : MonoBehaviour
{
    internal Spider parentSpider;

    private void Awake()
    {
        Transform playerTransform = FindObjectOfType<Skin>().transform;
        GetComponent<Rigidbody>().AddForce((playerTransform.position - transform.position) * 1.5f, ForceMode.Impulse);
        StartCoroutine(StartLifeTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            ApplyDamageToPlayer(parentSpider);
        }
        else
        {
            SpawnSpiderWeb();
            Destroy(gameObject);
        }
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(2);
        SpawnSpiderWeb();
        Destroy(this.gameObject);
    }

    private void SpawnSpiderWeb()
    {
        var spiderWeb = Resources.Load("Prefabs/Units/Enemy/EnemyAbilities/SpiderWeb");
        Instantiate(spiderWeb, transform.position, transform.rotation);
    }

    private void ApplyDamageToPlayer(Spider spider)
    {
        if (spider != null)
        {
            Spider.OnApplyDamage?.Invoke(spider.damage);
            Character.onHealthChanged?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
