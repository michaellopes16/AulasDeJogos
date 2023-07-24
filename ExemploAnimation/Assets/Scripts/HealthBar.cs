using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    //Set max value allowed to health bar
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;

         fill.color = gradient.Evaluate(1f);
    }

    // Set the value of slider health bar
    public void SetHealth(int health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
