using System;

namespace SharpOscar
{
    /// <summary>
    /// Contains TLV type enumerations
    /// </summary>
    internal static class TlvClass
    {
        /// <summary>
        /// TLV Class: FLAP__SIGNON_TAGS
        /// 
        /// These tags are used in the FLAP signon frame. They appear right after the 4 byte version number.
        /// </summary>
        public enum FlapSignOnTag: ushort
        {
            /// <summary>
            /// string. Yet another client name
            /// </summary>
            ClientName      = 3,

            /// <summary>
            /// blob.   Login cookie returned by startOSCARSession
            /// </summary>
            LoginCookie     = 6,

            /// <summary>
            /// u16.    Client major version: (1) if the client version is "1.2.3"
            /// </summary>
            MajorVersion    = 23,

            /// <summary>
            /// u16.    Client minor version: (2) if the client version is "1.2.3"
            /// </summary>
            MinorVersion    = 24,
        
            /// <summary>
            /// u16.    Client minor version: (3) if the client version is "1.2.3"
            /// </summary>
            PointVersion    = 25,

            /// <summary>
            /// u16.    Client build number, usually monotonically increasing
            /// </summary>
            BuildNumber     = 26,

            /// <summary>
            /// u08.	[Class:FLAP__MULTICONN_FLAGS] Should almost always be 0x1
            /// </summary>
            MultiConnFlags  = 74,

            /// <summary>
            /// u08.	Client claims it is reconnecting because it got knocked off
            /// </summary>
            ClientReconnect = 148
        }

        /// <summary>
        /// TLV Class: ERROR__TAGS
        /// 
        /// These are common tags used by error SNACs.
        /// </summary>
        public enum ErrorTag: ushort
        {
            /// <summary>
            /// string.	URL with more detail
            /// </summary>
            FailUrl         = 4,

            /// <summary>
            /// u16.    Foodgroup-specific error code
            /// </summary>
            ErrorSubcode    = 8,

            /// <summary>
            /// string. String error message text
            /// </summary>
            ErrorText       = 27,

            /// <summary>
            /// UUID.	UUID specifying format of ERROR_INFO_DATA data
            /// </summary>
            ErrorInfoClsId  = 41,

            /// <summary>
            /// blob.	Extra information describing error
            /// </summary>
            ErrorInfoData   = 42
        }

        /// <summary>
        /// TLV Class: OSERVICE__NICK_INFO_TAGS
        /// 
        /// These tags contain information about users and their server state.
        /// </summary>
        public enum OServiceNickInfoTag: ushort
        {
            /// <summary>
            /// u16.	[Class:OSERVICE__NICK_FLAGS] Flags that represent the user's state
            /// </summary>
            NickFlags       = 1,

            /// <summary>
            /// t70.	Signon time
            /// </summary>
            SignOnTod       = 3,

            /// <summary>
            /// u16.	Idle time in minutes
            /// </summary>
            IdleTime        = 4,

            /// <summary>
            /// t70.	Approximation of AIM membership
            /// </summary>
            MemberSince     = 5,

            /// <summary>
            /// u32.	Network byte order IP address
            /// </summary>
            RealIpAddress   = 10,

            /// <summary>
            /// Array of UUID.	Client capabilities - if not present use the previous values received; 
            /// if present but empty, clear previous values
            /// </summary>
            Caps            = 13,

            /// <summary>
            /// u32.	Online time in seconds
            /// </summary>
            OnlineTime      = 15,

            /// <summary>
            /// u08.	Set in first nick info. Identifies the instance number of this client
            /// </summary>
            MyInstanceNum   = 20,

            /// <summary>
            /// u08.	Set in first nick info. Identifies the instance number of this client
            /// </summary>
            ShortCaps       = 25,

            /// <summary>
            /// Array of BART__ID.	Expressions
            /// </summary>
            BartInfo        = 29,

            /// <summary>
            /// Array of u08.	[Class:OSERVICE__NICK_FLAGS] Upper bytes of nick flags, can be any size.
            /// nickFlags = NICK_FLAG | (NICK_FLAGS2 << 16)
            /// </summary>
            NickFlags2      = 31,

            /// <summary>
            /// t70.	Last Buddy Feed update time
            /// </summary>
            BuddyFeedTime   = 35,

            /// <summary>
            /// t70.	Time that the profile was set
            /// </summary>
            SigTime         = 38,

            /// <summary>
            /// t70.	Time that away was set
            /// </summary>
            AwayTime        = 39,

            /// <summary>
            /// string.	Two character country code. Sent from host to client if country is known
            /// </summary>
            GeoCountry      = 42
        }

        /// <summary>
        /// TLV Class: OSERVICE__MIGRATE_TAGS
        /// 
        /// These are the codes used in MIGRATE_GROUPS to describe where the client should recconnect.
        /// </summary>
        public enum OServiceMigrateTag: ushort
        {
            /// <summary>
            /// string.	IPaddress followed by optional colon and port, 10.0.0.1:5190
            /// </summary>
            ReconnectHere   = 5,

            /// <summary>
            /// string.	Binary opaque data
            /// </summary>
            LoginCookie     = 6,

            /// <summary>
            /// string.	Certname to use for SSL validation
            /// </summary>
            SslCertName     = 141,

            /// <summary>
            /// u08.	[Class:OSERVICE__SERVICE_RESPONSE_SSL_STATE] SSL state
            /// </summary>
            SslState        = 142
        }

        /// <summary>
        /// TLV Class: OSERVICE__SERVICE_REQUEST_TAGS
        /// 
        /// These are the tags the client uses to control what type of service request it wants.
        /// </summary>
        public enum OServiceServiceRequestTag: ushort
        {
            /// <summary>
            /// empty.	No value; if present use SSL
            /// </summary>
            UseSsl      = 140
        }

        /// <summary>
        /// TLV Class: OSERVICE__SERVICE_RESPONSE_TAGS
        /// 
        /// This class provided information about where the client should connect for the service.
        /// </summary>
        public enum OServiceServiceResponseTag: ushort
        {
            /// <summary>
            /// u16.	Foodgroup for which this response is for
            /// </summary>
            GroupId         = 13,

            /// <summary>
            /// string.	IP address followed by optional colon and port, 10.0.0.1:5190
            /// </summary>
            ReconnectHere   = 5,

            /// <summary>
            /// string.	Binary opaque data
            /// </summary>
            LoginCookie     = 6,

            /// <summary>
            /// string.	Certname to use for SSL validation
            /// </summary>
            SslCertName     = 141,

            /// <summary>
            /// u08.	[Class:OSERVICE__SERVICE_RESPONSE_SSL_STATE] SSL state
            /// </summary>
            SslState        = 142
        }

        /// <summary>
        /// TLV Class: BUDDY__RIGHTS_QUERY_TAGS
        /// 
        /// These are tags the client uses to inform the server of options for the BUDDY foodgroup.
        /// </summary>
        public enum BuddyRightsQueryTag: ushort
        {
            /// <summary>
            /// u16	[Class:BUDDY__RIGHTS_QUERY_FLAGS] Flags that govern feature support
            /// </summary>
            Flags       = 5
        }

        /// <summary>
        /// TLV Class: BUDDY__RIGHTS_REPLY_TAGS
        ///
        /// This class contains information from the server about the BUDDY foodgroup.
        /// </summary>
        public enum BuddyRightsReplyTag: ushort
        {
            /// <summary>
            /// u16.	Number of loginIds the user can have on their Buddy List
            /// </summary>
            MaxBuddies      = 1,

            /// <summary>
            /// u16.	Number of online users who can simultaneously watch this user
            /// </summary>
            MaxWatchers     = 2,

            /// <summary>
            /// u16.	Number of temporary buddies
            /// </summary>
            MaxTempBuddies  = 4
        }

        /// <summary>
        /// TLV Class: PD__RIGHTS_REPLY_TAGS
        /// 
        /// This class contains information from the server about the PD foodgroup.
        /// </summary>
        public enum PdRightsReplyTag: ushort
        {
            /// <summary>
            /// u16.	Number of permit entries a user is allowed
            /// </summary>
            MaxPermits      = 1,

            /// <summary>
            /// u16.	Number of deny entries a user is allowed
            /// </summary>
            MaxDenies       = 2,

            /// <summary>
            /// u16.	Number of temporary permit entries a client is allowed
            /// </summary>
            MaxTempPermits  = 3
        }

        /// <summary>
        /// TLV Class: LOCATE__RIGHTS_REPLY_TAGS
        /// 
        /// This class contains information from the server about the LOCATE foodgroup.
        /// </summary>
        public enum LocateRightsReplyTag: ushort
        {
            /// <summary>
            /// u16.	Maximum signature length for this user
            /// </summary>
            MaxSigLen               = 1,

            /// <summary>
            /// u16.	Number of full UUID capabilities allowed
            /// </summary>
            MaxCapabilitiesLen      = 2,

            /// <summary>
            /// u16.	Maximum number of email addresses to look up at once
            /// </summary>
            MaxFindByEmailList      = 3,

            /// <summary>
            /// u16.	Largest CERT length for end to end encryption
            /// </summary>
            MaxCertsLen             = 4,

            /// <summary>
            /// u16.	Number of short UUID capabilities allowed
            /// </summary>
            MaxShortCapabilities    = 5
        }

        /// <summary>
        /// TLV Class: LOCATE__TAGS
        /// 
        /// These are the possible tags for the SET_INFO and GET_INFO SNACs.
        /// </summary>
        public enum LocateTag: ushort
        {
            /// <summary>
            /// string.	Signature's MIME type
            /// </summary>
            SigType         = 1,

            /// <summary>
            /// string.	Signature data, also called the get info profile
            /// </summary>
            SigData         = 2,

            /// <summary>
            /// string.	Away message MIME type
            /// </summary>
            UnavailableType = 3,

            /// <summary>
            /// string.	Away message data
            /// </summary>
            UnavailableData = 4,

            /// <summary>
            /// Array of UUID.	Capabilities of the client
            /// </summary>
            Capabilities    = 5,

            /// <summary>
            /// t70.	Time the signature was set
            /// </summary>
            SigTime         = 10,

            /// <summary>
            /// t70.	Time the away message was set
            /// </summary>
            UnavailableTime = 11,

            /// <summary>
            /// u08.	If true, enable server based profiles
            /// </summary>
            SupportHostSig  = 12,

            /// <summary>
            /// string.	Host based Buddy Info MIME type
            /// </summary>
            HtmlInfoType    = 13,

            /// <summary>
            /// string.	Host based Buddy Info data that the client should display in a browser window
            /// </summary>
            HtmlInfoData    = 14
        }

        /// <summary>
        /// TLV Class: ICBM__IM_DATA_TAGS
        /// 
        /// These are the tags inside the IM_DATA TLV of an IM channel ICBM; order matters. 
        /// For the IM_CHANNEL there should be one IM_CAPABILITIES followed by one or more IM_TEXT tags.
        /// </summary>
        public enum IcbmImDataTag: ushort
        {
            /// <summary>
            /// ICBM__IM_SECTION	The actual IM text; there can be multiple of these
            /// </summary>
            ImText          = 0x0101,

            /// <summary>
            /// u08.	Old client support; should just be the value 1
            /// </summary>
            ImCapabilities  = 0x0501,

            /// <summary>
            /// u16.	Short caps
            /// </summary>
            MimeArray       = 0x0D01
        }

        /// <summary>
        /// TLV Class: ICBM__RENDEZVOUS_TAGS
        /// 
        /// These are the tags inside the DATA TLV of the RENDEZVOUS channel in ICBM.
        /// </summary>
        public enum IcbmRendezvousTag: ushort
        {
            /// <summary>
            /// u16.	ICBM channel on which the rendezvous is to occur
            /// </summary>
            Channel                 = 1,

            /// <summary>
            /// u32.	IP address proposed for the rendezvous
            /// </summary>
            IpAddr                  = 2,

            /// <summary>
            /// u32.	IP address of the proposing client
            /// </summary>
            ProposedIpAddr          = 3,

            /// <summary>
            /// u32.	IP address of the proposing client as seen by server; 
            /// NOTE - this TLV may only be added by the server
            /// </summary>
            VerifiedIpAddr          = 4,

            /// <summary>
            /// u16.	Port value of the client for rendezvous
            /// </summary>
            Port                    = 5,

            /// <summary>
            /// string.	URL for downloading software to support the service
            /// </summary>
            DownloadUrl             = 6,

            /// <summary>
            /// string.	Same as DOWNLOAD_URL, but added by server if the service is well known; 
            /// Note - this TLV may only be added by the server
            /// </summary>
            VerifiedDownloadUrl     = 8,

            /// <summary>
            /// u16.	Identifies which proposal this is in the rendezvous conversation; 
            /// the initial proposal has sequence_num 1; 
            /// NOTE - this tag is required in *all* rendezvous *proposal* payloads and may only occur in proposal payloads;
            /// each proposal applying to a given rendezvous cookie increments the sequence_num by one
            /// </summary>
            SequenceNum             = 10,

            /// <summary>
            /// [Class:ICBM__RENDEZVOUS_CANCEL_REASONS] Reason for cancelling a rendezvous; 
            /// this tag must be present in all RENDEZVOUS_CANCEL payloads.
            /// </summary>
            CancelReason            = 11,

            /// <summary>
            /// string.	Text inviting the other player to join
            /// </summary>
            Invitation              = 12,

            /// <summary>
            /// string.	Charset used by the data
            /// </summary>
            InviteMimeCharset       = 13,

            /// <summary>
            /// string.	Language used by the data
            /// </summary>
            InviteMimeLang          = 14,

            /// <summary>
            /// empty.	Requests that the server check caps for recipient
            /// </summary>
            RequestHostCheck        = 15,

            /// <summary>
            /// empty.	Requests that the Rendezvous Server be used as a transport for the data
            /// </summary>
            RequestUseArs           = 16,

            /// <summary>
            /// empty.	Requests that SSL be used for the connection
            /// </summary>
            RequestSecure           = 17,

            /// <summary>
            /// u16.	Maximum application protocol version supported
            /// </summary>
            MaxProtocolVersion      = 18,

            /// <summary>
            /// u16.	Minimum application protocol version supported
            /// </summary>
            MinProtocolVersion      = 19,

            /// <summary>
            /// u16.	Reason for a counter proposal
            /// </summary>
            CounterReason           = 20,

            /// <summary>
            /// string.	Content-type used by the data
            /// </summary>
            InviteMimeType          = 21,

            /// <summary>
            /// u32.    IP_ADDR ^ 0xFFFFFFFF
            /// </summary>
            IpAddrXor               = 22,

            /// <summary>
            /// u16.	PORT ^ 0xFFFF
            /// </summary>
            PortXor                 = 23,

            /// <summary>
            /// Array of string08.	List of "IP port" pairs to try
            /// </summary>
            AddrList                = 24,

            /// <summary>
            /// string.	Identifier for session
            /// </summary>
            SessionId               = 25,

            /// <summary>
            /// string.	Identifier of session to rollover
            /// </summary>
            RollOverId              = 26,

            /// <summary>
            /// blob.	Service specific data
            /// </summary>
            ServiceData             = 10001
        }

        /// <summary>
        /// TLV Class: ICBM__TAGS
        /// 
        /// These are the TLV tags used in TOHOST and TOCLIENT SNACs.
        /// </summary>
        public enum IcbmTag: ushort
        {
            /// <summary>
            /// Array of TLV.
            /// [Class:ICBM__IM_DATA_TAGS] Message data for the IM channel only; 
            /// unlike other TLVs the order of TLVs inside this tag does matter - it should be the CAPABILITIES 
            /// item followed by multiple IM_TEXT items
            /// </summary>
            ImData          = 2,

            /// <summary>
            /// empty.	Host will acknowledge this ICBM upon sending it to the destination client; 
            /// this does NOT mean the destination user received it
            /// </summary>
            RequestHostAck  = 3,

            /// <summary>
            /// empty.	This message is an auto response; 
            /// this tag is not allowed with either the REQUEST_HOST_ACK or STORE tags
            /// </summary>
            AutoResponce    = 4,

            /// <summary>
            /// ICBM__IM_RENDEZVOUS.	Message data for all other channels
            /// </summary>
            Data            = 5,

            /// <summary>
            /// empty.	If the user is offline then store this message for delivery the next time the user logs in 
            /// when possible; AIM and ICQ use complex privacy rules that control if an offline IM delivery is allowed 
            /// or not
            /// </summary>
            Store           = 6,

            /// <summary>
            /// empty.	Used in TO_CLIENT only, it is added by the server if the sender wants client events
            /// </summary>
            WantEvents      = 11,

            /// <summary>
            /// BART__ID.	If desired BART items can be sent with the ICBM, 
            /// the client should override the ones in NickwInfo with these
            /// </summary>
            Bart            = 13,

            /// <summary>
            /// t70.	Time when the server received the offline IM
            /// </summary>
            SendTime        = 22,

            /// <summary>
            /// string.	For WIMZI this is the friendly name of the anonymous user
            /// </summary>
            FriendlyName    = 23,

            /// <summary>
            /// empty.	This is an anonymous IM
            /// </summary>
            Anonymous       = 24
        }

        /// <summary>
        /// TLV Class: ICBM__ACK_TLV_TAGS
        /// 
        /// These are the TLV tags used in HOST_ACK SNACs. New tags may be defined for future use
        /// </summary>
        public enum IcbmAckTlvTag: ushort
        {

        }

        /// <summary>
        /// TLV Class: INVITE__TAGS
        /// 
        /// These are the tags used when inviting a user to join the AIM service.
        /// </summary>
        public enum InviteTag: ushort 
        {
            /// <summary>
            /// string.	Email address to invite
            /// </summary>
            Email               = 17,

            /// <summary>
            /// string.	Personalized message to send in an invite
            /// </summary>
            PesonalizedText     = 21
        }

        /// <summary>
        /// TLV Class: FEEDBAG__RIGHTS_QUERY_TAGS
        /// 
        /// These are the types used in the Feedbag rights query.
        /// </summary>
        public enum FeedbagRightsQueryFlag: ushort
        {
            /// <summary>
            /// u16.	[Class:FEEDBAG__RIGHTS_QUERY_FLAGS] Flags that govern feature support
            /// </summary>
            Flags           = 11
        }

        /// <summary>
        /// TLV Class: FEEDBAG__RIGHTS_REPLY_TAGS
        /// 
        /// This class provides information from the server about the Feedbag foodgroup.
        /// </summary>
        public enum FeedbagRightsReplyTag: ushort
        {
            /// <summary>
            /// u16.	Maximum size of all the attributes on a single item
            /// </summary>
            MaxItemAttrs            = 3,

            /// <summary>
            /// Array of u16	Maximum number of items per class
            /// </summary>
            MaxItemsByClass         = 4,

            /// <summary>
            /// u16.	Total number of items with classId > 1024
            /// </summary>
            MaxClientItems          = 5,

            /// <summary>
            /// u16.	Maximum length of name in Item that the database supports
            /// </summary>
            MaxItemNameLen          = 6,

            /// <summary>
            /// u16.	How many RECENT_BUDDIES are allowed
            /// </summary>
            MaxRecentBuddies        = 7,

            /// <summary>
            /// u16.	Top N interactions are buddies
            /// </summary>
            InteractionBuddies      = 8,

            /// <summary>
            /// u32.	Half life in 2^(-age/half_life) in seconds
            /// </summary>
            InteractionHalfLife     = 9,

            /// <summary>
            /// u32.	Upper limit in interaction score
            /// </summary>
            InteractionMaxScore     = 10,

            /// <summary>
            /// u16.	How many BUDDIES are allowed per group
            /// </summary>
            MaxBuddiesPerGroup      = 12,

            /// <summary>
            /// u16.	How many BOT BUDDIES are allowed
            /// </summary>
            MaxMegaBots             = 13,

            /// <summary>
            /// u16.	How many smart groups are allowed
            /// </summary>
            MaxSmartGroups          = 14
        }

        /// <summary>
        /// TLV Class: FEEDBAG__ATTRIBUTES
        /// 
        /// The following attributes as found in TLVs of Items:
        /// -- The range 0-99 is reserved. 
        /// At this point in time the server will reject any attribute value that is less than MIN_ATTR. 
        /// This is intended for later system use.
        /// -- The range 100-199 is reserved for attributes that can only be modified by the server. 
        /// Clients should not attempt to change or remove these attributes.
        /// The server will reject any attribute value that hasn't been registered in this file.
        /// -- The range 200-299 is reserved for attributes that have special meaning and ordinarily are hidden
        /// from the client by some form of abstraction. 
        /// Clients that fully understand the meaning of these attributes can modify these attributes. 
        /// The server will reject any attribute value that has not been registered in this file.
        /// -- The range 300-9999 is reserved for normal, client-modifiable attributes. 
        /// The server will reject any attribute value that has not been registered in this file.
        /// -- The range 10000-0x7fff is free for use anywhere.
        /// </summary>
        public enum FeedbagAttribute: ushort
        {
            /// <summary>
            /// empty.	Anything less than this value will be rejected by the server
            /// </summary>
            MinAttr             = 100,

            /// <summary>
            /// empty.	GROUP: this is a shared group
            /// </summary>
            Shared              = 100,

            /// <summary>
            /// empty.	BUDDY: invited to join the shared group
            /// </summary>
            Invited             = 101,

            /// <summary>
            /// empty.	BUDDY: pending authorization, a client can insert/delete this record, but not update
            /// </summary>
            Pending             = 102,

            /// <summary>
            /// t70.	Timestamp
            /// </summary>
            TimeT               = 103,

            /// <summary>
            /// empty.	BUDDY: Denied authorization
            /// </summary>
            Denied              = 104,

            /// <summary>
            /// empty.	GROUP/BUDDY: Tag to mark the group or Buddy as a recent Buddy
            /// </summary>
            RecentBuddy         = 106,

            /// <summary>
            /// empty.	GROUP/BUDDY: Tag to mark the group or Buddy as an auto BOT
            /// </summary>
            Bot                 = 107,

            /// <summary>
            /// INTERACTION_INFO.	BUDDY: Interaction data
            /// </summary>
            Interaction         = 109,

            /// <summary>
            /// empty.	GROUP/BUDDY: Tag to mark the group or Buddy as a mega BOT
            /// </summary>
            MegaBot             = 111,

            /// <summary>
            /// Array of u16.	BUDDY/GROUP Array of IDs, this represents order
            /// </summary>
            Order               = 200,

            /// <summary>
            /// u32.	[Class:FEEDBAG__BUDDY_PREFS] BUDDY_PREFS: the first 32 of the Buddy List preferences
            /// </summary>
            BuddyPrefs          = 201,

            /// <summary>
            /// u08.	[Class:FEEDBAG__PD_MODE] PD_MODE: permit/deny mode
            /// </summary>
            PdMode              = 202,

            /// <summary>
            /// u32.	[Class:OSERVICE__NICK_FLAGS] PD_MODE: permit/deny mask, usually just 0xffffffff
            /// </summary>
            PdMask              = 203,

            /// <summary>
            /// u32.	[Class:FEEDBAG__PD_FLAGS] PD_MODE: permit/deny flags
            /// </summary>
            PdFlags             = 204,

            /// <summary>
            /// blob.	CLIENT_PREFS: blob of client data; name of item should be client
            /// </summary>
            ClientPrefs         = 205,

            /// <summary>
            /// blob.	BART: opaque BART data; the item name is the string version of the BART type
            /// </summary>
            BartInfo            = 213,

            /// <summary>
            /// [Class:FEEDBAG__BUDDY_PREFS]. BUDDY_PREFS: mask indicating which of the first 32 BUDDY_PREFS have 
            /// actually been set and which are uninitialized
            /// </summary>
            BuddyPrefsValid     = 214,

            /// <summary>
            /// Array of u08.
            /// [Class:FEEDBAG__BUDDY_PREFS] BUDDY_PREFS: For all prefs after the first 32, this is a growing array
            /// </summary>
            BuddyPrefs2         = 215,

            /// <summary>
            /// Array of u08.
            /// [Class:FEEDBAG__BUDDY_PREFS] BUDDY_PREFS: bitmask indicating which of BUDDY_PREFS2 have actually been set
            /// </summary>
            BuddyPrefs2Valid    = 216,

            /// <summary>
            /// Array of BART__ID.	BART: array of complete BART items, the item name is the personality name
            /// </summary>
            BartList            = 217,

            /// <summary>
            /// string.	BUDDY: alias for Item
            /// </summary>
            Alias               = 305,

            /// <summary>
            /// empty.	GROUP: If present the group is collapsed when initially shown
            /// </summary>
            Collapsed           = 308,

            /// <summary>
            /// string.	BUDDY: string for user's Email address
            /// </summary>
            EmailAddr           = 311,

            /// <summary>
            /// string.	BUDDY: string for user's normal phone number
            /// </summary>
            PhoneNumber         = 312,

            /// <summary>
            /// string.	BUDDY: string for user's cell phone number
            /// </summary>
            CellPhoneNumber     = 313,

            /// <summary>
            /// string.	BUDDY: string for user's SMS phone number
            /// </summary>
            SmsPhoneNumber      = 314,

            /// <summary>
            /// string.	BUDDY: string for "notes" about item
            /// </summary>
            Note                = 316,

            /// <summary>
            /// u16.	[Class:FEEDBAG__BUDALERT_MASK] BUDDY: alert prefs
            /// </summary>
            AlertPrefs          = 317,

            /// <summary>
            /// u32.	VANITY_INFO: Client read only, number of IMs sent
            /// </summary>
            ImSent              = 336,

            /// <summary>
            /// u32.	VANITY_INFO: Client read only, number of seconds a user is online
            /// </summary>
            OnlineTime          = 337,

            /// <summary>
            /// u32.	VANITY_INFO: Client read only, number of times a user has the away message set
            /// </summary>
            AwayMsg             = 338,

            /// <summary>
            /// u32.	VANITY_INFO: Client read only, number of IMs received
            /// </summary>
            ImReceived          = 339,

            /// <summary>
            /// t70.	BUDDY: When did I last view this person's Buddy Feed ?
            /// </summary>
            BuddyFeedView       = 340,

            /// <summary>
            /// string.	BUDDY: string for user's work phone number
            /// </summary>
            WorkPhoneNumber     = 344,

            /// <summary>
            /// string.	BUDDY: string for user's other phone number
            /// </summary>
            OtherPhoneNumber    = 345,

            /// <summary>
            /// u08.	[Class:FEEDBAG__WEB_PD_MODE] PDINFO: When to show anonymous presence
            /// </summary>
            WebPdMode           = 351
        }
    }
}