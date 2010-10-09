using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpOscar
{
    /// <summary>
    /// Various classes (frame types) used across the protocol
    /// </summary>
    internal class Class
    {
        /// <summary>
        /// Class: FLAP__FRAME_TYPE
        ///
        /// There are several different frame types, with the most common being the DATA frame.
        /// </summary>
        public enum FlapFrameType: byte
        {
            /// <summary>
            /// Initialize the FLAP connection
            /// </summary>
            SignOn      = 1,

            /// <summary>
            /// Messages using the FLAP connection, usually a SNAC message
            /// </summary>
            Data        = 2,

            /// <summary>
            /// A FLAP error - rare
            /// </summary>
            Error       = 3,

            /// <summary>
            /// Close down the FLAP connection gracefully
            /// </summary>
            SignOff     = 4,

            /// <summary>
            /// Send a heartbeat to server to help keep connection open
            /// </summary>
            KeepAlive   = 5
        }

        /// <summary>
        /// Class: FLAP__MULTICONN_FLAGS
        /// 
        /// These flags control how multiple instances are handled by the servers and 
        /// if current sessions need to be bumped off when a new session signs on.
        /// </summary>
        [Flags]
        public enum FlapMulticonnFlags: byte
        {
            /// <summary>
            /// Don't use
            /// </summary>
            OldClient       = 0x00,

            /// <summary>
            /// This is a recent client that understands multiple instances
            /// </summary>
            RecentClient    = 0x01,

            /// <summary>
            /// This is a recent client that understands multiple instances but does not want them
            /// </summary>
            Single          = 0x03
        }

        /// <summary>
        /// Class: SNAC__HEADER_FLAGS
        /// 
        /// These are the flags that let the client know details about the SNAC being received.
        /// </summary>
        [Flags]
        public enum SnacHeaderFlags: ushort
        {
            /// <summary>
            /// A tlvLBlock immediately follows the SNAC header before the rest of the fields
            /// </summary>
            OptTvlPresent       = 0x8000,

            /// <summary>
            /// More replies follow this message using the same requestId; 
            /// the last reply is easily detectable because it will not have this flag set
            /// </summary>
            MoreRepliesFollow   = 0x0001
        }

        /// <summary>
        /// Class: ERROR__CODE
        /// 
        /// Generic error codes
        /// </summary>
        public enum ErrorCode: byte
        {
            /// <summary>
            /// Not a known SNAC
            /// </summary>
            InvalidSnac             = 1,

            /// <summary>
            /// Exceed the rate limit to server
            /// </summary>
            RateToHost              = 2,

            /// <summary>
            /// Exceed the rate limit to the remote user
            /// </summary>
            RateToClient            = 3,

            /// <summary>
            /// Remote user is not logged in
            /// </summary>
            NotLoggedOn             = 4,

            /// <summary>
            /// Normally available but something is wrong right now
            /// </summary>
            ServiceUnavailable      = 5,

            /// <summary>
            /// Requested a service that does not exist
            /// </summary>
            ServiceNotDefined       = 6,

            /// <summary>
            /// This SNAC is known no longer supported
            /// </summary>
            ObsoleteSnac            = 7,

            /// <summary>
            /// Unknown SNAC
            /// </summary>
            NotSupportedByHost      = 8,

            /// <summary>
            /// Remote user is on but does not support the request
            /// </summary>
            NotSupportedByClient    = 9,

            /// <summary>
            /// Message is bigger then remote client wants
            /// </summary>
            RefusedByClient         = 10,

            /// <summary>
            /// Something really messed up
            /// </summary>
            ResponcesLost           = 12,

            /// <summary>
            /// Server said user or client is not allowed to do this
            /// </summary>
            RequestDenied           = 13,

            /// <summary>
            /// SNAC is too small or is not in the right format
            /// </summary>
            BustedSnacPayload       = 14,

            /// <summary>
            /// User or client does not have the correct rights to make the request
            /// </summary>
            InsufficientRights      = 15,

            /// <summary>
            /// User is trying to interact with someone blocked by their own settings
            /// </summary>
            InLocalPermitDeny       = 16,

            /// <summary>
            /// Sender is too evil
            /// </summary>
            TooEvilSender           = 17,

            /// <summary>
            /// Receiver is too evil
            /// </summary>
            TooEvilReceiver         = 18,

            /// <summary>
            /// User is migrating or the server is down
            /// </summary>
            UserTempUnavail         = 19,

            /// <summary>
            /// Item was not found
            /// </summary>
            NoMatch                 = 20,

            /// <summary>
            /// Too many items were specified in a list
            /// </summary>
            ListOverflow            = 21,

            /// <summary>
            /// Host could not figure out which item to operate on
            /// </summary>
            RequestAmbigous         = 22,

            /// <summary>
            /// Some kind of timeout
            /// </summary>
            Timeout                 = 26,

            /// <summary>
            /// General Failure
            /// </summary>
            GeneralFailure          = 28,

            /// <summary>
            /// Restricted by parental controls
            /// </summary>
            RestrictedByPc          = 31,

            /// <summary>
            /// Remote user is restricted by parental controls
            /// </summary>
            RemoteRestrictedByPc    = 32
        }

        /// <summary>
        /// Class: OSERVICE__NICK_FLAGS
        /// 
        /// Bits specifying a user's characteristics; 
        /// For compatibility reasons the lower 2 bytes of NICK_FLAGS are sent in the NICK_FLAGS tag, 
        /// while the upper bytes are sent in the NICK_FLAGS2 tag. 
        /// To form the full nick flags the client needs to combine NICK_FLAGS and NICK_FLAGS2 
        /// shifted to the left 2 bytes. NICK_FLAGS is always a u16, which NICK_FLAGS2 can be any size. 
        /// Another way to express the math: nickFlags = NICK_FLAG | (NICK_FLAGS2 << 16)
        /// </summary>
        [Flags]
        public enum OServiceNickFlags
        {
            /// <summary>
            /// Unconfirmed account
            /// </summary>
            Unconfirmed = 0x0001,

            /// <summary>
            /// AOL user
            /// </summary>
            Aol = 0x0004,

            /// <summary>
            /// AIM user
            /// </summary>
            Aim = 0x0010,	

            /// <summary>
            /// User is away
            /// </summary>
            Unavailable = 0x0020,

            /// <summary>
            /// ICQ user; AIM bit will also be set
            /// </summary>
            Icq = 0x0040,	

            /// <summary>
            /// On a mobile device
            /// </summary>
            Wireless = 0x0080,	

            /// <summary>
            /// Using IM Forwarding
            /// </summary>
            Imf = 0x0200,	

            /// <summary>
            /// Bot user
            /// </summary>
            Bot = 0x0400,	

            /// <summary>
            /// One way wireless device
            /// </summary>
            OneWayWireless = 0x1000,	

            /// <summary>
            /// Do not display the "not on your Buddy List" knock-knock as the server took care of it or the sender is trusted
            /// </summary>
            NoKnockKnock = 0x00040000,	

            /// <summary>
            /// If no active instances forward to mobile
            /// </summary>
            ForwardMobile = 0x00080000	
        }

        /// <summary>
        /// Class: OSERVICE__RATE_CODE
        /// 
        /// These are the codes used in RATE_PARAM_CHANGE to describe the state of the rate class.
        /// </summary>
        public enum OServiceRateCode 
        {
            /// <summary>
            /// Rate parameters have changed
            /// </summary>
            Change      = 1,

            /// <summary>
            /// Rate limit warning reached; if client does not slow down LIMIT state will be hit
            /// </summary>
            Warning     = 2,

            /// <summary>
            /// Rate limit reached; if client does not slow down client will be disconnected
            /// </summary>
            Limit       = 3,

            /// <summary>
            /// Rate limit cleared; client can send SNACs normally now
            /// </summary>
            Clear       = 4,
        }

        /// <summary>
        /// Class: OSERVICE__SERVICE_RESPONSE_SSL_STATE
        /// 
        /// This describes what type of SSL connection the client and backend have.
        /// </summary>
        public enum OServiceServiceResponseSslState
        {
            /// <summary>
            /// SSL is not supported or not requested for this connection
            /// </summary>
            NotUsed     = 0,

            /// <summary>
            /// SSL is being used
            /// </summary>
            Use         = 1,

            /// <summary>
            /// SSL is being used and SSL resume is supported if desired
            /// </summary>
            Resume      = 2
        }

        /// <summary>
        /// Class: BUDDY__RIGHTS_QUERY_FLAGS
        /// 
        /// These are the flags the client uses to inform the server what kinds of features it supports.
        /// </summary>
        [Flags]
        public enum BuddyRightsQueryFlags
        {
            /// <summary>
            /// Want to receive BART items
            /// </summary>
            BartSupported           = 0x0001,

            /// <summary>
            /// Want to receive ARRIVE/DEPART for all users on a Buddy List, even those offline
            /// </summary>
            InitialDeparts          = 0x0002,

            /// <summary>
            /// Want to receive BART items for offline buddies, excluding location
            /// </summary>
            OfflineBartSupported    = 0x0004,

            /// <summary>
            /// If set and INITIAL_DEPARTS is set, use REJECT on pending buddies instead of DEPART
            /// </summary>
            RejectPendingBuddies    = 0x0008
        }

        /// <summary>
        /// Class: LOCATE__QUERY_TYPE
        /// 
        /// This class specified which fields the client wants returned when doing a USER INFO QUERY2.
        /// </summary>
        [Flags]
        public enum LocateQueryType
        {
            /// <summary>
            /// The AIM signature
            /// </summary>
            Sig             = 0x00000001,

            /// <summary>
            /// The away message
            /// </summary>
            Unavailable     = 0x00000002,

            /// <summary>
            /// CAPABILITIES UUID array; short caps will be represented in long form
            /// </summary>
            Capabilities    = 0x00000004,

            /// <summary>
            /// The CERT Blob
            /// </summary>
            Certs           = 0x00000008,

            /// <summary>
            /// Return HTML formatted Buddy Info page
            /// </summary>
            HtmlInfo        = 0x00000400
        }

        /// <summary>
        /// Class: ICBM__CHANNELS
        /// 
        /// Messages sent between users are sent on a specific channel that narrow down how they 
        /// should be processed and possible rate size parameters.
        /// </summary>
        public enum IcbmChannels
        {
            /// <summary>
            /// Normal IM channel; all clients are expected to understand this channel
            /// </summary>
            Im          = 1,

            /// <summary>
            /// For rendezvous negotiations and sending data between clients
            /// </summary>
            Rendezvous  = 2
        }

        /// <summary>
        /// Class: ICBM__PARAMETER_FLAGS
        /// 
        /// These are flags the client uses to inform the server what kinds of features it supports for the ICBM channel.
        /// </summary>
        [Flags]
        public enum IcbmParameterFlags
        {
            /// <summary>
            /// Wants ICBMs on this channel
            /// </summary>
            ChannelMsgsAllowed  = 0x00000001,

            /// <summary>
            /// Wants MISSED_CALLS on this channel
            /// </summary>
            MissedCallsEnabled  = 0x00000002,

            /// <summary>
            /// Wants CLIENT_EVENTs
            /// </summary>
            EventsAllowed       = 0x00000008,

            /// <summary>
            /// Aware of sending to SMS
            /// </summary>
            SmsSupported        = 0x00000010,

            /// <summary>
            /// Support offline IMs; client is capable of storing and retrieving
            /// </summary>
            OfflineMsgsAllowed  = 0x00000100
        }

        /// <summary>
        /// Class: ICBM__ERROR_SUBCODE
        /// 
        /// These are subcodes used with standard errors.
        /// </summary>
        public enum IcbmErrorSubcode
        {
            /// <summary>
            /// Used with NOT_LOGGED_ON
            /// </summary>
            RemoteImOff             = 1,

            /// <summary>
            /// Used with NOT_LOGGED_ON; the remote side denied because of parental controls
            /// </summary>
            RemoterestrictedByPc    = 2,

            /// <summary>
            /// User tried to send a message to an SMS user and is required to accept the legal text first
            /// </summary>
            NeedSmsLegalToSend      = 3,

            /// <summary>
            /// Client tried to send a message to an SMS user without the character counter being displayed
            /// </summary>
            SmsWithoutDisclaimer    = 4,

            /// <summary>
            /// Client tried to send a message to an SMS user but the SMS matrix said 
            /// the country code combination not permitted
            /// </summary>
            SmsCountryNotAllowed    = 5,

            /// <summary>
            /// Client tried to send to an SMS user but the server could not determine the country
            /// </summary>
            SmsUnknownCountry       = 8,

            /// <summary>
            /// An IM cannot be initiated by a BOT
            /// </summary>
            CannotInitiateIm        = 9,

            /// <summary>
            /// An IM is not allowed by a consumer BOT to a user
            /// </summary>
            ImNotAllowed            = 10,

            /// <summary>
            /// An IM is not allowed by a consumer BOT due to reaching a generic usage limit, not common
            /// </summary>
            CannotImUsageLimited    = 11,

            /// <summary>
            /// An IM is not allowed by a consumer BOT due to reaching the daily usage limit
            /// </summary>
            CannotImDUsageLimited   = 12,

            /// <summary>
            /// An IM is not allowed by consumer BOT due to reaching the monthly usage limit
            /// </summary>
            CannotImMUsageLimited   = 13,

            /// <summary>
            /// User does not accept offline IMs
            /// </summary>
            OfflineImNotAccepted    = 14,

            /// <summary>
            /// Exceeded max storage limit
            /// </summary>
            OfflineImExceededMax    = 15
        }

        /// <summary>
        /// Class: ICBM__IM_SECTION_ENCODINGS
        /// 
        /// An IM can be encoded in the following different forms:
        /// </summary>
        public enum IcbmImSectionEncodings
        {
            /// <summary>
            /// ANSI ASCII -- ISO 646
            /// </summary>
            Ascii       = 0,

            /// <summary>
            /// ISO 10646.USC-2 Unicode
            /// </summary>
            Unicode     = 2,

            /// <summary>
            /// ISO 8859-1
            /// </summary>
            Latin1      = 3
        }


        /// <summary>
        /// Class: ICBM__RENDEZVOUS_MESSAGE
        /// 
        /// This is a type of rendezvous/data message.
        /// </summary>
        public enum IcbmRendezvousMessage
        {
            /// <summary>
            /// Propose a rendezvous
            /// </summary>
            Propose     = 0,

            /// <summary>
            /// Cancel a proposal you generated
            /// </summary>
            Cancel      = 1,

            /// <summary>
            /// Accept a proposal someone else generated
            /// </summary>
            Accept      = 2
        }

        /// <summary>
        /// Class: ICBM__RENDEZVOUS_CANCEL_REASONS
        /// 
        /// These are the reasons a proposal is cancelled.
        /// </summary>
        public enum RendervousCancelReason
        {
            /// <summary>
            /// Reason not specified
            /// </summary>
            Unknown             = 0,

            /// <summary>
            /// Recipient user declined
            /// </summary>
            UserCancel          = 1,

            /// <summary>
            /// Timeout
            /// </summary>
            Timeout             = 2,

            /// <summary>
            /// Proposal was accepted by a different instance of the user
            /// </summary>
            AcceptedElsewhere   = 3
        }

        /// <summary>
        /// Class: ICBM__EVIL_REQUEST_FLAGS
        /// 
        /// These are the flags that control how EVIL should work.
        /// </summary>
        [Flags]
        public enum IcbmEvilRequestFlags
        {
            /// <summary>
            /// Do not reveal my loginId to the evilee.
            /// </summary>
            Anonymous = 0x0001
        }

        /// <summary>
        /// Class: ICBM__MISSED_CALL_REASONS
        /// 
        /// These are the reasons sent to a receiver why they could not receive an IM from a sender.
        /// </summary>
        [Flags]
        public enum IcbmMissedCallReasons
        {
            /// <summary>
            /// Sender's message was too large
            /// </summary>
            TooLarge = 0x0001,

            /// <summary>
            /// Sender exceeded the receiver's rate limit
            /// </summary>
            RateExceeded = 0x0002,

            /// <summary>
            /// Message rejected because sender is EVIL
            /// </summary>
            EvilSender = 0x0004,

            /// <summary>
            /// Message rejected because receiver is EVIL
            /// </summary>
            EvilReceiver = 0x0008
        }

        /// <summary>
        /// Class: ICBM__RENDEZVOUS_NAK
        /// 
        /// Sent in ICBM__CLIENT_ERR errorInfo field
        /// </summary>
        public enum IcbmRenderzvousNak
        {
            /// <summary>
            /// Proposal UUID not supported
            /// </summary>
            ProposalUnsupported         = 0,

            /// <summary>
            /// Not authorized, or user declined
            /// </summary>
            ProposalDenied              = 1,

            /// <summary>
            /// DO NOT USE; 'ignores' should no-op
            /// </summary>
            ProposalIgnored             = 2,

            /// <summary>
            /// Proposal malformed
            /// </summary>
            BustedParameters            = 3,

            /// <summary>
            /// Attempt to act on proposal (e.g. connect) timed out
            /// </summary>
            ProposalTimedOut            = 4,

            /// <summary>
            /// Recipient away or busy
            /// </summary>
            OnlineButNotAvailable       = 5,

            /// <summary>
            /// Recipient had internal error
            /// </summary>
            InsufficientResources       = 6,

            /// <summary>
            /// Recipient was ratelimited
            /// </summary>
            RateLimited                 = 7,

            /// <summary>
            /// Recipient had nothing to send
            /// </summary>
            NoData                      = 8,

            /// <summary>
            /// Incompatible versions
            /// </summary>
            VersionMismatch             = 9,

            /// <summary>
            /// Incompatible security settings
            /// </summary>
            SecurityMismatch            = 10,

            /// <summary>
            /// Service-specific reject defined by client
            /// </summary>
            ServiceSpecificReason       = 15
        }

        /// <summary>
        /// Class: ICBM__CLIENT_ERRORS
        ///
        /// The following are Inter-Client error codes.
        /// </summary>
        public enum IcbmClientErrors
        {
            /// <summary>
            /// Receiving client does not understand the channel
            /// </summary>
            UnsupportedChannel          = 1,

            /// <summary>
            /// Receiving client thinks the payload is busted
            /// </summary>
            BustedIcbmPayload           = 2,

            /// <summary>
            /// See ICBM__RENDEZVOUS_NAK which will be inside the errorInfo 
            /// for values for ICBM__CHANNEL_RENDEZVOUS
            /// </summary>
            ChannelSpecificError        = 3
        }
    }
}
