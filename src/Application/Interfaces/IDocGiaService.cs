using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDocGiaService
    {
        IEnumerable<DocGiaDTO> GetDSDocGia(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        DocGiaDTO GetDocGia(int MaDG);
        void CreateDocGia(DocGiaDTO docGia);
        void UpdateDocGia(DocGiaDTO docGia);
        void DeleteDocGia(int MaDG);
    }
}
