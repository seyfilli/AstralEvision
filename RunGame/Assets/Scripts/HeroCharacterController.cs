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
        // Gerekli bileþenleri alýyoruz
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Karakterin yürüme hýzý ve hareket yönü
        horizontalInput = 1f;

        // Karakterin öne bakmasý
        transform.forward = new Vector3(horizontalInput, 0f, Mathf.Abs(horizontalInput) - 1);

        // Karakterin yere temasýný kontrol ediyoruz
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        // Karakter yerdeyken dikey hýzýný sýfýrlýyoruz
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            // Karakterin düþüþ hýzýna yerçekimi ekliyoruz
            velocity.y += gravity * Time.deltaTime;
        }

        // Karakteri yatay eksende hareket ettiriyoruz
        characterController.Move(new Vector3(horizontalInput * runSpeed, 0f, 0f) * Time.deltaTime);

        // Hýz güçlendirme (boost) özelliði aktifse, koþma hýzýný arttýrýyoruz
        if (speedBoost == true)
        {
            runSpeed = 6f;
        }

        // Zýplama tuþuna basýldýðýnda veya telefon ekranýna dokunulduðunda zýplama iþlemini gerçekleþtiriyoruz
        if (isGrounded && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // Zýplama iþlemini gerçekleþtiriyoruz
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);

            // Eðer zýplama sesi varsa, sesi çalýyoruz
            if (jumpSound != null)
            {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position, 0.5f);
            }
        }

        // Dikey hýzý kullanarak karakteri yukarý veya aþaðý hareket ettiriyoruz
        characterController.Move(velocity * Time.deltaTime);

        // Koþma animasyonu
        animator.SetFloat("Speed", horizontalInput);

        // Zýplama animasyonu
        animator.SetBool("IsGrounded", isGrounded);
    }

    // Baþka bir nesneye temas edildiðinde çaðrýlan fonksiyon
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hiz")
        {
            // Hýz güçlendirme nesnesi ile temas edildiðinde hýzý arttýrýyoruz ve hýz güçlendirme süresini baþlatýyoruz
            speedBoost = true;
            StartCoroutine(StopSpeedBoost()); // Hýz güçlendirme süresi sona erdiðinde hýzý düþürecek fonksiyonu baþlatýyoruz
        }
    }

    // Hýz güçlendirme süresi sona erdiðinde çalýþacak fonksiyon
    private IEnumerator StopSpeedBoost()
    {
        // Belirli bir süre (örn. 10 saniye) sonra hýz güçlendirme özelliðini devre dýþý býrakýyoruz
        yield return new WaitForSeconds(10f);
        speedBoost = false;
        runSpeed = 3f; // Hýzý istediðiniz deðere düþürebilirsiniz, burada 3f olarak varsayýyoruz
    }
}
