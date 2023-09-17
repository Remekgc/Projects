// Copyright Epic Games, Inc. All Rights Reserved.

#include "IntroAndSetupGameMode.h"
#include "IntroAndSetupCharacter.h"
#include "UObject/ConstructorHelpers.h"

AIntroAndSetupGameMode::AIntroAndSetupGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPerson/Blueprints/BP_ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
