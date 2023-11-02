# Steamworksn't

A minimal Steamworks SDK wrapper, focusing on doing-it-yourself and staying as close to the original code as possible.

There is no build step - you can use this code directly in your Unity/C# project.

Not all SDK functions are included in `Api.cs`, but you can easily add any you would like to call.

## SDK Version

This repo is currently set up for the Steamworks SDK v1.57.

Keeping it up to date should be simple, as there seems to be an effort to avoid breaking changes to the SDK by its maintainers at Valve.

## Why

The Steamworks SDK is based on C++ and thus is not straightforward to interop with from C# code. One has to use P/Invoke, a way to call functions declared in binary files (such as `.dll` on Windows).

Existing wrappers such as Steamworks.NET or Facepunch.Steamworks can be opaque and stale, with multiple open issues and PRs at time of writing. I believe it is worth working directly with the Steamworks binaries and bringing the API calls into one's own code. That way you can understand what's going on under the hood, update SDK versions at any time, and make use of functionality you may have not otherwise.

## Setting up

1. Place this repo in your Unity project's `Assets` folder. I like to set up my dependencies with git submodules, so to include this repo in my project I run `git submodule add https://github.com/marcospgp/steamworksnt.git` and run `git submodule update --init --recursive --merge --remote` whenever I want to update the dependency or set it up for the first time after a fresh `git clone`.
1. Obtain the Steamworks SDK files and merge its `redistributable_bin` folder with the one in this repo. This will make Unity rely on the `.meta` files included here to configure which platform each binary should be loaded for (you can check these settings in the Unity inspector). Note that if you opened the Unity editor since the previous step, the `.meta` files may have been deleted and will have to be re-added.
1. For development only, place a `steam_appid.txt` file at the root of your Unity project. It should contain the game's Steam app ID (commonly `480` for testing, representing the game Spacewar). Remember not to ship this file in distribution builds.

Note that when updating the binary for MacOS, it may be necessary to run `sudo xattr -r -d com.apple.quarantine libsteam_api.dylib` in `sdk/redistributable_bin/osx`. Otherwise, Unity will display an error pop-up when attempting to load it.

## Usage

### Initialization & shutdown

1. Call `Steamworks.Init()` before anything else and handle its result accordingly (a restart may be required by Steam, for example)
1. Call `Callbacks.RunFrame()` once per frame (in `Update()`)
1. Call `Steamworks.Shutdown()` in an `Application.quitting` event handler

### Making use of the SDK

Check other root-level files for additional exposed functionality.
Alternatively, accessing the API directly through the `Api` class is also possible.

## Debugging

(See [Debugging the Steamworks API](https://partner.steamgames.com/doc/sdk/api/debugging) for more info)

### Log file

When debugging the Steam SDK one has to check the Unity log file directly with

`tail -f  ~/Library/Logs/Unity/Editor.log` (MacOS)

as logs for native plugins are not shown in the in-editor console. For example, `SteamAPI_Init()` can return `false`, with the failure reason only being logged to `Editor.log`.

Lines in `Editor.log` from the Steamworks SDK should be prefixed with `[S_API]`.

### Steam flags

Open steam in debugging mode with `open /Applications/Steam.app --args -console -debug_steamapi`.

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

### Marshaling

Tips on converting types when receiving or passing values from P/Invoke method calls.

#### Booleans

Use `[MarshalAs(UnmanagedType.U1)]` and `[return: MarshalAs(UnmanagedType.U1)]` when passing or receiving booleans (see https://learn.microsoft.com/en-us/visualstudio/code-quality/ca1414).

#### Strings

- When receiving strings, use `Marshal.PtrToStringUTF8()`
- When adding strings to shared structs, use `[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]` (replace 256 with the actual string size)

## Callbacks

We do not call `SteamAPI_RunCallbacks()` because we handle callbacks manually. This is required since Steam's way of handling callbacks is specific to C++.

Callback types are identified by a number, which can be referenced in `steam_api.json` under `callback_structs` (using the `callback_id` field).

## License

```
This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <https://unlicense.org>
```
