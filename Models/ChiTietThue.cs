namespace QuanLiKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThue")]
    public partial class ChiTietThue
    {
        [Key]
        public int STT { get; set; }

        public int? MaThue { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        public int? MaKH { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual PhongThue PhongThue { get; set; }
    }
}
