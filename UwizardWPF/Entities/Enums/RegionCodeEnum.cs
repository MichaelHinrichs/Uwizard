using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UwizardWPF.Entities.Enums
{
    public enum RegionCodeEnum
    {
        [Display(Name = "??")]
        [Description("Unknown")]
        Unknown = 0,
        [Description("NTSC-U")]
        [Display(Name = "US")]
        USA = 1,
        [Description("PAL")]
        [Display(Name = "EN")]
        EUR = 2,
        [Description("NTSC-J")]
        [Display(Name = "JP")]
        JPN = 3,     
    }
}
