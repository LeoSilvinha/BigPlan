using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc;

    public float entradaHorizontal;
    public float entradaVertical;

    public GameObject pfLaser;

    private float _tempoDeDisparo = 1f;
    private float _podeDisparar = 0.0f;

    public bool possoDarDisparoTriplo = false;
    public GameObject disparoTriploPrefab;

    public int vidas = 0;



    // Start is called before the first frame update
    void Start()
    {
        veloc = 5f;
        transform.position = new Vector3 (0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();

        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Disparo();
        }


 

    }

    private void Movimento()
    {

        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * veloc * entradaHorizontal);

        if (transform.position.x > 9.85f)
        {
            transform.position = new Vector3(-9.85f, transform.position.y, 0);
        }

        if (transform.position.x < -9.85f)
        {
            transform.position = new Vector3(9.85f, transform.position.y, 0);

        }

        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * veloc * entradaVertical);

        if (transform.position.y > 3.62)
        {
            transform.position = new Vector3(transform.position.x, 3.62f, 0);
        }

        if (transform.position.y < -3.70f)
        {
            transform.position = new Vector3(transform.position.x, -3.70f, 0);
        }
    }

    private void Disparo()
    {
        if (Time.time > _podeDisparar)
        {
            if (possoDarDisparoTriplo == true)
            {
                Instantiate(disparoTriploPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(pfLaser, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
            }
            _podeDisparar = Time.time + _tempoDeDisparo;
        }
    }

    public IEnumerator DisparoTriploRotina()
    {
        yield return new WaitForSeconds(7.0F);
        possoDarDisparoTriplo = false;
    }

    public void LigarPUDisparoTriplo()
    {
        possoDarDisparoTriplo = true;
        StartCoroutine(DisparoTriploRotina());
    }

  
     public void DanoAoPlayer()
    {
        vidas--;
        if (vidas < 1)
        {
            Destroy(this.gameObject);
        }
    }


}
