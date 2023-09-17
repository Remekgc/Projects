using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vectors;

namespace Location.Tank
{
    public class Drive : MonoBehaviour
    {
        [SerializeField] float speed = 10.0f;
        [SerializeField] float rotationSpeed = 100.0f;
        [SerializeField] TMPro.TMP_Text energyAmount;
        [Header("Runtime")]
        [SerializeField] Vector3 lastFuelUpdatePosition = Vector3.zero;

        private void Start()
        {
            lastFuelUpdatePosition  = transform.position;
        }

        void Update()
        {
            if (float.TryParse(energyAmount.text, out float energy))
            {
                if (energy <= 0f)
                {
                    return;
                }

                energyAmount.text = $"{energy - Vector3.Distance(lastFuelUpdatePosition, transform.position)}";
                lastFuelUpdatePosition = transform.position;
            }

            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, translation, 0);
            transform.Rotate(0, 0, -rotation);
        }
    }
}
