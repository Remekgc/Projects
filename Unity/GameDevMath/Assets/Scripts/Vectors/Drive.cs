using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Vectors 
{
    public class Drive : MonoBehaviour
    {
        [SerializeField] Vector2 up = new Vector2(0f, 1f);
        [SerializeField] Vector2 right = new Vector2(1f, 0f);
        [SerializeField] float speed = 0.1f;

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(-up);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(-right);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(right);
            }
        }

        void Move(Vector2 movementVector)
        {
            Vector2 position = this.transform.position;

            position += movementVector * speed;
            transform.position = position;
        }
    }
}