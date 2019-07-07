using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public static int BreakableCount = 0;
    public Sprite[] hitSprites;
    public int timesHit;

    private bool isBreakable;
    private SceneLoader sceneLoader;


    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //keep track of breakable bricks
        if (isBreakable)
        {
            BreakableCount++;
            print(BreakableCount);
        }

        timesHit = 0;
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            handleHits();
        }

    }

    void handleHits()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
            BreakableCount--;
            sceneLoader.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

     void SimulateWin()
    {
            
        sceneLoader.LoadNextScene();

        }
    }
