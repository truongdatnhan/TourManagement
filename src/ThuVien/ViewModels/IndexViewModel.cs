using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Helper;

namespace ThuVien.ViewModels
{
    public class IndexViewModel
    {
        public PaginatedList<SachDTO> Sachs { get; set; }
        public SachDTO sach { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}