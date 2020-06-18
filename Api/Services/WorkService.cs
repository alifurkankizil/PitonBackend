using Api.Context;
using Api.Models;
using Api.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{

    public interface IWorkService
    {
        Task<bool> Add(WorkDTO model);
    }

    public class WorkService : IWorkService
    {

        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public WorkService(IMapper mapper,ApiContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> Add(WorkDTO model)
        {
            var work = _mapper.Map<Work>(model);

            await _context.Works.AddAsync(work);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
