#import <CoreHaptics/CoreHaptics.h>

API_AVAILABLE(ios(13.0))
static CHHapticEngine* _engine;

API_AVAILABLE(ios(13.0))
static id<CHHapticAdvancedPatternPlayer> _player = nil;

void VibrationInitialize()
{
	if(_engine==nil)
	{
		_engine = [[CHHapticEngine alloc] initAndReturnError:nil];
		[_engine startAndReturnError:nil];
	}
}

BOOL SupportsHaptics()
{
	if (@available(iOS 13.0, *))
	{
		return [[CHHapticEngine capabilitiesForHardware] supportsHaptics];
	}
	return false;
}

void StopVibration()
{
	if(_player!=nil)
	{
		[_player cancelAndReturnError:nil];
		_player = nil;
	}
}

void PlayVibration(float duration, float intensity, float sharpness, bool sustained)
{
	CHHapticEventParameter* intensityParam = [[CHHapticEventParameter alloc] initWithParameterID:CHHapticEventParameterIDHapticIntensity value:intensity];

	CHHapticEventParameter* sharpnessParam = [[CHHapticEventParameter alloc] initWithParameterID:CHHapticEventParameterIDHapticSharpness value:sharpness];

	CHHapticEventParameter* sustainedParam = [[CHHapticEventParameter alloc] initWithParameterID:CHHapticEventParameterIDSustained value:sustained ? 1 : 0];
	
	CHHapticEventParameter* event = [[CHHapticEvent alloc] initWithEventType:CHHapticEventTypeHapticContinuous parameters:@[intensityParam, sharpnessParam, sustainedParam] relativeTime:0 duration:duration];

	CHHapticPattern* patten = [[CHHapticPattern alloc] initWithEvents:@[event] parameterCurves:@[] error:nil];

	StopVibration();
	
	_player = [_engine createAdvancedPlayerWithPattern:patten error:nil];
	[_player startAtTime:0 error:nil];
}

void VibrationTerminate()
{
	StopVibration();
	
	if(_engine!=nil)
	{
		[_engine stopWithCompletionHandler:nil];
		_engine = nil;
	}
}
