using System.Collections.Generic;
using Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class AsteroidGenerator : MonoBehaviour, ISpaceObjectCreator
    {
        [SerializeField] private int _asteroidCount = 7;
        
        [SerializeField] private List<GameObject> asteroidPrefabs;
        
        public static List<Asteroid> asteroids = new List<Asteroid>();

        private void Start()
        {
            for (int i = 0; i < _asteroidCount; i++)
            {
                CreateSpaceObject();
            }
        }

        public void CreateSpaceObject()
        {
            var asteroidGO = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Count)],
                gameObject.transform,
                true
            );

            var asteroidComponent = asteroidGO.GetComponent<Asteroid>();

            Vector3? previousPosition = null;
            
            if (asteroids.Count > 0)
                previousPosition = asteroids[asteroids.Count - 1].transform.position;

            asteroidComponent.Initialize(previousPosition);

            asteroids.Add(asteroidComponent);
        }
 
    }
}
