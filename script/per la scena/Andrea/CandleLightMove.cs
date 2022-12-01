using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLightMove : MonoBehaviour
{
    public float interval = 1f;
    float _time;

    public float valoreMin;
    public float valoreMax;



    public UnityEngine.Rendering.Universal.Light2D candle;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0f;
        //candle = FindObjectOfType<UnityEngine.Rendering.Universal.Light2D>();
    }   

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        while (_time >= interval)
        {
            Flame();
            _time -= interval;
        }
    }

    public void Flame()
    {
        candle.falloffIntensity = Random.Range(valoreMin, valoreMax);
    }
}
