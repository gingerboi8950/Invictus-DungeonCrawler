using UnityEngine;

public class TempHeroMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(move);
    }
}

