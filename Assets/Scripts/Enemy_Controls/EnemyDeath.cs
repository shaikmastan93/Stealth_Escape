using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    //public MonoBehaviour Testshoot;
    private float _fadeStart { get; set; }
    [SerializeField]
    private Renderer[] _renderers;
    void Start()
    {
      
        animator = GetComponent<Animator>();
    }

    IEnumerator FadeToGray()
    {
        _fadeStart = 0;
        for (int i = 0; i < 100; i++)
        {
            foreach (Renderer renderer in _renderers)
            {
                foreach (Material material in renderer.materials)
                {
                    var grayscale = material.color.grayscale;
                    material.color = Color.Lerp(material.color, new Color(grayscale, grayscale, grayscale), 0.1f);
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

}
