using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform gunPosition;
    [SerializeField] int bulletType = 0;
    public float movementSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager.Instance.GetPooledObjects(bulletType, gunPosition.position, gunPosition.rotation);

            if(bullet != null)
            {
                bullet.SetActive(true);
            }else
            {
                Debug.LogError("Pool demasiado pequeno");
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        float movementX = horizontalInput * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(movementX, 0f, 0f));

        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
