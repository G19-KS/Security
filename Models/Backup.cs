using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiKS.Models
{
    [Table("Backup_LK")]
    public class Backup
    {
        [Key]
        [StringLength(10)]
        public string MaLoaiKhach { get; set; }

        [StringLength(10)]
        public string TenLoaiKhach { get; set; }
    }
}