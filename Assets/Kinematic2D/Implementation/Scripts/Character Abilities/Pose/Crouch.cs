﻿using UnityEngine;
using Lightbug.CoreUtilities;


namespace Lightbug.Kinematic2D.Implementation
{

[AddComponentMenu("Kinematic2D/Implementation/Abilities/Body Size")]
public class Crouch : CharacterAbility
{
	#region Events	

	public event CharacterAbilityEvent OnCrouchStart;
	public event CharacterAbilityEvent OnCrouchEnd;
	
	#endregion


	[Range_NoSlider(true)]
	[SerializeField]
	float crouchHeight = 0.75f;

	[Range_NoSlider(true)]
	[SerializeField]
	float crouchFactor = 5;

	Vector3 targetSize;
	LayerMask layerMask;

	protected override void Awake()
	{
		base.Awake();

		targetSize = characterBody.CharacterSize;

		layerMask = characterController2D.layerMaskSettings.profile.obstacles;

	}


	public override void Process( float dt )
	{   	
		if( !movementController.isCurrentlyOnState( MovementState.Normal ) )
			return;
		

		switch( characterController2D.CurrentPoseState )
		{
			case PoseState.Normal:

				if( characterController2D.IsGrounded )
				{
					if( characterBrain.CharacterAction.down )
					{
						poseController.SetState( PoseState.Crouch );

						if( OnCrouchStart != null )
							OnCrouchStart();
					}
					
				}
				
				StandUp();

				break;

			case PoseState.Crouch:

				if( characterController2D.IsGrounded )
				{
					if( !characterBrain.CharacterAction.down )
					{
						if( CanStandUp() )
						{
							poseController.SetState( PoseState.Normal );

							if( OnCrouchEnd != null )
								OnCrouchEnd();
						}
					}
					
				}
				else
				{
					if( CanStandUp() )
					{
						poseController.SetState( PoseState.Normal );

						if( OnCrouchEnd != null )
							OnCrouchEnd();

					}
				}

				
				

				DoCrouch();

				break;
		}

		UpdateBodySize( dt );
		
	}

	void UpdateBodySize( float dt )
	{		
		Vector3 size = Vector3.Lerp( characterBody.CharacterSize , targetSize , crouchFactor * dt );
		characterBody.SetCharacterSize( size );
	}

	/// <summary>
	/// Check if the character is able to stand up.
	/// </summary>
	public bool CanStandUp()
	{
		float offset = characterBody.SkinWidth + characterBody.BoxThickness/2;
		Vector3 origin = transform.position + 
		transform.up * offset;

		Vector3 boxSize = new Vector3( 
			characterBody.verticalArea , 
			characterBody.BoxThickness , 
			characterBody.depth
		);

		if( characterBody.Is3D() )
		{
			RaycastHit hitInfo;
			
			Physics.BoxCast(
				origin ,
				boxSize / 2 ,
				transform.up ,				
				out hitInfo ,
				transform.rotation ,
				characterBody.InitialHeight - ( offset + characterBody.BoxThickness/2 ) ,
				layerMask
			);

			if( hitInfo.collider != null )
				return false;

			
		}
		else
		{
			RaycastHit2D hitInfo = Physics2D.BoxCast(
				origin ,
				boxSize ,
				Utilities.SignedAngle( Vector2.up , transform.up , characterBody.bodyTransform.Forward ),
				transform.up ,
				characterBody.InitialHeight - ( offset + characterBody.BoxThickness/2 ),
				layerMask
			);

			if( hitInfo.collider != null )
				return false;
		}


		return true;
		
	}


	/// <summary>
	/// Make the character crouch.
	/// </summary>
	public void DoCrouch()
	{

		targetSize = new Vector3(
			characterBody.InitialWidth ,
			crouchHeight ,
			characterBody.depth
		);
		
	}

	/// <summary>
	/// Make the character stand up.
	/// </summary>
	public void StandUp()
	{
		targetSize = characterBody.InitialSize;
	}

	

	
	public override string GetInfo()
	{ 
		return "Pressing the \"Down\" input will make the character crouch to a given height. " + 
		"The \"Crouch factor\" will determine how fast the ability is performed (lerping factor)."; 
	}

	
}

}


