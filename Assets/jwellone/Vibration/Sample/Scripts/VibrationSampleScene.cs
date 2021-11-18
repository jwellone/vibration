using System;
using UnityEngine;
using UnityEngine.UI;
using jwellone.Device;

namespace jwellone.Sample
{
	public class VibrationSampleScene : MonoBehaviour
	{
		[Serializable]
		class SliderUI
		{
			[SerializeField] Text m_text;
			[SerializeField] Slider m_slider;

			public float value => m_slider.value / 10f;

			public void Setup()
			{
				m_slider.onValueChanged.AddListener(_ =>
				{
					UpdateText();
				});

				UpdateText();
			}

			private void UpdateText()
			{
				m_text.text = m_slider.name + ":" + value;
			}
		}

		[SerializeField] SliderUI m_secondsSlider;
		[SerializeField] SliderUI m_intensitySlider;
		[SerializeField] SliderUI m_sharpnessSlider;

		private void Awake()
		{
			m_secondsSlider.Setup();
			m_intensitySlider.Setup();
			m_sharpnessSlider.Setup();
		}

		public void OnClickPlay()
		{
			VibrationManager.Play(
				m_secondsSlider.value,
				m_intensitySlider.value,
				m_sharpnessSlider.value);
		}

		public void OnClickStop()
		{
			VibrationManager.Stop();
		}

	}
}
