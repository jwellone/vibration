#if UNITY_ANDROID
using UnityEngine;

namespace jwellone.Device
{
	public class VibrationAndroid : MonoBehaviour, IVibration
	{
		static readonly AndroidJavaClass _unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		static readonly AndroidJavaObject _currentActivity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		static readonly AndroidJavaObject _vibrator = _currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

		public void Stop()
		{
			_vibrator.Call("cancel");
		}

		public void Play(float seconds, float intensity, float sharpness)
		{
			_vibrator.Call("vibrate", (long)(seconds * 1000));
		}
	}
}
#endif