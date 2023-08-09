using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    public GameObject pauseBtn;
    public GameObject altýnEfekti;
    public GameObject bittiPnl;
    public TMPro.TextMeshProUGUI puan_txt;
    public TMPro.TextMeshProUGUI toplanan_altin_txt;
    public AudioSource ses_dosyasý;
    public AudioClip altin_ses;
    public Transform yol_1;
    public Transform yol_2;



    int puan = 0;
    int toplanan_altin = 0;


    public bool hizlandirma = false;

    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SON_1")
        {
            yol_2.position = new Vector3(yol_1.position.x + 12.0f, yol_1.position.y, yol_1.position.z);
        }
        if(other.gameObject.name == "SON_2")
        {
            yol_1.position = new Vector3(yol_2.position.x + 12.0f, yol_2.position.y, yol_2.position.z );
        }
        if (other.gameObject.tag == "engel")
        {
            bittiPnl.SetActive(true);
            Time.timeScale = 0.0f; //zamaný durdurur                         
            pauseBtn.SetActive(false);
        }
        if (other.gameObject.tag == "altin")
        {
            ses_dosyasý.PlayOneShot(altin_ses);
            GameObject yeni_altin_efekti = Instantiate(altýnEfekti, other.gameObject.transform.position, Quaternion.identity); //altýnýn efektini burada oluþturduk
            Destroy(yeni_altin_efekti, 0.5f); //yarým saniye sonra efekti kaldýrdýk

            Destroy(other.gameObject);//temas edilen altýn silindi

            toplanan_altin++;
            puan += 5;

            puan_txt.text = puan.ToString("00000");
            toplanan_altin_txt.text = toplanan_altin.ToString();

        }

        if (other.gameObject.tag == "hiz")
        {
            GameObject[] tum_hizlanmalar = GameObject.FindGameObjectsWithTag("hiz");
            foreach (GameObject hizlanma in tum_hizlanmalar)
            {
                Destroy(hizlanma);
            }
            hizlandirma = true;
            Invoke("hizlanma_resetle", 10.0f);

        }
    }

    void hizlanma_resetle()
    {
        hizlandirma = false;
    }

}