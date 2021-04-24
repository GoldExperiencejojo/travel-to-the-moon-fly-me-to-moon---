using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public int gem;
    public Text gemNum;
    private int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Collection")
        {
            time++;
            Destroy(collision.gameObject);
            if (time == 1)
                gem += 100;
            gemNum.text = gem.ToString();
            
        }
    }
}
