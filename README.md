# Steamworksn't

A Steamworks SDK wrapper for Unity.

This repo should act as a good example for those seeking to call the Steamworks SDK directly from their C# code (and not just those using the Unity engine). Not all SDK functions are included in `Api.cs`, but you can easily add any you would like to call.

## Why

Existing wrappers such as Steamworks.NET or Facepunch.Steamworks can be opaque and stale, with multiple open issues and PRs at time of writing. I believe it is worth working directly with the Steamworks binaries and bringing the API calls into one's own code. That way you can understand what's going on under the hood, update SDK versions at any time, and make use of functionality you may have not otherwise.

## Version

This repo is currently set up for the Steamworks SDK v1.57. Keeping it up to date should be simple, as the SDK is kept stable over time.

## Setting up

1. Obtain the Steamworks SDK files and merge the `redistributable_bin` folder with the one present in `/sdk` (so `.meta` files are kept). I also like to keep the SDK's `public` folder in `/sdk` in order to reference those files while writing code.
1. For development only, place a `steam_appid.txt` file at the root of the Unity project. It should contain the game's steam app ID (commonly `480` for testing, representing the game Spacewar). Remember not to ship this file in distribution builds.
1. Add the `NetworkManager` component to an object in your Unity scene (typically left empty and also called `NetworkManager`.
1. Place other components as needed (TODO: more docs).

## Folder structure

### sdk

Contains necessary files from the Steamworks SDK (not included).

Note that each file in redistributable_bin is configured in the Unity inspector (thus having a corresponding .meta file in this repo) according to its target platform (OS & 32 or 64 bit). All of these files are set to be included in all platforms (although not sure if this remains true when adding support for new platforms into the project), and "load on startup" is left unchecked as it does not seem to be required.

The SDK's `Readme.txt` is also included in order to keep track of SDK version.

Note that when updating the binary for MacOS, it may be necessary to run `sudo xattr -r -d com.apple.quarantine libsteam_api.dylib` in `sdk/redistributable_bin/osx`. Otherwise, Unity will display an error pop-up when attempting to load it.

### SteamworksAPI

C# classes that act as an entrypoint into the Steamworks SDK. These classes use C#'s P/Invoke functionality (with `DllImport()`) to call into the SDK binaries.

### Internal

Functionality that is abstracted away from Unity `MonoBehaviour` components.

## Debugging

When debugging the Steam SDK one has to check the Unity log file directly with

`tail -f  ~/Library/Logs/Unity/Editor.log` (MacOS)

as logs for native (C++) plugins are not shown in the in-editor console.

For example, `SteamAPI_Init()` can return `false` and only log the failure reason to stderr.

## Callbacks

We do not call `SteamAPI_RunCallbacks()` because we handle callbacks manually. This is required since Steam's way of handling callbacks is specific to C++.

Callback types are identified by a number, which can be referenced in `steam_api.json` under `callback_structs` (using the `callback_id` field).

## Calling C++ from C#

To interact with the Steamworks SDK one must call the functions exposed by its binary files. This is done with the P/Invoke paradigm, using `DllImport()`.

Files `steam_api_flat.h` and `steam_api.json` are provided as a reference. The `S_API` macro indicates that a function is exposed through the SDK's binary files.

C++ style interfaces are worked around by calling "flat" functions that receive a reference to an existing interface, which they act upon.

Below is some information on P/Invoking C++ functions with `DllImport()`.

### Calling convention

Always specify `CallingConvention = CallingConvention.Cdecl`. That is the Steam SDK's expected calling convention, defined with `#define S_CALLTYPE __cdecl`.

Even though `__cdecl` is set to an empty string in `steam_api_common.h` for non-windows OSs:

```C++
// #define away __cdecl on posix.
// This is really, really bad.  We're sorry.  But it's been this way for
// a long time now and it's scary to change it, as there may be others that
// depend on it.
#ifndef _WIN32
	#define __cdecl
#endif
```

`Cdecl` is still the default in that case so it will still work.

### Marshaling booleans

Use `[return: MarshalAs(UnmanagedType.U1)]` when P/Invoking methods that return booleans (see https://learn.microsoft.com/en-us/visualstudio/code-quality/ca1414).

## License

This repository is licensed to the public domain.
