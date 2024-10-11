using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

namespace Tkfkadlsi
{
    public class DayAndNight : MonoBehaviour
    {
        public UnityEvent<int> OnDay;

        public enum TimeState
        {
            Day = 0,
            Night = 1
        }

        [Range(0f, 1440f)] public float CurrentTime;
        public TimeState dayNight = TimeState.Day;
        public int dayCount = 0;

        [SerializeField] private int startTime;
        [SerializeField] private Color DayLight;
        [SerializeField] private Color NightLight;
        [SerializeField] private float lightColorChangeTime;

        private IEnumerator timeFlowCouroutine;
        private IEnumerator lightColorChange_DayToNight;
        private IEnumerator lightColorChange_NightToDay;
        private Light2D Global_Light;

        [SerializeField] private TextMeshProUGUI waveViewer;

        public float TimeSpeed;
        //TimeSpeed가 1일때, 24분이 하루임.

        public void TimeFlowOn()
        {
            StartCoroutine(timeFlowCouroutine);
        }

        public void TimeFlowOff()
        {
            StartCoroutine(timeFlowCouroutine);
        }

        private void Awake()
        {
            CurrentTime = startTime;

            timeFlowCouroutine = TimeFlow();
            Global_Light = GetComponentInChildren<Light2D>();
            Global_Light.color = NightLight;
        }

        //스타트는 테스트용임
        private void Start()
        {
            TimeFlowOn();
        }

        private IEnumerator TimeFlow()
        {
            CurrentTime += 1;
            if (CurrentTime == 1440f) NextDay();

            if (CurrentTime == 0f) NightToDay();
            if (CurrentTime == 480f) DayToNight();

            yield return new WaitForSeconds(1 / TimeSpeed);

            timeFlowCouroutine = TimeFlow();
            StartCoroutine(timeFlowCouroutine);
        }

        private void DayToNight()
        {
            lightColorChange_DayToNight = LightColor_Change(DayLight, NightLight);
            StartCoroutine(lightColorChange_DayToNight);
            dayNight = TimeState.Night;
        }

        private void NightToDay()
        {
            lightColorChange_NightToDay = LightColor_Change(NightLight, DayLight);
            StartCoroutine(lightColorChange_NightToDay);
            dayNight = TimeState.Day;
            OnDay?.Invoke(dayCount);
        }

        private void NextDay()
        {
            dayCount++;
            CurrentTime = 0;
        }

        private IEnumerator LightColor_Change(Color CurrentStateColor, Color NextStateColor)
        {
            float t = 0f;

            while (t < lightColorChangeTime)
            {
                Global_Light.color
                    = Color.Lerp(CurrentStateColor, NextStateColor, t / lightColorChangeTime);

                t += Time.deltaTime;
                yield return null;
            }

            Global_Light.color = NextStateColor;
        }

        public void WaveViewerUpdate(int wave)
        {
            waveViewer.text = $"Wave {wave.ToString("D1")}";
        }
    }
}
