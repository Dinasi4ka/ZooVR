using UnityEngine;

public class AnimalSoundZone : MonoBehaviour
{
    public AudioSource animalSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (animalSound != null && !animalSound.isPlaying)
            {
                animalSound.Play();
            }
        }
    }
}
