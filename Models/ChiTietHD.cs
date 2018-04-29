namespace QuanLiKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHD")]
    public partial class ChiTietHD
    {
        [Key]
        public int IDCTHD { get; set; }

        public int SoHD { get; set; }

        public int MaThue { get; set; }

        public int? SoNgayO { get; set; }

        public int? Tien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual PhongThue PhongThue { get; set; }

        public int SoNgay(DateTime ngayden,DateTime ngaydi)
        {
            return (ngaydi - ngayden).Days;
        }
        
    
    }
}
