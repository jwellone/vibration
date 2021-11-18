#if UNITY_IOS
using System.Runtime.InteropServices;
using UnityEngine;

namespace jwellone.Device
{
	public class VibrationIOS : MonoBehaviour, IVibration
	{
		[DllImport("__Internal")]
		static extern void VibrationInitialize();

		[DllImport("__Internal")]
		static extern void VibrationTerminate();

		[DllImport("__Internal")]
		static extern void PlayVibration(float duration, float intensity, float sharpness, bool sustained);

		[DllImport("__Internal")]
		static extern void StopVibration();

		void Awake()
		{
			VibrationInitialize();
		}

		void OnApplicationPause(bool isPause)
		{
			if(isPause)
			{
				VibrationTerminate();
			}
			else
			{
				VibrationInitialize();
			}
		}

		public void Stop()
		{
			StopVibration();
		}

		public void Play(float seconds, float intensity, float sharpness)
		{
			PlayVibration(seconds, intensity, sharpness, true);
		}
	}
}
#endif
