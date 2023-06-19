using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BoxScripts : MonoBehaviour
{
    public float speed;


    public Text bottleCounterText;
    public GameObject bottle;
    int bottleCounter = 0;
    public Text loseText;
    public Button loseButton;
    public AudioSource audioS;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bottle")
        {
            bottleCounter += 1;
            bottleCounterText.text = bottleCounter.ToString();
            Destroy(collision.gameObject);
            float a = Random.Range(-6, 6.1f);
            Instantiate(bottle.gameObject, new Vector3(a, 6, 0), Quaternion.identity);
            audioS.Play();

            //obje.position=new vector2(x,y,z);
            //rigidbody pozisyon dondur
            //sürekli instantiate yapmak sistemi yorar
        }

    }

    public void loseButtonMenage()
    {
        SceneManager.LoadScene(0);
        loseText.gameObject.SetActive(false);
        Time.timeScale = 1;
        loseButton.gameObject.SetActive(false);
    }
}
