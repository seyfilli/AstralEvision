using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public AudioClip jumpSound; // Z�plama sesi
    private AudioSource audioSource; // Ses kayna��

    private void Start()
    {
        // AudioSource bile�enini al�n
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Karakterinizin z�plama eylemini alg�laman�z�n y�ntemine g�re burada bir kod yer almal�d�r.
        // �rne�in, e�er karakteriniz Input.GetKeyDown(KeyCode.Space) �eklinde z�plama yap�yorsa:

        if (Input.GetButtonDown("Jump"))
        {
            // Z�plama sesini �al
            PlayJumpSound();
        }
    }

    private void PlayJumpSound()
    {
        // Ses �al�nacak nesne varsa ve ses kayna�� varsa sesi �al
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
