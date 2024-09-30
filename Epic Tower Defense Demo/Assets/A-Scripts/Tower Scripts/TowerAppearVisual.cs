using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAppearVisual : MonoBehaviour
{
    [SerializeField] private float dissolveTime = 0.75f;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Material[] materials;

    private int _dissolveAmount = Shader.PropertyToID("_DisolveAmaount");
    private void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        materials = new Material[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            materials[i] = spriteRenderers[i].material;
        }
        StartCoroutine(Appear());

    }

    private IEnumerator Appear()
    {
        float elapsedTime = 0f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(0, 1.1f, (elapsedTime / dissolveTime));
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].SetFloat(_dissolveAmount, lerpedDissolve);
            }
            Debug.Log(lerpedDissolve);
            yield return null;
        }
    }
}