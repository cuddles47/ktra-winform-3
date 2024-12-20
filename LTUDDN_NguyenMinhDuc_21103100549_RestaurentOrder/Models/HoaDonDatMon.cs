﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LTUDDN_NguyenMinhDuc_21103100549_RestaurentOrder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HoaDonDatMon
    {
        [Key]
        public int MaHD { get; set; }
        [Required]
        public int MaMon { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên khách hàng phải từ 5 đến 50 ký tự.")]
        public string KhachHang { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Ngày đặt phải là ngày hợp lệ.")]
        public System.DateTime NgayDat { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
        public Nullable<int> SoLuong { get; set; }
    
        public virtual MonAn MonAn { get; set; }
        public decimal TongDoanhThu { get; set; } // Ensure this property exists

    }
}
