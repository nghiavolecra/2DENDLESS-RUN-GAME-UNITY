using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private float jumpTime = 0.3f;

    // [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float crouchHeight = 0.5f; // Chiều cao khi cúi người
    [SerializeField] private float normalHeight = 1f; // Chiều cao bình thường



    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private bool isCrouching = false;

    // private void OnDrawGizmos()
    // {
    //     if (feetPos != null)
    //     {
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawWireSphere(feetPos.position, groundDistance);
    //     }
    // }


    private void Update()
    {

        // Debug.Log("Vị trí hiện tại của nhân vật: " + transform.position);
        // Debug.Log("Vị trí chân của nhân vật: " + feetPos.position);

        // if (!isJumping) // Nếu nhân vật không nhảy thì đặt lại vị trí
        // {
        //     transform.position = new Vector3(transform.position.x, -3.5f, transform.position.z);
        // }


        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // Debug.Log("Is Grounded: " + isGrounded);
        // Debug.Log("Vị trí hiện tại của nhân vật: " + transform.position);


        #region JUMPING


        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Người chơi vừa nhấn phím Jump.");
        }





        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log("Lực nhảy hiện tại (jumpForce): " + jumpForce);

            Debug.Log("Vận tốc hiện tại của Rigidbody2D: " + rb.velocity);


            Debug.Log("Nhân vật đã nhảy.");

            Debug.Log("Vị trí hiện tại của nhân vật: " + transform.position);
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

        #endregion

        #region CROUCHING

        if (isGrounded && Input.GetButton("Crouch"))
        {
            // // GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            // // Đặt biến trạng thái cúi người
            // isCrouching = true;

            // // Tính toán vị trí y của nhân vật để chân vẫn chạm đất
            // // Thay đổi vị trí của nhân vật dựa trên sự khác biệt chiều cao
            // float offset = (normalHeight - crouchHeight) / 2f;

            // // Đặt lại chiều cao của đối tượng hình ảnh (GFX)

            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);

            // // Dịch chuyển đối tượng của nhân vật xuống để chân luôn chạm đất
            // transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);



            if (isJumping)
            {
                GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
            }


        }

        if (Input.GetButtonUp("Crouch"))
        {
            // Khi thả nút Crouch, nhân vật trở lại trạng thái đứng
            // isCrouching = false;

            // // Tính toán vị trí y của nhân vật để trả về trạng thái bình thường
            // float offset = (normalHeight - crouchHeight) / 2f;

            // // Đặt lại chiều cao của đối tượng hình ảnh
            // GFX.localScale = new Vector3(GFX.localScale.x, normalHeight, GFX.localScale.z);

            // // Dịch chuyển đối tượng của nhân vật lên để chân luôn chạm đất


            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);

        }


        #endregion
    }
}
