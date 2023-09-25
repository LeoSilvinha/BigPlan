using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUp : MonoBehaviour
{
    private float veloc = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * veloc * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" o objeto "+name+" colidiu com o Player"+ other.name);
        if( other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if ( player != null )
            {
                player.LigarPUDisparoTriplo();
            }

            Destroy(this.gameObject);

           
        }
       
    }


}
