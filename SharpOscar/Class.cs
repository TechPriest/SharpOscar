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
    }
}
