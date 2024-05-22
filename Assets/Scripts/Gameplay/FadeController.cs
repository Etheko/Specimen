using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    FadeInOutEffect fadeEffect;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        fadeEffect = GetComponent<FadeInOutEffect>();

        fadeEffect.FadeOut();
        player.GetComponent<PlayerController>().movementEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
