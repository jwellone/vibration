using System.Collections;
using UnityEngine;

namespace jwellone.Device
{
	public class Vibration : MonoBehaviour, IVibration
	{
		readonly WaitForSeconds _playbackSeconds = new WaitForSeconds(0.5f);

		public void Stop()
		{
			StopAllCoroutines();
		}

		public void Play(float seconds, float intensity, float sharpness)
		{
			Stop();
			StartCoroutine(OnPlay(seconds));
		}

		IEnumerator OnPlay(float seconds)
		{
			var endTime = Time.realtimeSinceStartup + seconds;
			while (Time.realtimeSinceStartup < endTime)
			{
				Handheld.Vibrate();
				yield return _playbackSeconds;
			}
		}
	}
}
