using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float minTeleportTime, maxTeleportTime;

    GameObject spawnField;
    GameController gameController;
    
    float x, y;
    float maxX, maxY;

    void Start ()
	{
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawnField = GameObject.FindGameObjectWithTag("Background");

        var spawnFieldSprite = spawnField.GetComponent<SpriteRenderer>();
        var fieldCollider = spawnField.GetComponent<BoxCollider2D>();

        var monsterSprite = GetComponent<SpriteRenderer>();

        float offset = Mathf.Min(fieldCollider.size.x, fieldCollider.size.y) +
            Mathf.Max(monsterSprite.sprite.bounds.size.x, monsterSprite.sprite.bounds.size.y) / 2;

        maxX = spawnFieldSprite.sprite.bounds.size.x / 2 - offset;
        maxY = spawnFieldSprite.sprite.bounds.size.y / 2 - offset;
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        while (true)
        {
            x = Random.Range(-maxX, maxX);
            y = Random.Range(-maxY, maxY);
            float randomTime = Random.Range(minTeleportTime, maxTeleportTime);
            yield return new WaitForSeconds(randomTime);
            transform.position = new Vector3(x, y, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameController.Losse();
            Destroy(collision.gameObject);
        }
    }


}
