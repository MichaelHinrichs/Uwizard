using SQLite.Net.Attributes;
using UwizardWPF.Entities.Enums;

namespace UwizardWPF.Entities
{
    public class WiiUDisk
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Keyhash { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public RegionCodeEnum RegionCode { get; set; }
        public string FilePath { get; set; }
    }
}
