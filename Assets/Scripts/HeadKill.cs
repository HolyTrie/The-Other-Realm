using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HeadKill : MonoBehaviour
{
    [SerializeField] float minImpulseForExplosion = 1.0f;
    [SerializeField] float explosionEffectTime = 0.68f;
    private Rigidbody rb;
    Animator _animator;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        _animator = this.gameObject.GetComponent<Animator>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        // In 3D, the Collision object contains an .impulse field.
        // In 2D, the Collision2D object does not contain it - so we have to compute it.
        // Impulse = F * DeltaT = m * a * DeltaT = m * DeltaV
        if (collision.collider.tag == "Player")
        {
            Debug.Log("ARROW FALSE TRIGGER");
            collision.collider.isTrigger = false; // after hitting the player, set the arrow to trigger so it can be destroyed once reached ground.
        }
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        Debug.Log(gameObject.name + " collides with " + collision.collider.name + " at velocity " + collision.relativeVelocity + " [m/s], impulse " + impulse + " [kg*m/s]");
        if (impulse > minImpulseForExplosion)
        {
            _animator.SetBool("Death", true);
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {

        yield return new WaitForSeconds(explosionEffectTime);
        Destroy(this.gameObject);
    }

}
