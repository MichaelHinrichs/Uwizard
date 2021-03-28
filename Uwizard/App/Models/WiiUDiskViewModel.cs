using System;
using System.Linq;
using System.Windows.Forms;
using Uwizard.Entities;
using Uwizard.Entities.Helpers;
using Uwizard.Extensions;

namespace Uwizard.App.Models
{
    public class WiiUDiskViewModel : BaseViewModel
    {
        public string DisplayName => !String.IsNullOrWhiteSpace(Name) ? Name : System.IO.Path.GetFileNameWithoutExtension(FilePath);
        public string CoverFrontLocation => String.IsNullOrWhiteSpace(Id) ? "" : "covers/front/" + Id + ".jpg";
        public string CoverFullLocation => String.IsNullOrWhiteSpace(Id) ? "" : "covers/full/" + Id + ".jpg";
        public string Cover3dLocation => String.IsNullOrWhiteSpace(Id) ? "" : "covers/3d/" + Id + ".jpg";
        public string CoverDiscLocation => String.IsNullOrWhiteSpace(Id) ? "" : "covers/disc/" + Id + ".jpg";
        public string Id { get; set; }
        public string Name { get; set; }
        public string KeyHash { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public RegionCodeEnum RegionCode { get; set; }
        public string FilePath { get; set; }
        
        public WiiUDiskViewModel() { }

        public WiiUDiskViewModel(string filePath)
        {
            FilePath = filePath;
        }

        public WiiUDiskViewModel(string id, string name, string keyHash, string key, string description, RegionCodeEnum regionCode, string filePath = "")
        {
            Id = id;
            Name = name;
            KeyHash = keyHash;
            Key = key;
            Description = description;
            RegionCode = regionCode;
            FilePath = filePath;
        }

        public WiiUDiskViewModel(WiiUDisk wiiUDisk, string filePath = "")
        {
            FilePath = filePath;
            Id = wiiUDisk.Id;
            Name = wiiUDisk.Name;
            Key = wiiUDisk.Key;
            KeyHash = wiiUDisk.Keyhash;
            Description = wiiUDisk.Description;
            RegionCode = wiiUDisk.RegionCode;
        }

        public override Control View()
        {
            throw new System.NotImplementedException();
        }

        public void Update(string id, string name, string key, string keyHash, RegionCodeEnum regionCode, string description)
        {
            Id = id;
            Name = name;
            KeyHash = keyHash;
            Key = key;
            Description = description;
            RegionCode = regionCode;
        }

        public void DownloadCovers()
        {
            var enumDisplay = RegionCode.GetDisplayName();
            Helpers.DownloadCover(CoverFrontLocation, Properties.Settings.Default.GameTDBCoverFront.Cast<String>(), enumDisplay, Id);
            Helpers.DownloadCover(CoverFullLocation, Properties.Settings.Default.GameTDBCoverFull.Cast<String>(), enumDisplay, Id);
            Helpers.DownloadCover(CoverDiscLocation, Properties.Settings.Default.GameTDBCoverDisc.Cast<String>(), enumDisplay, Id);
            Helpers.DownloadCover(Cover3dLocation, Properties.Settings.Default.GameTDBCover3D.Cast<String>(), enumDisplay, Id);
        }
    }
}
