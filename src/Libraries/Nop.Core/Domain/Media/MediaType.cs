namespace Nop.Core.Domain.Media
{
    /// <summary>
    /// Type of media stored in a picture
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// Images, JPG, PNG, GIF, etc
        /// </summary>
        Image = 0,

        /// <summary>
        /// Video, MPEG, AVI, etc
        /// </summary>
        Video = 1,

        /// <summary>
        /// SVG 
        /// </summary>
        Svg = 2,

        /// <summary>
        /// Audio, MP4
        /// </summary>
        Audio = 3
    }
}