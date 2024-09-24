using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeStorage
    {
        [Display(Name = "Disco duro")]
        HDD,
        [Display(Name = "SSD SATA")]
        SataSSD,
        [Display(Name = "M.2 SATA (SSD)")]
        M2Sata,
        [Display(Name = "M.2 PCIe (NVMe) (SSD)")]
        NVMe,
        [Display(Name = "eMMC")]
        eMMC
    }
}
