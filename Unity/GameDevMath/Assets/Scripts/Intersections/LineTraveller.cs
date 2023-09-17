using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Intersections
{
    public class LineTraveller : MonoBehaviour
    {
        [SerializeField] LineBuilder lineBuilder;

        private void Awake()
        {
            Assert.IsNotNull(lineBuilder);
        }

        private void Start()
        {
            StartCoroutine(ITravel());
        }

        IEnumerator ITravel()
        {
            Vector3 startPosition = lineBuilder.A.Lerp(0).ToVector();
            transform.position = startPosition;

            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                transform.position = lineBuilder.A.Lerp(Random.Range(0f, 1f)).ToVector();
            }
        }
    }
}
