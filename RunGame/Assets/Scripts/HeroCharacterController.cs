using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] public float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 100f;
    [SerializeField] private AudioClip jumpSound;

    private float gravity = -20f;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;
    private bool speedBoost = false;
    private float horizontalInput;

    private void Start()
    {
        // Gerekli bile�enleri al�yoruz
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Karakterin y�r�me h�z� ve hareket y�n�
        horizontalInput = 1f;

        // Karakterin �ne bakmas�
        transform.forward = new Vector3(horizontalInput, 0f, Mathf.Abs(horizontalInput) - 1);

        // Karakterin yere temas�n� kontrol ediyoruz
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        // Karakter yerdeyken dikey h�z�n� s�f�rl�yoruz
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            // Karakterin d���� h�z�na yer�ekimi ekliyoruz
            velocity.y += gravity * Time.deltaTime;
        }

        // Karakteri yatay eksende hareket ettiriyoruz
        characterController.Move(new Vector3(horizontalInput * runSpeed, 0f, 0f) * Time.deltaTime);

        // H�z g��lendirme (boost) �zelli�i aktifse, ko�ma h�z�n� artt�r�yoruz
        if (speedBoost == true)
        {
            runSpeed = 6f;
        }

        // Z�plama tu�una bas�ld���nda veya telefon ekran�na dokunuldu�unda z�plama i�lemini ger�ekle�tiriyoruz
        if (isGrounded && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // Z�plama i�lemini ger�ekle�tiriyoruz
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);

            // E�er z�plama sesi varsa, sesi �al�yoruz
            if (jumpSound != null)
            {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position, 0.5f);
            }
        }

        // Dikey h�z� kullanarak karakteri yukar� veya a�a�� hareket ettiriyoruz
        characterController.Move(velocity * Time.deltaTime);

        // Ko�ma animasyonu
        animator.SetFloat("Speed", horizontalInput);

        // Z�plama animasyonu
        animator.SetBool("IsGrounded", isGrounded);
    }

    // Ba�ka bir nesneye temas edildi�inde �a�r�lan fonksiyon
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hiz")
        {
            // H�z g��lendirme nesnesi ile temas edildi�inde h�z� artt�r�yoruz ve h�z g��lendirme s�resini ba�lat�yoruz
            speedBoost = true;
            StartCoroutine(StopSpeedBoost()); // H�z g��lendirme s�resi sona erdi�inde h�z� d���recek fonksiyonu ba�lat�yoruz
        }
    }

    // H�z g��lendirme s�resi sona erdi�inde �al��acak fonksiyon
    private IEnumerator StopSpeedBoost()
    {
        // Belirli bir s�re (�rn. 10 saniye) sonra h�z g��lendirme �zelli�ini devre d��� b�rak�yoruz
        yield return new WaitForSeconds(10f);
        speedBoost = false;
        runSpeed = 3f; // H�z� istedi�iniz de�ere d���rebilirsiniz, burada 3f olarak varsay�yoruz
    }
}
