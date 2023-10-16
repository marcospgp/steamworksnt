namespace Steamworksnt.SteamworksApi
{
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
}
