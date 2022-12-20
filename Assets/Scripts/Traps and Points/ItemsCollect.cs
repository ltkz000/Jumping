using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsCollect : MonoBehaviour
{
    private int cherries;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private TextMeshProUGUI CherriesText;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Collectibles")){
            collectSoundEffect.Play();
            Destroy(collision.gameObject);

            cherries++;
            Debug.Log("Points: " + cherries);
            CherriesText.SetText("Points: " + cherries);
        }
    }
}
