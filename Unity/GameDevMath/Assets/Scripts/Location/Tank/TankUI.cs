using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

