using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public AudioClip jumpSound; // Zýplama sesi
    private AudioSource audioSource; // Ses kaynaðý

    private void Start()
    {
        // AudioSource bileþenini alýn
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Karakterinizin zýplama eylemini algýlamanýzýn yöntemine göre burada bir kod yer almalýdýr.
        // Örneðin, eðer karakteriniz Input.GetKeyDown(KeyCode.Space) þeklinde zýplama yapýyorsa:

        if (Input.GetButtonDown("Jump"))
        {
            // Zýplama sesini çal
            PlayJumpSound();
        }
    }

    private void PlayJumpSound()
    {
        // Ses çalýnacak nesne varsa ve ses kaynaðý varsa sesi çal
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
