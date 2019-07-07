using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomCollider : MonoBehaviour {

    public SceneLoader sceneLoader;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        SceneManager.LoadScene(8);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
