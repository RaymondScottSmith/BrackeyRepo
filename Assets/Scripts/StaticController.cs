using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticController : MonoBehaviour
{

    public List<Sprite> staticSprites;
    public SpriteRenderer screen;

    public bool stop;

    private void Awake()
    {
        screen = GetComponent<SpriteRenderer>();
    }

    [ContextMenu("Start Static")]
    public void StartStatic()
    {
        screen.enabled = true;
        stop = false;
        StartCoroutine(SwitchSprite());
    }

    private IEnumerator SwitchSprite()
    {
        
        yield return new WaitForSeconds(1f);
        if (!stop)
        {
            screen.sprite = staticSprites[Random.Range(0, staticSprites.Count)];
            StartCoroutine(SwitchSprite());
        }
        else
        {
            screen.enabled = false;
        }
        
    }
}
