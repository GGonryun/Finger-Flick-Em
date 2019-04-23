using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ball
{
    public class Recycler : MonoBehaviour
    {
        [SerializeField] Ball[] prefabs = new Ball[0];

        #region MONOBEHAVIOUR
        void OnValidate()
        {
            int length = TypeHelper.Length;
            if (prefabs.Length != length)
            {
                Debug.LogError($"Please add only {TypeHelper.Length} balls to the recycler.");
                return;
            }

            for (int i = 0; i < length; i++)
            {
                string name = TypeHelper.Name(i);
                if (!(prefabs[i] is Ball) || prefabs[i].gameObject.name != name)
                    Debug.LogError($"Prefab #{i} should be a {name}");
            }
        }

        void Awake()
        {
            for (int i = 0; i < TypeHelper.Length; i++)
            {
                pools.Add(TypeHelper.Get(i), new Stack<Ball>(30));
            }
        }
        #endregion

        public void ReclaimAll()
        {
            GameObject[] ballObjects = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject obj in ballObjects)
            {
                if(obj.activeSelf)
                {
                    obj.transform.position = Vector2.down * 20f;
                }
            }
        }

        public void Reclaim(Ball b)
        {
            Type t = b.Type;
            lock (lockObject)
            {
                pools[t].Push(b);
            }
            b.gameObject.SetActive(false);
        }

        public Ball Get(Type t)
        {
            Ball b;

            if (this.pools[t].Count == 0)
                b = Create(t);
            else
                b = Recycle(t);

            return b;
        }

        Ball Create(Type t)
        {
            return Instantiate(prefabs[(int)t], this.transform) as Ball;
        }

        Ball Recycle(Type t)
        {
            Ball b;

            lock (lockObject)
            {
                b = this.pools[t].Pop();
            }

            b.gameObject.SetActive(true);
            return b;
        }

        Object lockObject = new Object();
        Dictionary<Type, Stack<Ball>> pools = new Dictionary<Type, Stack<Ball>>(TypeHelper.Length);
        
    }


}