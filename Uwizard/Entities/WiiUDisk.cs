using System.Xml.Serialization;

namespace Uwizard.Entities
{
    public class WiiUDisk
    {
        public string Id;
        public string Name;
        public string Keyhash;
        public string Key;
        public string Description;
        public RegionCodeEnum RegionCode;
        public string FilePath;
        public bool isGX2;
    }
}
