using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonOlustur : MonoBehaviour
{
    public GameObject altin;
    public GameObject roket;
    public GameObject hiz;

    public Transform oyuncu;

    float silinmezamani = 5.0f;

    void Start()
    {
        InvokeRepeating("nesne_klonla", 0, 2f);
    }

    public void nesne_klonla()
    {
        int rastsayi = Random.Range(0, 105);

        if (rastsayi >= 0 && rastsayi < 80)
        {
            klonla(altin, 1);
        }

        if (rastsayi >= 80 && rastsayi < 100)
        {
            klonla(roket, 8);
        }

        if (rastsayi >= 100 && rastsayi < 105)
        {
            if (!oyuncu.gameObject.GetComponent<Oyuncu>().hizlandirma)
            {
                klonla(hiz, 0);
            }
        }

    }

    void klonla(GameObject nesne, float Y_koordinat)
    {
        GameObject yeni_klon = Instantiate(nesne);

        // Random bir deðerle Y ekseninde rastgele bir pozisyon seçin
        float rastgeleY = Random.Range(1.5f, 2f);
        yeni_klon.transform.position = oyuncu.position + new Vector3(20.0f, rastgeleY, 0);

        Destroy(yeni_klon, silinmezamani);
    }
}
