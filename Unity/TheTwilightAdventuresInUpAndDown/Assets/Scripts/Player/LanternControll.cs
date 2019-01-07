using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternControll : MonoBehaviour {

    public GameObject lanterLight;
    public float amountOfLanternFuel;
     // [HideInInspector]
    public bool hasEveLantern;
    public SpriteRenderer lantern;

	// Use this for initialization
	void Start () {
        lantern.enabled = false;
	}
	
	// Make into a function when we know from where to call it.
	void Update () {
        

        if (hasEveLantern) {
            lanterLight.SetActive(true);
        } else {
            lanterLight.SetActive(false);
        }

        if (Random.Range(0, 100) < 5) {
            float flicker = Random.Range(0.97f, 1.03f);

            lanterLight.transform.localScale = new Vector3(lanterLight.transform.localScale.x * flicker, lanterLight.transform.localScale.y * flicker, lanterLight.transform.localScale.z);
        }

        lanterLight.transform.localScale = new Vector3(Mathf.Clamp(lanterLight.transform.localScale.x, 0.7f, 1.3f) , Mathf.Clamp(lanterLight.transform.localScale.y, 0.7f, 1.3f), lanterLight.transform.localScale.z);

    }

    void SetSizeOfLight(float percentage) {
        float tmp = percentage / 100;
        tmp = Mathf.Clamp(tmp, .2f, 1f); 

        lanterLight.transform.localScale = new Vector3(lanterLight.transform.localScale.x * tmp, lanterLight.transform.localScale.y * tmp, lanterLight.transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        hasEveLantern = true;
        GetComponent<SpriteRenderer>().enabled = false;
        lantern.enabled = true;
    }
}
