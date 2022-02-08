using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpaqueCollider : MonoBehaviour
{
    float timer = 0;
    float deltaA = -.01f;
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
    }

    // Update is called once per frame
    void Update()
    {
        var col = gameObject.GetComponent<Renderer>().material.color;
        var trans = col.a + deltaA;
        col.a = trans;
        timer++;
        gameObject.GetComponent<Renderer>().material.color = col;
        if(timer == 50f)
        {
            if(deltaA<0)
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
                
            } else
            {
                gameObject.AddComponent<BoxCollider>();
       
            }
        }
        if (timer == 100f)
        {
            timer = 0f;
            deltaA *= -1;
        }

    }
}
