using proiectDAW.Models.DTOs;
using proiectDAW.Models.Many_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public interface IRetetaService
    {
        List<RetetaDTO> getReteteFromCollection(Guid colId);
        RetetaDTO createReteta(Reteta reteta, Guid colId);
        Reteta FindById(Guid retetaId);
        RetetaDTO deleteReteta(Reteta reteta);
        void Save();

    }
}
