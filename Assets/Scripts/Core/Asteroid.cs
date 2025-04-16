using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class Asteroid : SpaceObject
    {
        [SerializeField, Range(0f, 2f)] private float upperThresholdSizeDiapason = 1f;
        [SerializeField, Range(0f, 2f)] private float lowerThresholdSizeDiapason = 1f;
        [SerializeField, Range(-3f, 3f)] private float upperThresholdDiapasonXPosition = 1f;
        [SerializeField, Range(-3f, 3f)] private float lowerThresholdDiapasonXPosition = 1f;
        
        public void Initialize(Vector3? previousPosition = null)
        {
           var randomSize = Random.Range(lowerThresholdSizeDiapason, upperThresholdSizeDiapason); 
           transform.localScale = new Vector3(randomSize,randomSize,randomSize);
           
           var randomPositionX = Random.Range(lowerThresholdDiapasonXPosition, upperThresholdDiapasonXPosition);
           
           if (previousPosition.HasValue)
               transform.localPosition = new Vector3(randomPositionX, previousPosition.Value.y + 2f, 0);
           
           else
               transform.localPosition = new Vector3(randomPositionX, 0, 0);
        }
    }
}
