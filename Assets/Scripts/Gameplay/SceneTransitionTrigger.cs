using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    public int sceneToGo;
    public Vector2 playerPosition;
    public Vector2 playerDirection;
    public VectorValue playerStorage;

    public GameObject fadeInCanvas;

    public GameObject player;

    FadeInOutEffect fadeEffect;

    private void Start()
    {
        fadeEffect = fadeInCanvas.GetComponent<FadeInOutEffect>();
    }

    IEnumerator transitionToScene()
    {

        fadeEffect.FadeIn();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToGo);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // disable any input
            player.GetComponent<PlayerController>().movementEnabled = false;
            playerStorage.initialValue = playerPosition;
            playerStorage.playerDirection = playerDirection;
            StartCoroutine(transitionToScene());
        }
    }

}
