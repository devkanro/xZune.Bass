// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagType.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags
{
    public enum TagType
    {
        /// <summary>
        ///     ID3v1 tags. A pointer to a TAG_ID3 structure is returned.
        /// </summary>
        ID3 = Internal.TagType.ID3,

        /// <summary>
        ///     ID3v2 tags. A pointer to a variable length block is returned. ID3v2 tags are supported at both the start and end of
        ///     the file, and in designated RIFF/AIFF chunks. See www.id3.org for details of the block's structure.
        /// </summary>
        ID3V2 = Internal.TagType.ID3V2,

        /// <summary>
        ///     OGG comments. A pointer to a series of null-terminated UTF-8 strings is returned, the final string ending with a
        ///     double null.
        /// </summary>
        Ogg = Internal.TagType.Ogg,

        /// <summary>
        ///     HTTP headers, only available when streaming from a HTTP server. A pointer to a series of null-terminated strings is
        ///     returned, the final string ending with a double null.
        /// </summary>
        Http = Internal.TagType.Http,

        /// <summary>
        ///     ICY (Shoutcast) tags. A pointer to a series of null-terminated strings is returned, the final string ending with a
        ///     double null.
        /// </summary>
        Icy = Internal.TagType.Icy,

        /// <summary>
        ///     Shoutcast metadata. A single string is returned, containing the current stream title and url (usually omitted). The
        ///     format of the string is: StreamTitle='xxx';StreamUrl='xxx';
        /// </summary>
        Meta = Internal.TagType.Meta,

        /// <summary>
        ///     APE (v1 or v2) tags. A pointer to a series of null-terminated UTF-8 strings is returned, the final string ending
        ///     with a double null. Each string is in the form of "key=value", or "key=value1/value2/..." if there are multiple
        ///     values.
        /// </summary>
        Ape = Internal.TagType.Ape,

        /// <summary>
        ///     MP4/iTunes metadata. A pointer to a series of null-terminated UTF-8 strings is returned, the final string ending
        ///     with a double null.
        /// </summary>
        Mp4 = Internal.TagType.Mp4,

        /// <summary>
        ///     OGG encoder. A single UTF-8 string is returned.
        /// </summary>
        Vendor = Internal.TagType.Vendor,

        /// <summary>
        ///     Lyrics3v2 tag. A single string is returned, containing the Lyrics3v2 information. See www.id3.org/Lyrics3v2 for
        ///     details of its format.
        /// </summary>
        Lyrics3 = Internal.TagType.Lyrics3,

        /// <summary>
        ///     CoreAudio codec information. A pointer to a TAG_CA_CODEC structure is returned.
        /// </summary>
        CaCodec = Internal.TagType.CaCodec,

        /// <summary>
        ///     Media Foundation metadata. A pointer to a series of null-terminated UTF-8 strings is returned, the final string
        ///     ending with a double null.
        /// </summary>
        Mf = Internal.TagType.Mf,

        /// <summary>
        ///     WAVE "fmt " chunk contents. A pointer to a WAVEFORMATEX structure is returned. As well as WAVE files, this is also
        ///     provided by Media Foundation codecs.
        /// </summary>
        Waveformat = Internal.TagType.Waveformat,

        /// <summary>
        ///     RIFF "INFO" chunk tags. A pointer to a series of null-terminated strings is returned, the final string ending with
        ///     a double null. The tags are in the form of "XXXX=text", where "XXXX" is the chunk ID.
        /// </summary>
        RiffInfo = Internal.TagType.RiffInfo,

        /// <summary>
        ///     RIFF/BWF "bext" chunk tags. A pointer to a TAG_BEXT structure is returned.
        /// </summary>
        RiffBext = Internal.TagType.RiffBext,

        /// <summary>
        ///     RIFF/BWF "cart" chunk tags. A pointer to a TAG_CART structure is returned.
        /// </summary>
        RiffCart = Internal.TagType.RiffCart,

        /// <summary>
        ///     RIFF "DISP" chunk text (CF_TEXT) tag. A single string is returned.
        /// </summary>
        RiffDisp = Internal.TagType.RiffDisp,

        /// <summary>
        ///     APE binary tag. A pointer to a TAG_APE_BINARY structure is returned.
        /// </summary>
        ApeBinary = Internal.TagType.ApeBinary,

        /// <summary>
        ///     MOD music title.
        /// </summary>
        MusicName = Internal.TagType.MusicName,

        /// <summary>
        ///     MOD message text.
        /// </summary>
        MusicMessage = Internal.TagType.MusicMessage,

        /// <summary>
        ///     MOD music order list. A pointer to a byte array is returned, with each byte being the pattern number played at that
        ///     order position. Pattern number 254 is "+++" (skip order) and 255 is "---" (end song).
        /// </summary>
        MusicOrders = Internal.TagType.MusicOrders,

        /// </summary>
        MusicInst = Internal.TagType.MusicInst,

        /// <summary>
        ///     MOD sample name.
        /// </summary>
        MusicSample = Internal.TagType.MusicSample
    }
}