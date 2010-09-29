using System;


namespace SharpOscar
{
    /// <summary>
    /// AIM uses UUIDs in several places to express what kind of capabilities a client has 
    /// and what features it would like the server to support. 
    /// The nice thing about UUIDs is there does not have to be a central registry since 
    /// they are unique when created. There are many websites and tools out there that will 
    /// create a UUID. UUIDs are also sometimes known as GUIDs.
    /// UUIDs are transmitted as 16 bytes of binary data; however in documents they are written 
    /// down in string form like 09460000-4C7F-11D1-8222-444553540000.
    /// At some point it was decided that full UUIDs were too verbose for common capabilities, 
    /// so AIM uses both full UUIDs and what are called "short UUIDs" or "Short Caps". 
    /// A "Short Cap" is really a UUID of the form 0946XXYY-4C7F-11D1-8222-444553540000 
    /// where XXYY is the short cap. A client receives short caps if it asserts the short cap capability. 
    /// If a client does not assert the short caps UUID, it will get most caps in long form. 
    /// Some APIs only take UUIDs In those cases the long form of a short cap should be sent.
    /// </summary>
    internal static class Caps
    {
        /// <summary>
        /// Client support short caps
        /// </summary>
        public static readonly Guid ShortCaps = new Guid("09460000-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client supports SECURE_IM
        /// </summary>
        public static readonly Guid SecureIm = new Guid("09460001-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client supports XHTML profile and ims instead of AOLRTF
        /// </summary>
        public static readonly Guid XhtmlIm = new Guid("09460002-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client supports SIP/RTP video
        /// </summary>
        public static readonly Guid RtcVideo = new Guid("09460101-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client has a camera
        /// </summary>
        public static readonly Guid HasCamera = new Guid("09460102-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client has a microphone
        /// </summary>
        public static readonly Guid HasMicrophone = new Guid("09460103-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client supports RTCAUDIO
        /// </summary>
        public static readonly Guid RtcAudio = new Guid("09460104-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client supports new status message features
        /// </summary>
        public static readonly Guid HostStatusTextAware = new Guid("0946010A-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client support "see as I type" IMs
        /// </summary>
        public static readonly Guid RtIm = new Guid("0946010B-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client only asserts caps for services it is participating in
        /// </summary>
        public static readonly Guid SmartCaps = new Guid("094601FF-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// File transfer
        /// </summary>
        public static readonly Guid FileTransfer = new Guid("09461343-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// P2p ims
        /// </summary>
        public static readonly Guid DirectIcbm = new Guid("09461345-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// File sharing
        /// </summary>
        public static readonly Guid FileSharing = new Guid("09461348-4C7F-11D1-8222-444553540000");

        /// <summary>
        /// Client supports talking to ICQ users
        /// </summary>
        public static readonly Guid SupportIcq = new Guid("0946134D-4C7F-11D1-8222-444553540000");
    }

    /// <summary>
    /// Short Caps
    /// </summary>
    internal enum ShortCaps: ushort
    {
        /// <summary>
        /// Client supports SECURE_IM
        /// </summary>
        SecureIm                = 0x0001,

        /// <summary>
        /// Client supports XHTML profile and ims instead of AOLRTF
        /// </summary>
        XhtmlIm                 = 0x0002,

        /// <summary>
        /// Client supports SIP/RTP video
        /// </summary>
        RtcVideo                = 0x0101,

        /// <summary>
        /// Client has a camera
        /// </summary>
        HasCamera               = 0x0102,

        /// <summary>
        /// Client has a microphone
        /// </summary>
        HasMicrophone           = 0x0103,

        /// <summary>
        /// Client supports RTCAUDIO
        /// </summary>
        RtcAudio                = 0x0104,

        /// <summary>
        /// Client supports new status message features
        /// </summary>
        HostStatusTextAware     = 0x010A,

        /// <summary>
        /// Client support "see as I type" IMs
        /// </summary>
        RtIm                    = 0x010B,

        /// <summary>
        /// Client only asserts caps for services it is participating in
        /// </summary>
        SmartCaps               = 0x01FF,
        
        /// <summary>
        /// File transfer
        /// </summary>
        FileTransfer            = 0x1343,

        /// <summary>
        /// P2p ims
        /// </summary>
        DirectIcbm              = 0x1345,

        /// <summary>
        /// File sharing
        /// </summary>
        FileSharing             = 0x1348,

        /// <summary>
        /// Client supports talking to ICQ users
        /// </summary>
        SupportIcq              = 0x134D
    }
}
