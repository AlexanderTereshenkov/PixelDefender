using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LampInsanityManager : MonoBehaviour
{

    [SerializeField] private float maxDistanceFromBase;
    [SerializeField] private float maxIntensity;
    [SerializeField] private float lampOilLevel = 100;
    [SerializeField] private float maxInsanityLevel;
    [SerializeField] private float fearLevel;
    [SerializeField] private float fearIncrease;
    [SerializeField] private float oilLevelDecrement;
    [SerializeField] private Light2D playerLamp;

    private Transform exitPoint;
    private Light2D worldLight;
    private Slider oilSlider;
    private Slider insanitySlider;
    private bool lightCalculationg = false;

    private float tempGlobalLightTime;

    private float tempIntensivity;
    private float oilLevelTime;

    private float currentInsaniteLevel = 0;
    private float maxLampRadius;
    private float maxLampBrightness;


    private void Start()
    {
        exitPoint = SingleGameEnterPoint.instance.GetExitPoint();
        worldLight = SingleGameEnterPoint.instance.GetWorldTime().GetWorldLight();
        oilSlider = SingleGameEnterPoint.instance.GetPlayerUI().GetOilSlider();
        insanitySlider = SingleGameEnterPoint.instance.GetPlayerUI().GetInsanitySlider();
        maxLampRadius = playerLamp.pointLightInnerRadius;
        maxLampBrightness = playerLamp.intensity;
    }

    private void Update()
    {
        if (lightCalculationg)
        {
            float distance = Vector2.Distance(transform.position, exitPoint.position);
            float percent = distance / maxDistanceFromBase;
            percent = Mathf.Clamp(percent, 0.05f, 1);
            worldLight.intensity = maxIntensity * (1 - percent);

            oilLevelTime += Time.deltaTime;
            if (oilLevelTime >= 1)
            {
                if (lampOilLevel - oilLevelDecrement >= 0)
                {
                    lampOilLevel -= oilLevelDecrement;

                    UpdateOilUI(lampOilLevel);
                    if (lampOilLevel <= 30)
                    {
                        playerLamp.pointLightInnerRadius = 0.3f;
                        playerLamp.intensity = 0.25f;
                    }
                }

                if (lampOilLevel <= 30)
                {
                    currentInsaniteLevel += (fearLevel + (lampOilLevel <= 0 ? fearIncrease : 0));
                    if (currentInsaniteLevel >= maxInsanityLevel)
                        SingleGameEnterPoint.instance.GetGameplayHandler().Loose();
                    UpdateInsanityUI(currentInsaniteLevel);
                }
                oilLevelTime = 0;
            }
        }
    }

    public void SetLightCalculating(bool value)
    {
        lightCalculationg = value;
        playerLamp.enabled = value;
        if (!value)
        {
            StartCoroutine(SetMaxBrightnessCoroutine());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public void UpdateOilUI(float value)
    {
        float percent = value / 100;
        oilSlider.value = percent;
    }

    public void UpdateInsanityUI(float value)
    {
        float percent = value / maxInsanityLevel;
        insanitySlider.value = percent;
    }

    public void AddOil(float value)
    {
        lampOilLevel += value;
        lampOilLevel = Mathf.Clamp(lampOilLevel, 0, 100);
        if(lampOilLevel > 30)
        {
            playerLamp.pointLightInnerRadius = maxLampRadius;
            playerLamp.intensity = maxLampBrightness;
        }
        UpdateOilUI(lampOilLevel);
    }

    public void DecreaseInsanity(float value)
    {
        currentInsaniteLevel -= value;
        currentInsaniteLevel = Mathf.Clamp(currentInsaniteLevel, 0, maxInsanityLevel);
        UpdateInsanityUI(currentInsaniteLevel);
    }

    public bool isFull(int ButtonID)
    {
        if (ButtonID < 2) return lampOilLevel < 100;
        return currentInsaniteLevel > 0;
    }

    private IEnumerator SetMaxBrightnessCoroutine()
    {
        while(worldLight.intensity < maxIntensity)
        {
            tempGlobalLightTime += Time.deltaTime;
            tempIntensivity = Mathf.Lerp(worldLight.intensity, maxIntensity, tempGlobalLightTime / 1f);
            worldLight.intensity = tempIntensivity;
            yield return null;
        }
        tempGlobalLightTime = 0;
    }

}
