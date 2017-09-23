using System;


public interface ITimable
{
	float Frequency { get; set; }
	float Time { get; set; }
	float Delay { get; set; }

	void Start();
	void Stop();
	void Process(float deltaTime);
}
