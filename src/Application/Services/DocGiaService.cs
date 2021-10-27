using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class DocGiaService : IDocGiaService
    {
        private readonly IDocGiaRepository docgiaRepository;
        public DocGiaService(IDocGiaRepository docgiaRepository)
        {
            this.docgiaRepository = docgiaRepository;
        }

        public void CreateDocGia(DocGiaDTO docGiaDTO)
        {
            var docgia = docGiaDTO.MappingDocGia();
            docgiaRepository.Add(docgia);
        }

        public void DeleteDocGia(int MaDG)
        {
            var docgia = docgiaRepository.GetBy(MaDG);
            docgiaRepository.Delete(docgia);
        }

        public DocGiaDTO GetDocGia(int MaDG)
        {
            var docGia = docgiaRepository.GetBy(MaDG);
            return docGia.MappingDTO();
        }

        public IEnumerable<DocGiaDTO> GetDSDocGia(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var docGias = docgiaRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return docGias.MappingDtos();
        }


        public void UpdateDocGia(DocGiaDTO docGiaDTO)
        {
            var docgia = docgiaRepository.GetBy(docGiaDTO.MaDG);
            docGiaDTO.MappingDocGia(docgia);
            docgiaRepository.Update(docgia);
        }
      
    }
}
