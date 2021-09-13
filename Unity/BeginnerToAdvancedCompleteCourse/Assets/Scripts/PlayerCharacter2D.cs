using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter2D : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer characterSprite;
    [SerializeField] Animator animator;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform leftGun;
    [SerializeField] Transform rightGun;
    [Header("Stats")]
    [SerializeField] int movementSpeed = 1;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallSpeed = 3f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool isAttacking = false;
    [SerializeField] float attackSpeeed = 0.25f;
    [SerializeField] float shotSpeed = 2f;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        StartCoroutine(IShoot());
        Walk();
        Jump();
    }

    IEnumerator IShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isAttacking == false)
        {
            float timer = attackSpeeed;
            isAttacking = true;

            animator.SetBool("isShooting", isAttacking);

            if (characterSprite.flipX == false)
            {
                SpawnBullet(rightGun, Vector3.right);
            }
            else
            {
                SpawnBullet(leftGun, Vector3.left);
            }

            while (timer > 0)
            {
                timer -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            isAttacking = false;

            animator.SetBool("isShooting", isAttacking);
        }
    }

    void SpawnBullet(Transform spawnPoint, Vector3 flightDirection)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);

        //bullet.GetComponent<Rigidbody2D>().velocity = flightDirection * shotSpeed * Time.deltaTime;
        bullet.GetComponent<Rigidbody2D>().AddForce(flightDirection * shotSpeed);
    }

    void Walk()
    {
        animator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.D))
        {
            characterSprite.flipX = true;

            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
            animator.SetBool("isWalking", true);
            animator.SetBool("isShooting", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterSprite.flipX = false;

            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
            animator.SetBool("isWalking", true);
            animator.SetBool("isShooting", false);
        }
    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isShooting", false);

            if (isGrounded)
            {
                isGrounded = false;

                rigidbody.AddForce(Vector2.up * jumpForce);
                animator.SetBool("isGrounded", isGrounded);
            }
        }

        Fall();
    }

    void Fall()
    {
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * fallSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
    }
}
