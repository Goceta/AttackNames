using System;

namespace AttackNames.Metadata
{
    public enum MediaType
    {
        Game,
        Movie,
        Anime
    }

    public class MediaTypeHelper
    {
        public static string MediaTypeToString(MediaType mediaType)
        {
            return mediaType.ToString();
        }

        public static MediaType StringToMediaType(string mediaTypeStr)
        {
            MediaType result;
            if (Enum.TryParse(mediaTypeStr, out result))
            {
                return result;
            }
            else
            {
                return MediaType.Anime; // default. TODO?: add a void/nothing enum to be the default?
            }
        }
    }
}
