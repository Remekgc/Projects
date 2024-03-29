using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectors;

namespace Location.Tank
{
    public class TankUI : MonoBehaviour
    {
        [SerializeField] GameObject tank;
        [SerializeField] ObjectSpawner fuelSpawner;
        [Header("UI elements")]
        [SerializeField] TMPro.TMP_Text tankPosition;
        [SerializeField] TMPro.TMP_Text fuelPosition;
        [SerializeField] TMPro.TMP_Text energyAmount;
        [SerializeField] TMPro.TMP_InputField fuelAmount;
        [SerializeField] TMPro.TMP_InputField turnAngle;

        Coroutine uiUpdate;

        private void Start()
        {
            uiUpdate = StartCoroutine(IUpdateUI());
        }

        public void AddEnergy(string amount)
        {
            if (int.TryParse(amount, out int result))
            {
                energyAmount.text = $"{result}";
            }
        }

        public void SetAngle(string amount)
        {
            if (float.TryParse(amount, out float angle))
            {
                angle *= (Mathf.PI / 180f);
                tank.transform.up = VectorMath.Rotate(new Coordinates(tank.transform.up), angle, false).Position;
            }
        }

        IEnumerator IUpdateUI()
        {
            yield return new WaitForSeconds(0.5f);

            while (true)
            {
                tankPosition.text = $"{tank.transform.position}";
                fuelPosition.text = $"{fuelSpawner.Clone.transform.position}";

                yield return new WaitForSeconds(0.25f);  
            }
        }

        private void OnDestroy()
        {
            StopCoroutine(uiUpdate);
        }
    }
}

