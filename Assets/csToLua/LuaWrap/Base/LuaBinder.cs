﻿using System;
public static class LuaBinder
{
	public static void Bind(IntPtr L)
	{

        wheelWrap.Register(L);
        RtmpC2SWrap.Register(L);
		objectWrap.Register(L);
        ObjectWrap.Register(L);
        CoroutineWrap.Register(L);
		FilterModeWrap.Register(L);
		TextureWrapModeWrap.Register(L);
		NPOTSupportWrap.Register(L);
		TextureFormatWrap.Register(L);
		CubemapFaceWrap.Register(L);
		RenderTextureFormatWrap.Register(L);
		RenderTextureReadWriteWrap.Register(L);
		BlendModeWrap.Register(L);
		BlendOpWrap.Register(L);
		CompareFunctionWrap.Register(L);
		CullModeWrap.Register(L);
		ColorWriteMaskWrap.Register(L);
		StencilOpWrap.Register(L);
		SecurityWrap.Register(L);
		StackTraceUtilityWrap.Register(L);
		UnityExceptionWrap.Register(L);
		MissingComponentExceptionWrap.Register(L);
		UnassignedReferenceExceptionWrap.Register(L);
		MissingReferenceExceptionWrap.Register(L);		
		//WWWWrap.Register(L);
		GenericStackWrap.Register(L);
		ForceModeWrap.Register(L);
		PhysicsWrap.Register(L);
		RigidbodyConstraintsWrap.Register(L);
		RigidbodyWrap.Register(L);
		RigidbodyInterpolationWrap.Register(L);
		JointMotorWrap.Register(L);
		JointSpringWrap.Register(L);
		JointLimitsWrap.Register(L);
		JointWrap.Register(L);
        //JsonManagerWrap.Register(L);
        HingeJointWrap.Register(L);
		SpringJointWrap.Register(L);
		FixedJointWrap.Register(L);
		SoftJointLimitWrap.Register(L);
		JointDriveModeWrap.Register(L);
		JointProjectionModeWrap.Register(L);
		JointDriveWrap.Register(L);
		CharacterJointWrap.Register(L);
		RotationDriveModeWrap.Register(L);
		ConfigurableJointWrap.Register(L);
		ConstantForceWrap.Register(L);
		CollisionDetectionModeWrap.Register(L);
		ColliderWrap.Register(L);
		BoxColliderWrap.Register(L);
		SphereColliderWrap.Register(L);
		MeshColliderWrap.Register(L);
		CapsuleColliderWrap.Register(L);
		WheelFrictionCurveWrap.Register(L);
		WheelHitWrap.Register(L);
		WheelColliderWrap.Register(L);
		RaycastHitWrap.Register(L);
		PhysicMaterialCombineWrap.Register(L);
		PhysicMaterialWrap.Register(L);
		ContactPointWrap.Register(L);
		CollisionWrap.Register(L);
		CollisionFlagsWrap.Register(L);
		ControllerColliderHitWrap.Register(L);
		CharacterControllerWrap.Register(L);
		ClothWrap.Register(L);
		InteractiveClothWrap.Register(L);
		ClothSkinningCoefficientWrap.Register(L);
		SkinnedClothWrap.Register(L);
		ClothRendererWrap.Register(L);
		Physics2DWrap.Register(L);
		RaycastHit2DWrap.Register(L);
		RigidbodyInterpolation2DWrap.Register(L);
		RigidbodySleepMode2DWrap.Register(L);
		CollisionDetectionMode2DWrap.Register(L);
		ForceMode2DWrap.Register(L);
		Rigidbody2DWrap.Register(L);
		Collider2DWrap.Register(L);
		CircleCollider2DWrap.Register(L);
		BoxCollider2DWrap.Register(L);
		EdgeCollider2DWrap.Register(L);
		PolygonCollider2DWrap.Register(L);
		ContactPoint2DWrap.Register(L);
		Collision2DWrap.Register(L);
		JointLimitState2DWrap.Register(L);
		JointAngleLimits2DWrap.Register(L);
		JointTranslationLimits2DWrap.Register(L);
		JointMotor2DWrap.Register(L);
		JointSuspension2DWrap.Register(L);
		Joint2DWrap.Register(L);
		AnchoredJoint2DWrap.Register(L);
		SpringJoint2DWrap.Register(L);
		DistanceJoint2DWrap.Register(L);
		HingeJoint2DWrap.Register(L);
		SliderJoint2DWrap.Register(L);
		WheelJoint2DWrap.Register(L);
		PhysicsMaterial2DWrap.Register(L);
		ObstacleAvoidanceTypeWrap.Register(L);
		NavMeshAgentWrap.Register(L);
		OffMeshLinkTypeWrap.Register(L);
		OffMeshLinkDataWrap.Register(L);
		NavMeshHitWrap.Register(L);
		NavMeshTriangulationWrap.Register(L);
		NavMeshWrap.Register(L);
		OffMeshLinkWrap.Register(L);
		NavMeshPathStatusWrap.Register(L);
		NavMeshPathWrap.Register(L);
		NavMeshObstacleWrap.Register(L);
		AudioSpeakerModeWrap.Register(L);
		AudioSettingsWrap.Register(L);
		AudioTypeWrap.Register(L);
		AudioClipWrap.Register(L);
		AudioVelocityUpdateModeWrap.Register(L);
		AudioListenerWrap.Register(L);
		AudioRolloffModeWrap.Register(L);
		AudioSourceWrap.Register(L);
		AudioReverbPresetWrap.Register(L);
		AudioReverbZoneWrap.Register(L);
		AudioLowPassFilterWrap.Register(L);
		AudioHighPassFilterWrap.Register(L);
		AudioDistortionFilterWrap.Register(L);
		AudioEchoFilterWrap.Register(L);
		AudioChorusFilterWrap.Register(L);
		AudioReverbFilterWrap.Register(L);
		MicrophoneWrap.Register(L);
		WebCamFlagsWrap.Register(L);
		WebCamDeviceWrap.Register(L);
		WebCamTextureWrap.Register(L);
		AnimationClipPairWrap.Register(L);
		AnimatorOverrideControllerWrap.Register(L);
		WrapModeWrap.Register(L);
		AnimationEventWrap.Register(L);
		AnimationClipWrap.Register(L);
		KeyframeWrap.Register(L);
		AnimationCurveWrap.Register(L);
		PlayModeWrap.Register(L);
		QueueModeWrap.Register(L);
		AnimationBlendModeWrap.Register(L);
		AnimationPlayModeWrap.Register(L);
		AnimationCullingTypeWrap.Register(L);
		AnimationWrap.Register(L);
		AnimationStateWrap.Register(L);
		GameObjectWrap.Register(L);
		AvatarTargetWrap.Register(L);
		AvatarIKGoalWrap.Register(L);
		AnimationInfoWrap.Register(L);
		AnimatorCullingModeWrap.Register(L);
		AnimatorUpdateModeWrap.Register(L);
		AnimatorStateInfoWrap.Register(L);
		AnimatorTransitionInfoWrap.Register(L);
		MatchTargetWeightMaskWrap.Register(L);
		AnimatorWrap.Register(L);
		AnimatorUtilityWrap.Register(L);
		SkeletonBoneWrap.Register(L);
		HumanLimitWrap.Register(L);
		HumanBoneWrap.Register(L);
		HumanDescriptionWrap.Register(L);
		AvatarBuilderWrap.Register(L);
		RuntimeAnimatorControllerWrap.Register(L);
		HumanBodyBonesWrap.Register(L);
		AvatarWrap.Register(L);
		HumanTraitWrap.Register(L);
		UIVertexWrap.Register(L);
		AssetBundleWrap.Register(L);
		HideFlagsWrap.Register(L);
		SendMessageOptionsWrap.Register(L);
		PrimitiveTypeWrap.Register(L);
		SpaceWrap.Register(L);
		LayerMaskWrap.Register(L);
		RuntimePlatformWrap.Register(L);
		SystemLanguageWrap.Register(L);
		LogTypeWrap.Register(L);
		DeviceTypeWrap.Register(L);
		SystemInfoWrap.Register(L);
		ScriptableObjectWrap.Register(L);
		ResourcesWrap.Register(L);
		ThreadPriorityWrap.Register(L);
		ProfilerWrap.Register(L);
		ReproductionWrap.Register(L);
		CrashReportWrap.Register(L);
		LightTypeWrap.Register(L);
		LightRenderModeWrap.Register(L);
		LightShadowsWrap.Register(L);
		OcclusionAreaWrap.Register(L);
		OcclusionPortalWrap.Register(L);
		FogModeWrap.Register(L);
		RenderSettingsWrap.Register(L);
		ShadowProjectionWrap.Register(L);
		QualitySettingsWrap.Register(L);
		CameraClearFlagsWrap.Register(L);
		DepthTextureModeWrap.Register(L);
		TexGenModeWrap.Register(L);
		AnisotropicFilteringWrap.Register(L);
		BlendWeightsWrap.Register(L);
		MeshFilterWrap.Register(L);
		CombineInstanceWrap.Register(L);
		MeshTopologyWrap.Register(L);
		MeshWrap.Register(L);
		BoneWeightWrap.Register(L);
		SkinQualityWrap.Register(L);
		SkinnedMeshRendererWrap.Register(L);
		FlareWrap.Register(L);
		LensFlareWrap.Register(L);
		RendererWrap.Register(L);
		ProjectorWrap.Register(L);
		SkyboxWrap.Register(L);
		TextMeshWrap.Register(L);
		ParticleWrap.Register(L);
		ParticleEmitterWrap.Register(L);
		ParticleAnimatorWrap.Register(L);
		TrailRendererWrap.Register(L);
		ParticleRenderModeWrap.Register(L);
		ParticleRendererWrap.Register(L);
		LineRendererWrap.Register(L);
		MaterialPropertyBlockWrap.Register(L);
		RenderBufferWrap.Register(L);
		GraphicsWrap.Register(L);
		ResolutionWrap.Register(L);
		LightmapDataWrap.Register(L);
		LightmapsModeWrap.Register(L);
		ColorSpaceWrap.Register(L);
		LightProbesWrap.Register(L);
		LightmapSettingsWrap.Register(L);
		GeometryUtilityWrap.Register(L);
		ScreenOrientationWrap.Register(L);
		ScreenWrap.Register(L);
		SleepTimeoutWrap.Register(L);
		GLWrap.Register(L);
		MeshRendererWrap.Register(L);
		StaticBatchingUtilityWrap.Register(L);
		ImageEffectTransformsToLDRWrap.Register(L);
		ImageEffectOpaqueWrap.Register(L);
		TextureWrap.Register(L);
		Texture2DWrap.Register(L);
		CubemapWrap.Register(L);
		Texture3DWrap.Register(L);
		SparseTextureWrap.Register(L);
		RenderTextureWrap.Register(L);		
		CharacterInfoWrap.Register(L);
		FontWrap.Register(L);
		UICharInfoWrap.Register(L);
		UILineInfoWrap.Register(L);
		LODWrap.Register(L);
		LODGroupWrap.Register(L);
		GradientColorKeyWrap.Register(L);
		GradientAlphaKeyWrap.Register(L);
		GradientWrap.Register(L);
		ScaleModeWrap.Register(L);
		FocusTypeWrap.Register(L);
		RectOffsetWrap.Register(L);		
		ImagePositionWrap.Register(L);
		EventWrap.Register(L);
		KeyCodeWrap.Register(L);
		LightProbeGroupWrap.Register(L);
		Vector2Wrap.Register(L);
		Vector3Wrap.Register(L);
		ColorWrap.Register(L);
		Color32Wrap.Register(L);
		QuaternionWrap.Register(L);
		RectWrap.Register(L);
		Matrix4x4Wrap.Register(L);
		BoundsWrap.Register(L);
		Vector4Wrap.Register(L);
		RayWrap.Register(L);
		Ray2DWrap.Register(L);
		PlaneWrap.Register(L);
		PingWrap.Register(L);
		ParticleSystemRenderModeWrap.Register(L);
		ParticleSystemSimulationSpaceWrap.Register(L);
		ParticleSystemWrap.Register(L);
		ParticleSystemParticleWrap.Register(L);
		ParticleSystemCollisionEventWrap.Register(L);
		ParticleSystemRendererWrap.Register(L);		
		ISerializationCallbackReceiverWrap.Register(L);
		ShaderWrap.Register(L);
		MaterialWrap.Register(L);
		ProceduralProcessorUsageWrap.Register(L);
		ProceduralCacheSizeWrap.Register(L);
		ProceduralLoadingBehaviorWrap.Register(L);
		ProceduralPropertyTypeWrap.Register(L);
		ProceduralOutputTypeWrap.Register(L);
		ProceduralPropertyDescriptionWrap.Register(L);
		ProceduralMaterialWrap.Register(L);
		ProceduralTextureWrap.Register(L);
		SpriteAlignmentWrap.Register(L);
		SpritePackingModeWrap.Register(L);
		SpritePackingRotationWrap.Register(L);
		SpriteMeshTypeWrap.Register(L);
		SpriteWrap.Register(L);
		SpriteRendererWrap.Register(L);
		DataUtilityWrap.Register(L);
		WWWFormWrap.Register(L);
		CachingWrap.Register(L);
		ApplicationWrap.Register(L);
		UserAuthorizationWrap.Register(L);
		BehaviourWrap.Register(L);
		RenderingPathWrap.Register(L);
		TransparencySortModeWrap.Register(L);
		CameraWrap.Register(L);
		ComputeShaderWrap.Register(L);
		ComputeBufferTypeWrap.Register(L);
		ComputeBufferWrap.Register(L);
		DebugWrap.Register(L);
		DisplayWrap.Register(L);
		MonoBehaviourWrap.Register(L);
		TouchPhaseWrap.Register(L);
		IMECompositionModeWrap.Register(L);
		TouchWrap.Register(L);
		DeviceOrientationWrap.Register(L);
		AccelerationEventWrap.Register(L);
		GyroscopeWrap.Register(L);
		LocationInfoWrap.Register(L);
		LocationServiceStatusWrap.Register(L);
		LocationServiceWrap.Register(L);
		CompassWrap.Register(L);
		InputWrap.Register(L);
		ComponentWrap.Register(L);
		LightWrap.Register(L);
		TransformWrap.Register(L);
		TimeWrap.Register(L);
		PlayerPrefsExceptionWrap.Register(L);
		PlayerPrefsWrap.Register(L);
	}
}
