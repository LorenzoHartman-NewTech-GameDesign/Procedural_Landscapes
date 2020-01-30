**************************************
*            GLOBAL SNOW             *
* Created by Ramiro Oliva (Kronnect) * 
*            README FILE             *
**************************************


How to use this asset
---------------------
Firstly, you should run the Demo Scene provided to get an idea of the overall functionality.
Later, please read the documentation and experiment with the system.

Hint: to quick start using the asset just add GlobalSnow script to your camera. It will show up in the Game view. Customize it using the custom inspector.


Documentation/API reference
---------------------------
The PDF is located in the Documentation folder. It contains instructions on how to use this asset as well as a useful Frequent Asked Question section.


Support
-------
Please read the documentation PDF and browse/play with the demo scene and sample source code included before contacting us for support :-)

* Support: contact@kronnect.me
* Website-Forum: http://kronnect.me
* Twitter: @KronnectGames


Future updates
--------------

All our assets follow an incremental development process by which a few beta releases are published on our support forum (kronnect.com).
We encourage you to signup and engage our forum. The forum is the primary support and feature discussions medium.

Of course, all updates of Global Snow will be eventually available on the Asset Store.


Version history
---------------
V5.0.1 Changes:
- [Fix] Fixed layer mask issue in deferred rendering path

V5.0 Changes:
- Added in-SceneView snow mask editor
- Optimization (deferred): snow exclusion logic now integrated in main CommandBuffer
- [Fix] Fixed VR exclusion issues on Unity 2018.1
- [Fix] Fixed inspector issues on Unity 2018.1

V4.3.4 Changes:
- Deferred or forward rendering path support files can now be safely removed to reduce app size and build time

V4.3.3 Changes:
- [Fix] Removed warning when building and SceneView snow preview cannot be unloaded

V4.3.2 Changes:
- Added "Deferred Camera Event" option in inspector (only deferred mode, useful to change commandBuffer event if deferred reflections are disabled)

V4.3.1 Changes:
- Added "Excluded Cast Shadows" option in inspector (only forward rendering path)
- [Fix] Fixed shadows on snow from objects not included in layer mask (only forward rendering path)

V4.3 Changes:
- Added snow tint color option (alpha controls saturation)
- [Fix] Fixed snow exclusion issue in Scene View

V4.2.1 Changes:
- Snowfall is more dynamic
- [Fix] Fixed issue with forward rendering workflow dependencies when deferred is used

V4.2 Changes:
- Added snow amount parameter
- Added altitude blending parameter
- Improved compatibility with CTS

V4.1 Changes:
- New holes prefabs
- Improved performance in deferred rendering path
- World Manager API integration

V4.0.2 Changes:
- [Fix] Added workaround for Unity 2017.3 surface shader normal bug

V4.0.1 Changes:
- [Fix] Fixed compiler error on PS4

V4.0 Changes:
- New inspector option to show snow in Scene View
- 2 new hole prefabs (CircularHole / QuadHole) in Resources/Prefabs folder

V3.3 Changes:
- Snowfall effect: added particle shadow support
- 3 snow footfalls audio clips included
- Support for water reflections in Unity Water

V3.2.1 Changes:
- [Fix] Fixed "moving" snow over some models when Relief mapping is enabled
- [Fix] Fixed minor naming typo in one of the shaders

V3.2 Changes:
- Grass can now be fully covered by snow
- Exposed character controller into the inspector
- GlobalSnow Volume: define areas where snow is deactivated automatically
- [Fix] Fixed incompatibility with Ceto ocean system underwater effect
- [Fix] Fixed coverage flashing artifact due to HDR issues
- [Fix] Fixed infinite loop bug when searching for character controller

V3.1 Changes:
- Added Zenithal mask to provide better control over which objects can occlude other objects beneath them
- Coverage algorithm now also takes into account camera culling mask
- Improved first person character component detection
- Additional controls for distance snow: ignore normals, slope controls, ignore coverage
- New quality presets: faster and fastest
- [Fix] Fixed bug when no light is found in the scene
- [Fix] Fixed render texture issue with Unity 2017.1

V3.0.1 Changes:
- Exposed internal default exclusion layer to allow greater flexibility when excluding specific objects from snow (see documentation)
- [Fix] Fixed layer culling issue

V3.0 Changes:
- New slope controls: threadhold, sharpness, noise
- Added Vegetation Offset parameter to control altitude cover over grass and trees
- Added option for hot keys "K" and "J" to change snow altitude at runtime

V2.4 Changes:
- Separated Tree Billboard coverage from Grass coverage parameters
- Added support for SpeedTree billboard shadows on snow
- Improved SpeedTree billboard snow shading
- Added optional support for Unity standard tree billboard (read FAQ)

V2.3 Changes:
- Support for Unity 5.6 speed tree shaders
- New footprints scale and obscurance parameters
- [Fix] Fixed Speed Tree replacement shader issue at build time

V2.2 Changes:
- Added Coverage Update parameter to control when coverage should be computed
- [Fix] Fixed coverage issue with overlapping objects

v2.1 Changes:
- Added option to remove leaves of trees (only SpeedTree)
- Added VR/Single Pass Stereo Rendering compatibility

v2.0.2 Changes:
- [Fix] Removed build warning on DX9 (Global Snow requires SM 3.0+)

v2.0.1 Changes:
- [Fix] Fixed FPS weapons cutout issue on the snow

v2.0 Changes:
- Added "Distance Optimization" option which greatly improve performance by reducing detail beyond a given distance to camera
- Improved snowfall performance
- Added new quality preset: "Medium"
- Improved snow altitude scattering quality
- Fixed snow disappearing over some areas

v1.1 Changes:
- Added ground coverage slider
- Added tree billboard / grass coverage slider
- Fixed Unity tree creator clipping issues
- Fixed Sun cone showing over mountains
- Fixed TransparentCutout materials being snowed when excluded
- Fixed snow disappearing when camera is moved away from scene

V1.0 First Release
