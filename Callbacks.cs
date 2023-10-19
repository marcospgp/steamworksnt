using System;
using System.Collections.Generic;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Callbacks
    {
        private static Int32 hSteamPipe;

        private static Dictionary<int, string> _callbacksById;

        /// <summary>
        /// Must be called once before anything else on this class.
        /// </summary>
        public static void Init()
        {
            // We use manual callbacks and do not call SteamAPI_RunCallbacks().
            Api.SteamAPI_ManualDispatch_Init();

            hSteamPipe = Api.SteamAPI_GetHSteamPipe();
        }

        /// <summary>
        /// This should be called once per frame (that is, in Update()), as it
        /// is similar to SteamAPI_RunCallbacks() about which the Steamworks SDK
        /// docs say "Most games call this once per render-frame".
        /// TODO: Consider making this async.
        /// </summary>
        public static void RunFrame()
        {
            Api.SteamAPI_ManualDispatch_RunFrame(hSteamPipe);

            CallbackMsg_t data = default;

            while (Api.SteamAPI_ManualDispatch_GetNextCallback(hSteamPipe, ref data))
            {
                try
                {
                    OnCallback(data);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    Api.SteamAPI_ManualDispatch_FreeLastCallback(hSteamPipe);
                    data = default;
                }
            }
        }

        private static Dictionary<int, string> GetCallbacksById()
        {
            if (_callbacksById == null)
            {
                _callbacksById = new Dictionary<int, string>();

                string[] names = Enum.GetNames(typeof(Callback));
                int[] ids = (int[])Enum.GetValues(typeof(Callback));

                for (int i = 0; i < ids.Length; i++)
                {
                    _callbacksById.Add(ids[i], names[i]);
                }
            }

            return _callbacksById;
        }

        private static void OnCallback(CallbackMsg_t data)
        {
            var callbacksById = GetCallbacksById();

            UnityEngine.Debug.Log($"Got Steamworks SDK callback \"{data.iCallback}\".");
            UnityEngine.Debug.Log($"data.hSteamUser: {data.hSteamUser}");
            UnityEngine.Debug.Log($"data.pubParam: {data.pubParam}");
            UnityEngine.Debug.Log($"data.cubParam: {data.cubParam}");
            // TODO: handle callbacks
        }
    }
}
