namespace QuanLiKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            PhongThues = new HashSet<PhongThue>();
        }

        [Key]
        public int MaPhong { get; set; }

        [StringLength(10)]
        public string MaLoaiPhong { get; set; }

       
        public bool TinhTrang { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongThue> PhongThues { get; set; }
    }
}
