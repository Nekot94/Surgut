using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject item;
    public int count;

    GameObject spawnField;

    float x, y;
    float maxX, maxY;
   

	void Start ()
	{
        spawnField = GameObject.FindGameObjectWithTag("Background");

        var spawnFieldSprite = spawnField.GetComponent<SpriteRenderer>();
        var fieldCollider = spawnField.GetComponent<BoxCollider2D>();

        var itemSprite = item.GetComponent<SpriteRenderer>();

        float offset = Mathf.Min(fieldCollider.size.x, fieldCollider.size.y) +
            Mathf.Max(itemSprite.sprite.bounds.size.x, itemSprite.sprite.bounds.size.y) / 2;

        maxX = spawnFieldSprite.sprite.bounds.size.x / 2 - offset;
        maxY = spawnFieldSprite.sprite.bounds.size.y / 2 - offset;
        Spawn(count);
    }

    void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            x = Random.Range(-maxX, maxX);
            y = Random.Range(-maxY, maxY);

            Instantiate(item, new Vector3(x, y, 0), Quaternion.identity);

        }
    }
}
