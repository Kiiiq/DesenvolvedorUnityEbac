using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageScript : MonoBehaviour
{
    public GameObject[] tpPlaces;
    public bool ableToTp = true, ableToCast;
    public GameObject ChasingSpell;

    // Start is called before the first frame update
    void Start()
    {
        tpPlaces = GameObject.FindGameObjectsWithTag("TpPlace");
    }

    // Update is called once per frame
    void Update()
    {        
        if (ableToTp)
        {
            StartCoroutine(Teleport());
        }

        if(ableToCast)
        {
            StartCoroutine(Cast());
        }
    }

    

    public IEnumerator Teleport()
    {
        ableToTp = false;
        while (true) {
            int i = Random.Range(0, tpPlaces.Length - 1);
            if (tpPlaces[i].transform != this.transform)
            {
                this.transform.position = tpPlaces[i].transform.position;
                break;
            }
        }
        int time = Random.Range(3, 5);
        yield return new WaitForSeconds(time);
        ableToTp=true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthManager healthManager = collision.GetComponent<HealthManager>();
            healthManager.Takedamage(1,this.transform.position.x);
        }
    }

    public IEnumerator Cast()
    {
        ableToCast = false;
        Instantiate(ChasingSpell,new Vector3(this.transform.position.x, this.transform.position.y+1.5f), Quaternion.identity);
        int i = Random.Range(2, 3);
        yield return new WaitForSeconds(i);
        ableToCast=true;
    }
}
