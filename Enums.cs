using System;

// Enums are exposed on the root namespace as they are likely to be consumed
// externally, such as being passed in as parameters.
namespace Steamworksnt
{
    /// <summary>
    /// Callback enums taken from "steam_api.json".
    /// </summary>
    public enum Callback : Int32
    {
        SteamServersConnected_t = 101,
        SteamServerConnectFailure_t = 102,
        SteamServersDisconnected_t = 103,
        ClientGameServerDeny_t = 113,
        IPCFailure_t = 117,
        LicensesUpdated_t = 125,
        ValidateAuthTicketResponse_t = 143,
        MicroTxnAuthorizationResponse_t = 152,
        EncryptedAppTicketResponse_t = 154,
        GetAuthSessionTicketResponse_t = 163,
        GameWebCallback_t = 164,
        StoreAuthURLResponse_t = 165,
        MarketEligibilityResponse_t = 166,
        DurationControl_t = 167,
        GetTicketForWebApiResponse_t = 168,
        PersonaStateChange_t = 304,
        GameOverlayActivated_t = 331,
        GameServerChangeRequested_t = 332,
        GameLobbyJoinRequested_t = 333,
        AvatarImageLoaded_t = 334,
        ClanOfficerListResponse_t = 335,
        FriendRichPresenceUpdate_t = 336,
        GameRichPresenceJoinRequested_t = 337,
        GameConnectedClanChatMsg_t = 338,
        GameConnectedChatJoin_t = 339,
        GameConnectedChatLeave_t = 340,
        DownloadClanActivityCountsResult_t = 341,
        JoinClanChatRoomCompletionResult_t = 342,
        GameConnectedFriendChatMsg_t = 343,
        FriendsGetFollowerCount_t = 344,
        FriendsIsFollowing_t = 345,
        FriendsEnumerateFollowingList_t = 346,
        SetPersonaNameResponse_t = 347,
        UnreadChatMessagesChanged_t = 348,
        OverlayBrowserProtocolNavigation_t = 349,
        EquippedProfileItemsChanged_t = 350,
        EquippedProfileItems_t = 351,
        IPCountry_t = 701,
        LowBatteryPower_t = 702,
        SteamAPICallCompleted_t = 703,
        SteamShutdown_t = 704,
        CheckFileSignature_t = 705,
        GamepadTextInputDismissed_t = 714,
        AppResumingFromSuspend_t = 736,
        FloatingGamepadTextInputDismissed_t = 738,
        FilterTextDictionaryChanged_t = 739,
        FavoritesListChanged_t = 502,
        LobbyInvite_t = 503,
        LobbyEnter_t = 504,
        LobbyDataUpdate_t = 505,
        LobbyChatUpdate_t = 506,
        LobbyChatMsg_t = 507,
        LobbyGameCreated_t = 509,
        LobbyMatchList_t = 510,
        LobbyKicked_t = 512,
        LobbyCreated_t = 513,
        PSNGameBootInviteResult_t = 515,
        FavoritesListAccountsUpdated_t = 516,
        SearchForGameProgressCallback_t = 5201,
        SearchForGameResultCallback_t = 5202,
        RequestPlayersForGameProgressCallback_t = 5211,
        RequestPlayersForGameResultCallback_t = 5212,
        RequestPlayersForGameFinalResultCallback_t = 5213,
        SubmitPlayerResultResultCallback_t = 5214,
        EndGameResultCallback_t = 5215,
        JoinPartyCallback_t = 5301,
        CreateBeaconCallback_t = 5302,
        ReservationNotificationCallback_t = 5303,
        ChangeNumOpenSlotsCallback_t = 5304,
        AvailableBeaconLocationsUpdated_t = 5305,
        ActiveBeaconsUpdated_t = 5306,
        RemoteStorageFileShareResult_t = 1307,
        RemoteStoragePublishFileResult_t = 1309,
        RemoteStorageDeletePublishedFileResult_t = 1311,
        RemoteStorageEnumerateUserPublishedFilesResult_t = 1312,
        RemoteStorageSubscribePublishedFileResult_t = 1313,
        RemoteStorageEnumerateUserSubscribedFilesResult_t = 1314,
        RemoteStorageUnsubscribePublishedFileResult_t = 1315,
        RemoteStorageUpdatePublishedFileResult_t = 1316,
        RemoteStorageDownloadUGCResult_t = 1317,
        RemoteStorageGetPublishedFileDetailsResult_t = 1318,
        RemoteStorageEnumerateWorkshopFilesResult_t = 1319,
        RemoteStorageGetPublishedItemVoteDetailsResult_t = 1320,
        RemoteStoragePublishedFileSubscribed_t = 1321,
        RemoteStoragePublishedFileUnsubscribed_t = 1322,
        RemoteStoragePublishedFileDeleted_t = 1323,
        RemoteStorageUpdateUserPublishedItemVoteResult_t = 1324,
        RemoteStorageUserVoteDetails_t = 1325,
        RemoteStorageEnumerateUserSharedWorkshopFilesResult_t = 1326,
        RemoteStorageSetUserPublishedFileActionResult_t = 1327,
        RemoteStorageEnumeratePublishedFilesByUserActionResult_t = 1328,
        RemoteStoragePublishFileProgress_t = 1329,
        RemoteStoragePublishedFileUpdated_t = 1330,
        RemoteStorageFileWriteAsyncComplete_t = 1331,
        RemoteStorageFileReadAsyncComplete_t = 1332,
        RemoteStorageLocalFileChange_t = 1333,
        UserStatsReceived_t = 1101,
        UserStatsStored_t = 1102,
        UserAchievementStored_t = 1103,
        LeaderboardFindResult_t = 1104,
        LeaderboardScoresDownloaded_t = 1105,
        LeaderboardScoreUploaded_t = 1106,
        NumberOfCurrentPlayers_t = 1107,
        UserStatsUnloaded_t = 1108,
        UserAchievementIconFetched_t = 1109,
        GlobalAchievementPercentagesReady_t = 1110,
        LeaderboardUGCSet_t = 1111,

        // Same as "GlobalStatsReceived_t".
        // PS3TrophiesInstalled_t = 1112,
        GlobalStatsReceived_t = 1112,
        DlcInstalled_t = 1005,
        NewUrlLaunchParameters_t = 1014,
        AppProofOfPurchaseKeyResponse_t = 1021,
        FileDetailsResult_t = 1023,
        TimedTrialStatus_t = 1030,
        P2PSessionRequest_t = 1202,
        P2PSessionConnectFail_t = 1203,
        SocketStatusCallback_t = 1201,
        ScreenshotReady_t = 2301,
        ScreenshotRequested_t = 2302,
        PlaybackStatusHasChanged_t = 4001,
        VolumeHasChanged_t = 4002,
        MusicPlayerRemoteWillActivate_t = 4101,
        MusicPlayerRemoteWillDeactivate_t = 4102,
        MusicPlayerRemoteToFront_t = 4103,
        MusicPlayerWillQuit_t = 4104,
        MusicPlayerWantsPlay_t = 4105,
        MusicPlayerWantsPause_t = 4106,
        MusicPlayerWantsPlayPrevious_t = 4107,
        MusicPlayerWantsPlayNext_t = 4108,
        MusicPlayerWantsShuffled_t = 4109,
        MusicPlayerWantsLooped_t = 4110,
        MusicPlayerWantsVolume_t = 4011,
        MusicPlayerSelectsQueueEntry_t = 4012,
        MusicPlayerSelectsPlaylistEntry_t = 4013,
        MusicPlayerWantsPlayingRepeatStatus_t = 4114,
        HTTPRequestCompleted_t = 2101,
        HTTPRequestHeadersReceived_t = 2102,
        HTTPRequestDataReceived_t = 2103,
        SteamInputDeviceConnected_t = 2801,
        SteamInputDeviceDisconnected_t = 2802,
        SteamInputConfigurationLoaded_t = 2803,
        SteamInputGamepadSlotChange_t = 2804,
        SteamUGCQueryCompleted_t = 3401,
        SteamUGCRequestUGCDetailsResult_t = 3402,
        CreateItemResult_t = 3403,
        SubmitItemUpdateResult_t = 3404,
        ItemInstalled_t = 3405,
        DownloadItemResult_t = 3406,
        UserFavoriteItemsListChanged_t = 3407,
        SetUserItemVoteResult_t = 3408,
        GetUserItemVoteResult_t = 3409,
        StartPlaytimeTrackingResult_t = 3410,
        StopPlaytimeTrackingResult_t = 3411,
        AddUGCDependencyResult_t = 3412,
        RemoveUGCDependencyResult_t = 3413,
        AddAppDependencyResult_t = 3414,
        RemoveAppDependencyResult_t = 3415,
        GetAppDependenciesResult_t = 3416,
        DeleteItemResult_t = 3417,
        UserSubscribedItemsListChanged_t = 3418,
        WorkshopEULAStatus_t = 3420,
        SteamAppInstalled_t = 3901,
        SteamAppUninstalled_t = 3902,
        HTML_BrowserReady_t = 4501,
        HTML_NeedsPaint_t = 4502,
        HTML_StartRequest_t = 4503,
        HTML_CloseBrowser_t = 4504,
        HTML_URLChanged_t = 4505,
        HTML_FinishedRequest_t = 4506,
        HTML_OpenLinkInNewTab_t = 4507,
        HTML_ChangedTitle_t = 4508,
        HTML_SearchResults_t = 4509,
        HTML_CanGoBackAndForward_t = 4510,
        HTML_HorizontalScroll_t = 4511,
        HTML_VerticalScroll_t = 4512,
        HTML_LinkAtPosition_t = 4513,
        HTML_JSAlert_t = 4514,
        HTML_JSConfirm_t = 4515,
        HTML_FileOpenDialog_t = 4516,
        HTML_NewWindow_t = 4521,
        HTML_SetCursor_t = 4522,
        HTML_StatusText_t = 4523,
        HTML_ShowToolTip_t = 4524,
        HTML_UpdateToolTip_t = 4525,
        HTML_HideToolTip_t = 4526,
        HTML_BrowserRestarted_t = 4527,
        SteamInventoryResultReady_t = 4700,
        SteamInventoryFullUpdate_t = 4701,
        SteamInventoryDefinitionUpdate_t = 4702,
        SteamInventoryEligiblePromoItemDefIDs_t = 4703,
        SteamInventoryStartPurchaseResult_t = 4704,
        SteamInventoryRequestPricesResult_t = 4705,
        GetVideoURLResult_t = 4611,
        GetOPFSettingsResult_t = 4624,
        SteamParentalSettingsChanged_t = 5001,
        SteamRemotePlaySessionConnected_t = 5701,
        SteamRemotePlaySessionDisconnected_t = 5702,
        SteamRemotePlayTogetherGuestInvite_t = 5703,
        SteamNetworkingMessagesSessionRequest_t = 1251,
        SteamNetworkingMessagesSessionFailed_t = 1252,
        SteamNetConnectionStatusChangedCallback_t = 1221,
        SteamNetAuthenticationStatus_t = 1222,
        SteamRelayNetworkStatus_t = 1281,
        GSClientApprove_t = 201,
        GSClientDeny_t = 202,
        GSClientKick_t = 203,
        GSClientAchievementStatus_t = 206,
        GSPolicyResponse_t = 115,
        GSGameplayStats_t = 207,
        GSClientGroupStatus_t = 208,
        GSReputation_t = 209,
        AssociateWithClanResult_t = 210,
        ComputeNewPlayerCompatibilityResult_t = 211,
        GSStatsReceived_t = 1800,
        GSStatsStored_t = 1801,

        // Same as "UserStatsUnloaded_t".
        // GSStatsUnloaded_t = 1108,
        SteamNetworkingFakeIPResult_t = 1223,
    }

    /// <summary>
    /// Friend flags.
    /// Note that to represent regular friends one should use
    /// "k_EFriendFlagImmediate".
    /// https://partner.steamgames.com/doc/api/ISteamFriends#EFriendFlags
    /// </summary>
    public enum EFriendFlags : Int32
    {
        k_EFriendFlagNone = 0x00,
        k_EFriendFlagBlocked = 0x01,
        k_EFriendFlagFriendshipRequested = 0x02,
        k_EFriendFlagImmediate = 0x04, // "regular" friend
        k_EFriendFlagClanMember = 0x08,
        k_EFriendFlagOnGameServer = 0x10,

        // k_EFriendFlagHasPlayedWith	= 0x20,	// not currently used
        // k_EFriendFlagFriendOfFriend	= 0x40, // not currently used
        k_EFriendFlagRequestingFriendship = 0x80,
        k_EFriendFlagRequestingInfo = 0x100,
        k_EFriendFlagIgnored = 0x200,
        k_EFriendFlagIgnoredFriend = 0x400,

        // k_EFriendFlagSuggested		= 0x800,	// not used
        k_EFriendFlagChatMember = 0x1000,
        k_EFriendFlagAll = 0xFFFF,
    };

    /// <summary>
    /// List of states a Steam friend can be in.
    /// https://partner.steamgames.com/doc/api/ISteamFriends#EPersonaState
    /// </summary>
    public enum EPersonaState : Int32
    {
        k_EPersonaStateOffline = 0, // friend is not currently logged on
        k_EPersonaStateOnline = 1, // friend is logged on
        k_EPersonaStateBusy = 2, // user is on, but busy
        k_EPersonaStateAway = 3, // auto-away feature
        k_EPersonaStateSnooze = 4, // auto-away for a long time
        k_EPersonaStateLookingToTrade = 5, // Online, trading
        k_EPersonaStateLookingToPlay = 6, // Online, wanting to play
        k_EPersonaStateInvisible = 7, // Online, but appears offline to friends.  This status is never published to clients.
        k_EPersonaStateMax,
    };

    public enum EResult
    {
        k_EResultNone = 0,
        k_EResultOK = 1,
        k_EResultFail = 2,
        k_EResultNoConnection = 3,
        k_EResultInvalidPassword = 5,
        k_EResultLoggedInElsewhere = 6,
        k_EResultInvalidProtocolVer = 7,
        k_EResultInvalidParam = 8,
        k_EResultFileNotFound = 9,
        k_EResultBusy = 10,
        k_EResultInvalidState = 11,
        k_EResultInvalidName = 12,
        k_EResultInvalidEmail = 13,
        k_EResultDuplicateName = 14,
        k_EResultAccessDenied = 15,
        k_EResultTimeout = 16,
        k_EResultBanned = 17,
        k_EResultAccountNotFound = 18,
        k_EResultInvalidSteamID = 19,
        k_EResultServiceUnavailable = 20,
        k_EResultNotLoggedOn = 21,
        k_EResultPending = 22,
        k_EResultEncryptionFailure = 23,
        k_EResultInsufficientPrivilege = 24,
        k_EResultLimitExceeded = 25,
        k_EResultRevoked = 26,
        k_EResultExpired = 27,
        k_EResultAlreadyRedeemed = 28,
        k_EResultDuplicateRequest = 29,
        k_EResultAlreadyOwned = 30,
        k_EResultIPNotFound = 31,
        k_EResultPersistFailed = 32,
        k_EResultLockingFailed = 33,
        k_EResultLogonSessionReplaced = 34,
        k_EResultConnectFailed = 35,
        k_EResultHandshakeFailed = 36,
        k_EResultIOFailure = 37,
        k_EResultRemoteDisconnect = 38,
        k_EResultShoppingCartNotFound = 39,
        k_EResultBlocked = 40,
        k_EResultIgnored = 41,
        k_EResultNoMatch = 42,
        k_EResultAccountDisabled = 43,
        k_EResultServiceReadOnly = 44,
        k_EResultAccountNotFeatured = 45,
        k_EResultAdministratorOK = 46,
        k_EResultContentVersion = 47,
        k_EResultTryAnotherCM = 48,
        k_EResultPasswordRequiredToKickSession = 49,
        k_EResultAlreadyLoggedInElsewhere = 50,
        k_EResultSuspended = 51,
        k_EResultCancelled = 52,
        k_EResultDataCorruption = 53,
        k_EResultDiskFull = 54,
        k_EResultRemoteCallFailed = 55,
        k_EResultPasswordUnset = 56,
        k_EResultExternalAccountUnlinked = 57,
        k_EResultPSNTicketInvalid = 58,
        k_EResultExternalAccountAlreadyLinked = 59,
        k_EResultRemoteFileConflict = 60,
        k_EResultIllegalPassword = 61,
        k_EResultSameAsPreviousValue = 62,
        k_EResultAccountLogonDenied = 63,
        k_EResultCannotUseOldPassword = 64,
        k_EResultInvalidLoginAuthCode = 65,
        k_EResultAccountLogonDeniedNoMail = 66,
        k_EResultHardwareNotCapableOfIPT = 67,
        k_EResultIPTInitError = 68,
        k_EResultParentalControlRestricted = 69,
        k_EResultFacebookQueryError = 70,
        k_EResultExpiredLoginAuthCode = 71,
        k_EResultIPLoginRestrictionFailed = 72,
        k_EResultAccountLockedDown = 73,
        k_EResultAccountLogonDeniedVerifiedEmailRequired = 74,
        k_EResultNoMatchingURL = 75,
        k_EResultBadResponse = 76,
        k_EResultRequirePasswordReEntry = 77,
        k_EResultValueOutOfRange = 78,
        k_EResultUnexpectedError = 79,
        k_EResultDisabled = 80,
        k_EResultInvalidCEGSubmission = 81,
        k_EResultRestrictedDevice = 82,
        k_EResultRegionLocked = 83,
        k_EResultRateLimitExceeded = 84,
        k_EResultAccountLoginDeniedNeedTwoFactor = 85,
        k_EResultItemDeleted = 86,
        k_EResultAccountLoginDeniedThrottle = 87,
        k_EResultTwoFactorCodeMismatch = 88,
        k_EResultTwoFactorActivationCodeMismatch = 89,
        k_EResultAccountAssociatedToMultiplePartners = 90,
        k_EResultNotModified = 91,
        k_EResultNoMobileDevice = 92,
        k_EResultTimeNotSynced = 93,
        k_EResultSmsCodeFailed = 94,
        k_EResultAccountLimitExceeded = 95,
        k_EResultAccountActivityLimitExceeded = 96,
        k_EResultPhoneActivityLimitExceeded = 97,
        k_EResultRefundToWallet = 98,
        k_EResultEmailSendFailure = 99,
        k_EResultNotSettled = 100,
        k_EResultNeedCaptcha = 101,
        k_EResultGSLTDenied = 102,
        k_EResultGSOwnerDenied = 103,
        k_EResultInvalidItemType = 104,
        k_EResultIPBanned = 105,
        k_EResultGSLTExpired = 106,
        k_EResultInsufficientFunds = 107,
        k_EResultTooManyPending = 108,
        k_EResultNoSiteLicensesFound = 109,
        k_EResultWGNetworkSendExceeded = 110,
        k_EResultAccountNotFriends = 111,
        k_EResultLimitedUserAccount = 112,
        k_EResultCantRemoveItem = 113,
        k_EResultAccountDeleted = 114,
        k_EResultExistingUserCancelledLicense = 115,
        k_EResultCommunityCooldown = 116,
        k_EResultNoLauncherSpecified = 117,
        k_EResultMustAgreeToSSA = 118,
        k_EResultLauncherMigrated = 119,
        k_EResultSteamRealmMismatch = 120,
        k_EResultInvalidSignature = 121,
        k_EResultParseFailure = 122,
        k_EResultNoVerifiedPhone = 123,
        k_EResultInsufficientBattery = 124,
        k_EResultChargerRequired = 125,
        k_EResultCachedCredentialInvalid = 126,
        K_EResultPhoneNumberIsVOIP = 127
    }

    public enum ESteamNetworkingAvailability
    {
        // Negative values indicate a problem.
        //
        // In general, we will not automatically retry unless you take some action that
        // depends on of requests this resource, such as querying the status, attempting
        // to initiate a connection, receive a connection, etc.  If you do not take any
        // action at all, we do not automatically retry in the background.
        k_ESteamNetworkingAvailability_CannotTry = -102, // A dependent resource is missing, so this service is unavailable.  (E.g. we cannot talk to routers because Internet is down or we don't have the network config.)
        k_ESteamNetworkingAvailability_Failed = -101, // We have tried for enough time that we would expect to have been successful by now.  We have never been successful
        k_ESteamNetworkingAvailability_Previously = -100, // We tried and were successful at one time, but now it looks like we have a problem

        k_ESteamNetworkingAvailability_Retrying = -10, // We previously failed and are currently retrying

        // Not a problem, but not ready either
        k_ESteamNetworkingAvailability_NeverTried = 1, // We don't know because we haven't ever checked/tried
        k_ESteamNetworkingAvailability_Waiting = 2, // We're waiting on a dependent resource to be acquired.  (E.g. we cannot obtain a cert until we are logged into Steam.  We cannot measure latency to relays until we have the network config.)
        k_ESteamNetworkingAvailability_Attempting = 3, // We're actively trying now, but are not yet successful.

        k_ESteamNetworkingAvailability_Current = 100, // Resource is online/available

        k_ESteamNetworkingAvailability_Unknown = 0, // Internal dummy/sentinel, or value is not applicable in this context
        k_ESteamNetworkingAvailability__Force32bit = 0x7fffffff,
    };

    // lobby type description
    public enum ELobbyType : Int32
    {
        k_ELobbyTypePrivate = 0, // only way to join the lobby is to invite to someone else
        k_ELobbyTypeFriendsOnly = 1, // shows for friends or invitees, but not in lobby list
        k_ELobbyTypePublic = 2, // visible for friends and in lobby list

        // returned by search, but not visible to other friends
        // useful if you want a user in two lobbies, for example matching groups together
        // a user can be in only one regular lobby, and up to two invisible lobbies
        k_ELobbyTypeInvisible = 3,

        // private, unique and does not delete when empty - only one of these may exist per unique keypair set
        // can only create from webapi
        k_ELobbyTypePrivateUnique = 4,
    };
}
