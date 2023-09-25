using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    public float veloc = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * veloc * Time.deltaTime);

        if ( transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-7.7f, 7.7f), 6.0f, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Laser" )
        {
            Destroy(other.gameObject);
        }

        if ( other.tag == "Player")
        {
            Player player = GetComponent<Player>();

            if ( player != null )
            {
                player.DanoAoPlayer();
            }
        }

       Destroy(this.gameObject);
    }

}
