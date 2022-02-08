using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollider : MonoBehaviour
{
    float timer = 0;
    float deltaA = -.05f;
    int delay;
    // Start is called before the first frame update
    void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000;
        delay = Random.Range(1, 21);
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0)
        {


            var col = gameObject.GetComponent<Renderer>().material.color;
            var trans = col.a + deltaA;
            col.a = trans;
            timer++;
            gameObject.GetComponent<Renderer>().material.color = col;
            if (timer == 10f)
            {
                if (deltaA < 0)
                {
                    Destroy(gameObject.GetComponent<BoxCollider>());

                }
                else
                {
                    gameObject.AddComponent<BoxCollider>();

                }
            }
            if (timer == 20f)
            {
                timer = 0f;
                if(deltaA <0 )
                {
                    int newPos = (int)transform.position[2];
                    while (newPos == (int)transform.position[2]) newPos = Random.Range(-2, 3);
                    Vector3 position = transform.position;
                    position[2] = newPos;
                    transform.position = position;
                }
                deltaA *= -1;
            }
        }
        else delay--;
    }
}
