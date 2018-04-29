namespace QuanLiKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            ChiTietThues = new HashSet<ChiTietThue>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaKH { get; set; }

        [StringLength(10)]
        public string MaLoaiKhach { get; set; }

        [StringLength(50)]
        public string TenKhach { get; set; }

       
        public bool GioiTinh { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThue> ChiTietThues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual LoaiKhach LoaiKhach { get; set; }
    }
}
