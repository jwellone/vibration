using UnityEngine;

namespace jwellone.Device
{
#if UNITY_EDITOR
	using VibrationComponent = Vibration;
#elif UNITY_IOS
    using VibrationComponent = VibrationIOS;
#elif UNITY_ANDROID
    using VibrationComponent = VibrationAndroid;
#else
    using VibrationComponent = Vibration;
#endif

	public static class VibrationManager
	{
		static IVibration _instance;

		[RuntimeInitializeOnLoadMethod]
		static void OnRuntimeInitializeOnLoadMethod()
		{
			var go = new GameObject("Vibration");
			GameObject.DontDestroyOnLoad(go);
			_instance = go.AddComponent<VibrationComponent>();
		}

		public static void Play(float seconds, float intensity, float sharpness)
		{
			_instance.Play(seconds, intensity, sharpness);
		}

		public static void Stop()
		{
			_instance.Stop();
		}
	}
}
