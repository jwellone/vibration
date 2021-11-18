namespace jwellone.Device
{
	public interface IVibration
	{
		void Stop();
		void Play(float seconds, float intensity, float sharpness);
	}
}
