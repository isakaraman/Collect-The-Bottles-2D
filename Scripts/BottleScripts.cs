using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BottleScripts : MonoBehaviour
{
    public Text loseText;
    public Button loseButton;
    public AudioSource audioS;
    public Text healthText;
    public GameObject bottle;
    int health=3;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bottle")
        {
            health -= 1;
            healthText.text = "Health: " + health.ToString();
            if (health==0)
            {
                Time.timeScale = 0;
                loseText.gameObject.SetActive(true);
                loseButton.gameObject.SetActive(true);
            }
            else
            {
                float a = Random.Range(-6, 6.1f);
                Instantiate(bottle.gameObject, new Vector3(a, 6, 0), Quaternion.identity);
            }
            audioS.Play();
        }
    }


}
