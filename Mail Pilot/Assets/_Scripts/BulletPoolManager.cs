using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

//[System.Serializable]
public class BulletPoolManager
{
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    private int _poolSize = 20;
    

    //TODO: create a structure to contain a collection of bullets
    [SerializeField]
    Queue<GameObject> _bulletPool = new Queue<GameObject>(20);

    static BulletPoolManager _instance;

    // Start is called before the first frame update
    //void Start()
    //{
    //    GameObject currBullet;

    //    // TODO: add a series of bullets to the Bullet Pool
    //    for (int i = 20; i < _poolSize; ++i)
    //    {
    //        currBullet = GameObject.Instantiate(bullet, Vector3.zero, Quaternion.identity);
    //        currBullet.SetActive(false);
    //        _bulletPool.Enqueue(currBullet);
    //    }

    //}


    private BulletPoolManager()
    {
        bullet = Resources.Load("Bullet", typeof(GameObject)) as GameObject;

        GameObject currBullet;

        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < _poolSize; ++i)
        {
            currBullet = Object.Instantiate(bullet, Vector3.zero, Quaternion.identity);
            currBullet.SetActive(false);
            _bulletPool.Enqueue(currBullet);
        }
    }

    public static BulletPoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BulletPoolManager();
            }

            return _instance;
        }
    }



    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject bullet = null;

        // Retrieve a bullet from the pool, iff the pool is not empty.
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue();
            bullet.SetActive(true);
        }

        return bullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        // Recylce bullet iff it exists, and the pool is not at the user's desired max size.
        if (bullet && (_bulletPool.Count < 20))
        {
            _bulletPool.Enqueue(bullet);
        }

        bullet.SetActive(false);
    }
}
